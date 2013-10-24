namespace BlogWebAPi.Extensions
{
    using System;
    using System.Linq;

    public static class UserValidator
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int MinNicknameLength = 6;
        private const int MaxNicknameLength = 30;
        private const int AuthCodeLength = 40;
        private const int SessionKeyLength = 49;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNicknameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        public static void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey==null)
            {
                throw new ArgumentNullException("SessionKey cannot be null");
            }
            else if (sessionKey.Length < SessionKeyLength || sessionKey.Length > SessionKeyLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("SessionKey must be exactly {0} characters long",
                        SessionKeyLength));
            }
        }

        public static void ValidateAuthCode(string authcode)
        {
            if (authcode == null)
            {
                throw new ArgumentNullException("Authocde cannot be null");
            }

            if (authcode.Length < AuthCodeLength || authcode.Length > AuthCodeLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Authcode must be exactly {0} characters long",
                        AuthCodeLength));
            }
        }

        public static void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                        MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                        MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }

        public static void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (nickname.Length < MinNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be at least {0} characters long",
                        MinNicknameLength));
            }
            else if (nickname.Length > MaxNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be less than {0} characters long",
                        MaxNicknameLength));
            }
            else if (nickname.Any(ch => !ValidNicknameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits, spaces .,_");
            }
        }
    }
}