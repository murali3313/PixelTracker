using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using RecordAndPlayBack;

namespace PixTracker
{
    public partial class AssertBox : Form
    {
        private Image screenShot;

        public AssertBox()
        {
            InitializeComponent();
        }

        public Image ScreenShot
        {
            get {
                return screenShot;
            }
            set {
                screenShot = value;
                picAssertScreenShot.Image = value;
            }
        }

        private int xCoOrdinate = 0;
        private int yCoOrdinate = 0;

        private void picAssertScreenShot_MouseDown(object sender, MouseEventArgs e)
        {
            xCoOrdinate = e.X;
            yCoOrdinate = e.Y;
        }

        public static AssertionAction AssertionData=new AssertionAction();

        private void picAssertScreenShot_MouseUp(object sender, MouseEventArgs e)
        {
            var width = Math.Abs(xCoOrdinate - e.X);
            var height= Math.Abs(yCoOrdinate - e.Y);

            if (width <= 8 || height <= 8)
            {
                foreach (var assertiondatum in AssertionData)
                {
                    var startPointX = assertiondatum.CropInfo.X;
                    var endPointX = startPointX+assertiondatum.CropInfo.Width;
                    
                    var startPointY = assertiondatum.CropInfo.Y;
                    var endPointY = startPointY+assertiondatum.CropInfo.Height;
                    if ((startPointX <= e.X) && (e.X <= endPointX)&&(startPointY <= e.Y) && (e.Y <= endPointY))
                    {
                        var reasonBox = new ReasonBox(assertiondatum);
                        reasonBox.ShowDialog();
                        break;
                    }
                }
            }
            else
            {
                var bitmap = new Bitmap(picAssertScreenShot.Image);
                var startPointX = e.X - width;
                var startPointY = e.Y - height;
                var markingRect = new Rectangle(startPointX, startPointY, width, height);
                var clonedImage = bitmap.Clone(markingRect, bitmap.PixelFormat);
                AssertionData.Add(clonedImage, startPointX, startPointY, width, height);


                Graphics.FromImage(picAssertScreenShot.Image).DrawRectangle(new Pen(Color.Red, 1), markingRect);

                Graphics.FromImage(picAssertScreenShot.Image).DrawString(AssertionData.Count.ToString(),
                                                                         new Font(
                                                                             new FontFamily(GenericFontFamilies.Serif),
                                                                             25,
                                                                             GraphicsUnit.Pixel),
                                                                         new SolidBrush(Color.Green),
                                                                         new RectangleF(startPointX + width/2,
                                                                                        startPointY + 20, 40, 40));
                picAssertScreenShot.Image = picAssertScreenShot.Image;
                bitmap.Dispose();
            }
        }
    }
}
