using System;

namespace ProcessHollow
{
    public static class ShellcodeConverter
    {
        public static byte[] ConvertRawStringToByteArray(string rawString) {
            if (rawString.Length % 2 != 0)
                throw new ArgumentException("String should've a pair char number.");

            int byteCount = rawString.Length / 2;
            byte[] byteArray = new byte[byteCount];

            for (int i = 0; i < byteCount; i++) {
                string byteStr = rawString.Substring(i * 2, 2);
                byteArray[i] = Convert.ToByte(byteStr, 16);
            }
            return byteArray;
        }

        public static byte[] EncryptDecryptByteArray(byte[] byteArray) {
            for (int i = 0; i < byteArray.Length; i++)
                byteArray[i] = (byte)(byteArray[i] ^ 54);
            return byteArray;
        }

        public static void PrintByteArray(byte[] byteArray) {
            Console.Write("byte[] shellcode = new byte[" + byteArray.Length + "] { ");
            for (int i = 0; i < byteArray.Length; i++) {
                Console.Write(@"\x" + byteArray[i].ToString("X2"));
                if (i != byteArray.Length - 1) Console.Write(", ");
            }
            Console.WriteLine(" };");
        }
    }
}