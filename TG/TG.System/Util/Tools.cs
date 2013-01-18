using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Plan5W2HPlusPlus.Application.Util
{
    public class Tools
    {
        public static String retrieveUserFromCookie(Plan5W2HPlusPlus.Application.MvcApplication app)
        {
            if (app.User.Identity.IsAuthenticated)
            {
                HttpCookie cookie = app.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                return FormsAuthentication.Decrypt(cookie.Value).Name;
            }
            return null;
        }

        public static Bitmap ResizeImage(Image oldImage, int newWidth, int newHeight)
        {
            var bitmap = new Bitmap(newWidth, newHeight);
            try
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(oldImage,
                        new Rectangle(0, 0, newWidth, newHeight),
                        new Rectangle(0, 0, oldImage.Width, oldImage.Height), GraphicsUnit.Pixel);
                }//done with drawing on "g"
                return bitmap;//transfer IDisposable ownership
            }
            catch
            { //error before IDisposable ownership transfer
                if (bitmap != null) bitmap.Dispose();
                throw;
            }
        }

        public static Image CropImageToSquare(Image img)
        {
            bool vertical = img.Height > img.Width? true : false;
            int ladoMenor = img.Height > img.Width? img.Width : img.Height;
            int sobras;
            double temp;
            if (vertical)
            {
                temp = (img.Height - img.Width) / 2;
                sobras = Convert.ToInt32(Math.Round(temp));
            }
            else
            {
                temp = (img.Width - img.Height) / 2;
                sobras = Convert.ToInt32(Math.Round(temp));
            }

            Rectangle cropArea;
            if (vertical)
            {
                cropArea = new Rectangle(0, sobras, ladoMenor, ladoMenor);
            }
            else
            {
                cropArea = new Rectangle(sobras, 0, ladoMenor, ladoMenor);
            }

            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        public static bool FileExists(String path)
        {
            if (File.Exists(path))
                return true;

            return false;
        }
    }
}