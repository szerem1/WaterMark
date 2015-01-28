using System.IO;

namespace WaterMark
{
    public static class Helper
    {
        public static byte[] ToByteArray(Stream ms)
        {
            byte[] bytes = new byte[ms.Length];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(bytes, 0, bytes.Length);
            return bytes;
        } 
    }
}