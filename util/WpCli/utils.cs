using System;
using System.IO;

    public class Util{
        private static byte[] ConvertStringToByteArray(string data)
        {
            return(new System.Text.UnicodeEncoding()).GetBytes(data);
        }

        private static System.IO.FileStream GetFileStream(string pathName)
        {
            return(new System.IO.FileStream(pathName, System.IO.FileMode.Open, 
                        System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));
        }

        public static string GetSHA1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1Hasher=
                        new System.Security.Cryptography.SHA1CryptoServiceProvider();

            try
            {
                oFileStream = GetFileStream(pathName);
                arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream);
                oFileStream.Close();

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch(System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return(strResult);
        }

        public static void AddImage(string pathOrg, string pathDst)
        {
            if (File.Exists(pathDst))
            {
                var preForegroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("File already existed!! will abort this action");
                Console.ForegroundColor = preForegroundColor;
                return;
            }
            File.Copy(pathOrg, pathDst);
        }
    }