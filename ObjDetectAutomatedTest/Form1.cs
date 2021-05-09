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

        /// <summary>
        /// The types of tests that will be ran
        /// </summary>
        private enum exe_method
        {
            BASIC,
            BASIC_GREY,
            GREY,
            GREY_GREY,
            COMBO,
            COMBO_GREY,
            INVERT_BASIC,
            INVERT_BASIC_GREY,
            INVERT_GREY,
            INVERT_GREY_GREY,
            INVERT_COMBO,
            INVERT_COMBO_GREY
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            /*
            // Initialize the data for Tensorflow model using basic images
            InitializeTensor(exe_method.BASIC);

            // Run a test using basic test images
            RunTensorflowTest(exe_method.BASIC);
            // Run a test using greyscaled test images
            RunTensorflowTest(exe_method.BASIC_GREY);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();

            // Initialize the data for Tensorflow model using grey images
            InitializeTensor(exe_method.GREY);

            // Run a test using basic test images
            RunTensorflowTest(exe_method.GREY);
            // Run a test using greyscaled test images
            RunTensorflowTest(exe_method.GREY_GREY);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();

            // Initialize the data for Tensorflow model using grey images
            InitializeTensor(exe_method.COMBO);

            // Run a test using basic test images
            RunTensorflowTest(exe_method.COMBO);
            // Run a test using greyscaled test images
            RunTensorflowTest(exe_method.COMBO_GREY);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();
            */

            ///
            /// Run the previous tests with inverted libraries, larger training, smaller testing samples
            ///

            // Initialize the data for Tensorflow model using basic images
            InitializeTensor(exe_method.INVERT_BASIC);

            // Run a test using basic test images
            RunTensorflowTest(exe_method.INVERT_BASIC);
            // Run a test using greyscaled test images
            RunTensorflowTest(exe_method.INVERT_BASIC_GREY);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();

            // Initialize the data for Tensorflow model using grey images
            InitializeTensor(exe_method.INVERT_GREY);

            // Run a test using basic test images
            RunTensorflowTest(exe_method.INVERT_GREY);
            // Run a test using greyscaled test images
            RunTensorflowTest(exe_method.INVERT_GREY_GREY);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();

            // Initialize the data for Tensorflow model using grey images
            InitializeTensor(exe_method.INVERT_COMBO);

            // Run a test using basic test images
            RunTensorflowTest(exe_method.INVERT_COMBO);
            // Run a test using greyscaled test images
            RunTensorflowTest(exe_method.INVERT_COMBO_GREY);

            // End the first prediction method before starting to teach a new one
            predictionFunc.Dispose();
        }

        // Generated prediction engine used to check loaded images
        private PredictionEngine<ImageData, ImagePrediction> predictionFunc;

        private void InitializeTensor(exe_method method)
        {
            // Set the image folder to be used in training
            string imageLoc;
            // Set the label file to be used for the images to be trained
            string labels;

            switch (method)
            {
                case exe_method.BASIC_GREY:
                    {
                        labels = "./labels.csv";
                        imageLoc = "basic_images";
                        break;
                    }
                case exe_method.GREY: case exe_method.GREY_GREY:
                    {
                        labels = "./labels.csv";
                        imageLoc = "grey_images";
                        break;
                    }
                case exe_method.COMBO: case exe_method.COMBO_GREY:
                    {
                        labels = "./labels-combined.csv";
                        imageLoc = "combined_images";
                        break;
                    }
                case exe_method.INVERT_BASIC: case exe_method.INVERT_BASIC_GREY:
                    {
                        labels = "./invert-labels.csv";
                        imageLoc = "basic_test_images";
                        break;
                    }
                case exe_method.INVERT_GREY: case exe_method.INVERT_GREY_GREY:
                    {
                        labels = "./invert-labels.csv";
                        imageLoc = "grey_test_images";
                        break;
                    }
                case exe_method.INVERT_COMBO: case exe_method.INVERT_COMBO_GREY:
                    {
                        labels = "./invert-combined-labels.csv";
                        imageLoc = "combined_test_images";
                        break;
                    }
                default:
                    {
                        labels = "./labels.csv";
                        imageLoc = "basic_images";
                        break;
                    }
            }

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

        private void RunTensorflowTest(exe_method method){
            string imgDir;

            switch (method)
            {
                case exe_method.BASIC_GREY:
                case exe_method.GREY_GREY:
                case exe_method.COMBO_GREY:
                    {
                        imgDir = "./grey_test_images";
                        break;
                    }
                case exe_method.INVERT_BASIC:
                case exe_method.INVERT_GREY:
                case exe_method.INVERT_COMBO:
                    {
                        imgDir = "./basic_images";
                        break;
                    }
                case exe_method.INVERT_BASIC_GREY:
                case exe_method.INVERT_GREY_GREY:
                case exe_method.INVERT_COMBO_GREY:
                    {
                        imgDir = "./grey_images";
                        break;
                    }
                default:
                    {
                        imgDir = "./basic_test_images";
                        break;
                    }
            }

            int iterations = 0;
            int correct = 0;
            // Go through and run predictions on all images in the subfolders
            foreach (string imgFile in Directory.GetFiles(imgDir))
            {
                iterations++;
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
                if (prediction.Equals(answer))
                {
                    accuracies.Add(100f);
                    correct++;
                }
                else accuracies.Add(0f);

                var confidence = singlePrediction.Score.Max();
                confidences.Add(confidence);
                // Print out the current prediction
                lb_current_output.Items.Add(addressSplit[1] + ", predicted:" + prediction + ", answer:" + answer + ", confidence:" + confidence);

                // Update the outputs
                tb_accuracy.Text = accuracies.Average().ToString();
                tb_confidence.Text = confidences.Average().ToString();

                // Slow it down for presentation?
                //Thread.Sleep(100);
                this.Refresh();
            }

            // Print out final results and reset to be used for another test
            var avgAccuracy = accuracies.Average();
            var avgConfidence = confidences.Average();

            switch (method)
            {
                case exe_method.BASIC_GREY:
                    {
                        lb_final_output.Items.Add(
                            "Plain Trained, "
                            + "Greyscale Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.GREY:
                    {
                        lb_final_output.Items.Add(
                            "Greyscale Trained, "
                            + "Plain Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.GREY_GREY:
                    {
                        lb_final_output.Items.Add(
                            "Greyscale Trained, "
                            + "Greyscale Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.COMBO:
                    {
                        lb_final_output.Items.Add(
                            "Combined Trained, "
                            + "Plain Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.COMBO_GREY:
                    {
                        lb_final_output.Items.Add(
                            "Combined Trained, "
                            + "Greyscale Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.INVERT_BASIC:
                    {
                        lb_final_output.Items.Add(
                            "Basic Invert Trained, "
                            + "Plain Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.INVERT_BASIC_GREY:
                    {
                        lb_final_output.Items.Add(
                            "Basic Invert Trained, "
                            + "Grey Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.INVERT_GREY:
                    {
                        lb_final_output.Items.Add(
                            "Grey Invert Trained, "
                            + "Plain Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.INVERT_GREY_GREY:
                    {
                        lb_final_output.Items.Add(
                            "Grey Invert Trained, "
                            + "Grey Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.INVERT_COMBO:
                    {
                        lb_final_output.Items.Add(
                            "Combined Invert Trained, "
                            + "Plain Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                case exe_method.INVERT_COMBO_GREY:
                    {
                        lb_final_output.Items.Add(
                            "Combined Invert Trained, "
                            + "Grey Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
                default:
                    {
                        lb_final_output.Items.Add(
                            "Plain Trained, "
                            + "Plain Test Images:"
                            + " Accuracy:= " + avgAccuracy
                            + ", Confidence:= " + avgConfidence);
                        break;
                    }
            }

            lb_final_output.Items.Add("Iterations: " + iterations + ", Correct Prediction: " + correct + ", Incorrect Predictions: " + (iterations - correct));
            accuracies.Clear();
            confidences.Clear();
        }
    }
}
