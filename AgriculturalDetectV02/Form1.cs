using Alturos.Yolo;
using Alturos.Yolo.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ObjDetectV02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "ImageFiles|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
            }
        }

        private async void btnDisplay_Click(object sender, EventArgs e)
        {
            // Run detection logic
            if (picImage != null)
            {
                try
                {
                    output_box.Items.Clear();

                    // var configurationDetector = new YoloConfigurationDetector();
                    // var yolo = new YoloWrapper("yolov2-tiny-voc.cfg", "yolov2-tiny-voc.weights", "voc.names"); // The small pre trained dataset

                    // This part techinically only need to run once! comment out when executed
                    /*
                    Console.Out.WriteLine("Starting YOLOV3 Download");
                    var repository = new YoloPreTrainedDatasetRepository();
                    await repository.DownloadDatasetAsync("YOLOv2", ".");
                    Console.Out.WriteLine("YOLOV3 Downloaded!");
                    */

                    using (var yoloWrapper = new YoloWrapper("yolov2.cfg", "yolov2.weights", "coco.names"))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            picImage.Image.Save(ms, ImageFormat.Png);
                            var _items= yoloWrapper.Detect(ms.ToArray()).ToList(); ;
                            AddDetailsToPicture(picImage, _items);
                        }
                    }


                    /*
                    var memoryStream = new MemoryStream();
                    picImage.Image.Save(memoryStream, ImageFormat.Png);
                    var _items = yolo.Detect(memoryStream.ToArray()).ToList();
                    AddDetailsToPicture(picImage, _items);
                    */
                }
                catch (Exception err)
                {
                    Console.Out.WriteLine(err.Message);
                }
            }
        }

        private void AddDetailsToPicture(PictureBox pictureBox, List<YoloItem> items)
        {
            var img = pictureBox.Image;

            var font = new Font("Arial", 12, FontStyle.Bold);
            var brush = new SolidBrush(Color.Cyan);

            var graphics = Graphics.FromImage(img);
            int i = 0;
            foreach(var item in items)
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
