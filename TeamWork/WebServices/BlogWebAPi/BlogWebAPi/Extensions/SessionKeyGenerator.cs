namespace BlogWebAPi.Extensions
{
    using System;
    using System.Linq;
    using System.Text;

    public static class SessionKeyGenerator
    {
        private const int SessionKeyLength = 49;
        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        public static string Generate(int userId)
        {
            StringBuilder str = new StringBuilder(SessionKeyLength);
            str.Append(userId);
            while (str.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                str.Append(SessionKeyChars[index]);
            }

            return str.ToString();
        }
    }
}