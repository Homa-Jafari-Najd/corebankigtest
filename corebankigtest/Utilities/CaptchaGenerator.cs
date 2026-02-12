using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace corebankingtest.Utilities
{
    public class CaptchaGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateCode(int length = 5)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            string code = "";
            for (int i = 0; i < length; i++)
                code += chars[random.Next(chars.Length)];
            return code;
        }

        public static Bitmap GenerateImage(string captchaCode)
        {
            Bitmap bitmap = new Bitmap(180, 50);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                using (Font font = new Font("Arial", 22, FontStyle.Bold))
                {
                    g.DrawString(captchaCode, font, Brushes.Black, new PointF(10, 5));
                }

                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(Pens.Gray,
                        random.Next(bitmap.Width), random.Next(bitmap.Height),
                        random.Next(bitmap.Width), random.Next(bitmap.Height));
                }
            }
            return bitmap;
        }
    }
}