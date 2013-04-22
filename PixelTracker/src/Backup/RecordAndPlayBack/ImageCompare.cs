using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RecordAndPlayBack
{
    class ImageCompare
    {


        public int CompareImage(Bitmap img1,Bitmap img2)
        {
            string img1_ref, img2_ref;
            img1 = new Bitmap(img1);
            img2 = new Bitmap(img2);
            var unMatchCount = 0;
            var notEqual = false;
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                    
                    
                        if (img1_ref != img2_ref)
                        {
                            unMatchCount++;
                            notEqual = true;
                            break;
                        }
                    }
                }
            }
            return unMatchCount;
        }
    }
}
