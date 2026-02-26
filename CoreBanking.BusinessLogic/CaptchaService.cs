using System;
using CoreBanking.Entities;
using System.Drawing;
using CoreBanking.BusinessLogic;

namespace CoreBanking.BusinessLogic
{
   
        public static class CaptchaService
        {
            public static (string code, Image image) GenarateCaptcha()
            {
                string code = CaptchaGenerator.GenerateCode();
                Image image = CaptchaGenerator.GenerateImage(code);
                return (code, image);
            }
        }

    }


