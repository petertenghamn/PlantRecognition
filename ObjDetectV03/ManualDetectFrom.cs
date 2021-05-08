using Alturos.Yolo;
using Alturos.Yolo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjDetectV03
{
    public partial class ManualDetectFrom : Form
    {
        // Global vars
        private bool isInputGreyscaled;

        private string basePath = @"D:\Program Files (x86)\GitHub\darknet-master\build\darknet\x64";
        // End global vars

        public ManualDetectFrom(bool inputGreyScaled)
        {
            InitializeComponent();

            // Set variables from main window to use
            isInputGreyscaled = inputGreyScaled;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "ImageFiles|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btn_detect_Click(object sender, EventArgs e)
        {
            output_box.Items.Clear();

            // There should be 2 more options, if the colored training works, implement the greyscaled training
            if (isInputGreyscaled) {
                RunCTrainedWithGreyInput();
            }
            else
            {
                RunControlTest();
            }
        }

        /// <summary>
        /// Colored images were used for the training model
        /// Colored images are used for testing
        /// </summary>
        private void RunControlTest()
        {
            // Run detection logic
            if (picImage != null)
            {
                try
                {
                    // Files needed for model
                    var ConfigFile = Path.Combine(basePath, "yolov3-tiny-obj.cfg");
                    var WeightsFile = Path.Combine(basePath, "yolov3-tiny-obj-basic.weights");
                    var NamesFile = Path.Combine(basePath, @"data\obj.names");

                    var configurationDetector = new ConfigurationDetector();
                    var config = configurationDetector.Detect();
                    //Basic trained weights (using colored images)
                    var yolo = new YoloWrapper(ConfigFile, WeightsFile, NamesFile);
                    var memoryStream = new MemoryStream();
                    picImage.Image.Save(memoryStream, ImageFormat.Png);
                    var _items = yolo.Detect(memoryStream.ToArray()).ToList();
                    AddDetailsToPicture(picImage, _items);
                }
                catch (Exception err)
                {
                    Console.Out.WriteLine(err.Message);
                }
            }
        }

        /// <summary>
        /// Colored images were used for the training model
        /// Images are greyscaled for testing
        /// </summary>
        private void RunCTrainedWithGreyInput()
        {

        }

        /// <summary>
        /// Converts the image input into a greyscaled version
        /// </summary>
        /// <param name="bmp"></param>
        private void convertBitmapToGreyscale(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);

                    //Apply conversion equation
                    byte gray = (byte)(.21 * c.R + .71 * c.G + .071 * c.B);

                    //Set the color of this pixel
                    bmp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
        }

        /// <summary>
        /// Adds boxes and class names to the image
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="items"></param>
        private void AddDetailsToPicture(PictureBox pictureBox, List<YoloItem> items)
        {
            var img = pictureBox.Image;

            var font = new Font("Arial", 12, FontStyle.Bold);
            var brush = new SolidBrush(Color.Cyan);

            var graphics = Graphics.FromImage(img);
            int i = 0;
            foreach (var item in items)
            {
                i++;
                // Format the percentile confidence
                var confidence = String.Format("{0:P2}", item.Confidence);
                output_box.Items.Add("[" + i + "] " + item.Type + ": " + confidence + " con");

                var x = item.X;
                var y = item.Y;
                var w = item.Width;
                var h = item.Height;

                var point = new Point(x + (w / 2) - 12, y + (h / 2) - 6);

                var rect = new Rectangle(x, y, w, h);
                var pen = new Pen(Color.Cyan, 2);

                graphics.DrawRectangle(pen, rect);
                graphics.DrawString("[" + i + "]", font, brush, point);
            }
            pictureBox.Image = img;
        }
    }
}
