using System;

namespace PXLPro2022Shoppers07.Helpers
{
    public class ImageHelper
    {
        public static string CreateBase64StringFromByteArray(byte[] byteArray) =>
            $"data:image/jpg;base64,{Convert.ToBase64String(byteArray)}";
    }
}
