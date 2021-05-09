using Microsoft.ML;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ObjDetectV01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Initialize the data for Tensorflow model
            InitializeTensor();
        }

        // Generated prediction engine used to check loaded images
        private PredictionEngine<ImageData, ImagePrediction> predictionFunc;
        private ImageData imageLoaded;

        private void InitializeTensor()
        {
            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<ImageData>("./labels.csv", separatorChar: ',');

            var pipeline = context.Transforms.Conversion.MapValueToKey("LabelKey", "Label")
                .Append(context.Transforms.LoadImages("input", "images", nameof(ImageData.ImagePath)))
                .Append(context.Transforms.ResizeImages("input", InceptionSettings.ImageWidth,
                    InceptionSettings.ImageHeight, "input"))
                .Append(context.Transforms.ExtractPixels("input", interleavePixelColors: InceptionSettings.ChannelsList,
                    offsetImage: InceptionSettings.Mean))
                .Append(context.Model.LoadTensorFlowModel("./model/tensorflow_inception_graph.pb")
                    .ScoreTensorFlowModel(new[] { "softmax2_pre_activation" }, new[] { "input" }, addBatchDimensionInput: true))
                .Append(context.MulticlassClassification.Trainers.LbfgsMaximumEntropy("LabelKey", "softmax2_pre_activation"))
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabelValue", "PredictedLabel"));

            var model = pipeline.Fit(data);

            var imageData = File.ReadAllLines("./labels.csv")
                .Select(l => l.Split(','))
                .Select(l => new ImageData { ImagePath = Path.Combine(Environment.CurrentDirectory, "images", l[0]) });

            var imageDataView = context.Data.LoadFromEnumerable(imageData);

            var predictions = model.Transform(imageDataView);

            var imagePredictions = context.Data.CreateEnumerable<ImagePrediction>(predictions, reuseRowObject: false, ignoreMissingColumns: true);

            var evalPredictions = model.Transform(data);

            var metrics = context.MulticlassClassification.Evaluate(evalPredictions, labelColumnName: "LabelKey",
                predictedLabelColumnName: "PredictedLabel");

            Console.WriteLine($"Log loss - {metrics.LogLoss}");

            predictionFunc = context.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            imageLoaded = null;
            tb_prediction.Text = "";
            tb_accuracy.Text = "";

            var ofd = new OpenFileDialog();
            ofd.Filter = "ImageFiles|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
                imageLoaded = new ImageData { ImagePath = ofd.FileName };
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Flower/Weed detector logic
            if (imageLoaded != null)
            {
                // This doesn't currently use the loaded image
                var singlePrediction = predictionFunc.Predict(imageLoaded);

                tb_prediction.Text = singlePrediction.PredictedLabelValue;
                tb_accuracy.Text = singlePrediction.Score.Max().ToString();

                Console.WriteLine($"Image {Path.GetDirectoryName(singlePrediction.ImagePath)} was presicted as " +
                    $"a {singlePrediction.PredictedLabelValue} with a score of {singlePrediction.Score.Max()}");
            }
        }
    }
}
