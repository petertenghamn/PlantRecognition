using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ObjDetectAutomatedTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += new System.EventHandler(this.Form1_Shown);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Initialize the data for Tensorflow model using basic images
            InitializeTensor(false, false);

            // Run a test using basic test images
            RunTensorflowTest(false, false, false);
            // Run a test using greyscaled test images
            RunTensorflowTest(true, false, false);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();

            // Initialize the data for Tensorflow model using grey images
            InitializeTensor(true, false);

            // Run a test using basic test images
            RunTensorflowTest(false, true, false);
            // Run a test using greyscaled test images
            RunTensorflowTest(true, true, false);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();

            // Initialize the data for Tensorflow model using grey images
            InitializeTensor(false, true);

            // Run a test using basic test images
            RunTensorflowTest(false, true, true);
            // Run a test using greyscaled test images
            RunTensorflowTest(true, true, true);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();
        }

        // Generated prediction engine used to check loaded images
        private PredictionEngine<ImageData, ImagePrediction> predictionFunc;
        private ImageData imageLoaded;

        private void InitializeTensor(bool greyscaled, bool combined)
        {
            string imageLoc = "basic_images";
            if (greyscaled) imageLoc = "grey_images";
            if (combined) imageLoc = "combined_images";

            string labels = "./labels.csv";
            if (combined) labels = "./labels-combined.csv";

            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<ImageData>(labels, separatorChar: ',');

            var pipeline = context.Transforms.Conversion.MapValueToKey("LabelKey", "Label")
                .Append(context.Transforms.LoadImages("input", imageLoc, nameof(ImageData.ImagePath)))
                .Append(context.Transforms.ResizeImages("input", InceptionSettings.ImageWidth,
                    InceptionSettings.ImageHeight, "input"))
                .Append(context.Transforms.ExtractPixels("input", interleavePixelColors: InceptionSettings.ChannelsList,
                    offsetImage: InceptionSettings.Mean))
                .Append(context.Model.LoadTensorFlowModel("./model/tensorflow_inception_graph.pb")
                    .ScoreTensorFlowModel(new[] { "softmax2_pre_activation" }, new[] { "input" }, addBatchDimensionInput: true))
                .Append(context.MulticlassClassification.Trainers.LbfgsMaximumEntropy("LabelKey", "softmax2_pre_activation"))
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabelValue", "PredictedLabel"));

            var model = pipeline.Fit(data);

            var imageData = File.ReadAllLines(labels)
                .Select(l => l.Split(','))
                .Select(l => new ImageData { ImagePath = Path.Combine(Environment.CurrentDirectory, imageLoc, l[0]) });

            var imageDataView = context.Data.LoadFromEnumerable(imageData);

            var predictions = model.Transform(imageDataView);

            var imagePredictions = context.Data.CreateEnumerable<ImagePrediction>(predictions, reuseRowObject: false, ignoreMissingColumns: true);

            var evalPredictions = model.Transform(data);

            var metrics = context.MulticlassClassification.Evaluate(evalPredictions, labelColumnName: "LabelKey",
                predictedLabelColumnName: "PredictedLabel");

            Console.WriteLine($"Log loss - {metrics.LogLoss}");

            predictionFunc = context.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);
        }

        // Testing variables
        private List<float> accuracies = new List<float>();
        private List<float> confidences = new List<float>();
        // End of testing variables

        private void RunTensorflowTest(bool greyscaled, bool greyscaleTrained, bool combinedTrained){
            string imgDir = "./basic_test_images";
            if (greyscaled) imgDir = "./grey_test_images";

            // Go through and run predictions on all images in the subfolders
            foreach (string imgFile in Directory.GetFiles(imgDir))
            {
                picImage.Image = Image.FromFile(imgFile);
                picImage.Refresh();
                picImage.Visible = true;
                var imageLoaded = new ImageData { ImagePath = "../" + imgFile };

                var singlePrediction = predictionFunc.Predict(imageLoaded);
                // Check if the prediction is correct
                string[] addressSplit = imgFile.Split('\\');
                string[] strSplit = addressSplit[1].Split('-');
                string answer = strSplit[0];
                string prediction = singlePrediction.PredictedLabelValue;

                // Add the accuracy and confidence to lists which will display the total
                if (prediction.Equals(answer)) accuracies.Add(100f);
                else accuracies.Add(0f);

                var confidence = singlePrediction.Score.Max();
                confidences.Add(confidence);
                // Print out the current prediction
                lb_current_output.Items.Add(addressSplit[1] + ", predicted:" + prediction + ", answer:" + answer + ", confidence:" + confidence);

                // Slow it down for presentation?
                Thread.Sleep(100);
                this.Refresh();
            }

            // Print out final results and reset to be used for another test
            var avgAccuracy = accuracies.Average();
            var avgConfidence = confidences.Average();
            if (!combinedTrained)
                lb_final_output.Items.Add((greyscaleTrained ? "Greyscale Trained, " : "Plain Trained, ") + (greyscaled ? "Greyscale Test Images -" : "Plain Test Images -") + " Accuracy = " + avgAccuracy + ", Confidence = " + avgConfidence);
            else
                lb_final_output.Items.Add("Combined Trained, " + (greyscaled ? "Greyscale Test Images -" : "Plain Test Images -") + " Accuracy = " + avgAccuracy + ", Confidence = " + avgConfidence);
            accuracies.Clear();
            confidences.Clear();
        }
    }
}
