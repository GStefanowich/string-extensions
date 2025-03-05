using System.Diagnostics.CodeAnalysis;

namespace TheElm.Literals {
    public static class Literals {
        #region Constants
        
        public const string NUMBERIC = "0123456789";
        public const string ALPHANUMERICAL = $"{Literals.ALPHABETIC}{Literals.NUMBERIC}";
        public const string ALPHABETIC = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        public const string NUMERICS = "0123456789";
        public const string ALL_VALID = $"{Literals.ALPHABETIC}{Literals.NUMERICS}";
        
        #endregion
        
        /// <summary>
        /// Create a Substring of the given string, even if the given length is out of bounds of the string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [return: NotNullIfNotNull(nameof(input))]
        public static string? SubstringMax( this string? input, int max )
            => input is not null && input.Length > max ? input[..max] : input;
        
        /// <summary>
        /// Get the number of matching characters from the start of two strings
        /// "Apple" and "Banana" would be 0, but "Happy" and "Hapless" would be 3
        /// </summary>
        /// <param name="a">First input string</param>
        /// <param name="b">Second input string</param>
        /// <returns>Number of matching characters from the beginning</returns>
        public static int MatchingStartCharacters( string a, string b ) {
            int len = Math.Min(a.Length, b.Length);
            
            for (int i = 0; i < len; i++) {
                if (!a[i].Equals(b[i]))
                    return i - 1;
            }
            
            return len;
        }
    }
}
