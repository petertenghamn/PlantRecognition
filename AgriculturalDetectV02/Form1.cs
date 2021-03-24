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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Run detection logic
            if (picImage != null)
            {
                try
                {
                    output_box.Items.Clear();

                    var configurationDetector = new ConfigurationDetector();
                    var config = configurationDetector.Detect();
                    var yolo = new YoloWrapper(config);
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
