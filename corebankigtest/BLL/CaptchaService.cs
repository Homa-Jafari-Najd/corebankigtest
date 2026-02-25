using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using corebankingtest.Utilities;

namespace corebankigtest.BLL
{
   
        internal static class CaptchaService
        {
            public static (string code, Image image) GenarateCaptcha()
            {
                string code = CaptchaGenerator.GenerateCode();
                Image image = CaptchaGenerator.GenerateImage(code);
                return (code, image);
            }
        }

    }


