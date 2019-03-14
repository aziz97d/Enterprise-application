using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop
{
    static class FileClass
    {
        public static Byte[] ImageToByte(System.Drawing.Image img)
        {
            System.Drawing.ImageConverter d = new ImageConverter();
            Byte[] bta;
            bta = (Byte[]) d.ConvertTo(img, typeof (Byte[]));
            return bta;
        }

        public static System.Drawing.Image ImageFromByte(Object bta)
        {
            try
            {
                System.IO.MemoryStream ms = new MemoryStream();
                return System.Drawing.Image.FromStream(ms);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public static Byte[] FileToByte(string fileName)
        //{
        //    if (string.IsNullOrEmpty(fileName))
        //        return null;
        //    System.IO.FileStream fs = new FileStream(fileName,System.IO.FileStream);
        //}
    }
}
