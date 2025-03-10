using System.Text;

namespace TheElm.Literals {
    public static partial class Literals {
        /// <summary>Run Rotation13 on the string</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Rot13( this string input )
            => !string.IsNullOrEmpty(input) ? new string(input.ToCharArray().Rot13()) : input;
        
        /// <summary>Run Rotation13 on the string</summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static char[] Rot13( this IEnumerable<char> array )
            => array.Select(s => (char)(( s >= 97 && s <= 122 ) ? ( (s + 13 > 122 ) ? s - 13 : s + 13) : ( s >= 65 && s <= 90 ? (s + 13 > 90 ? s - 13 : s + 13) : s ))).ToArray();
        
        public static string Base64Encode( this string encode )
            => encode.Base64Encode(Encoding.UTF8);
        
        public static string Base64Encode( this string encode, Encoding encoding )
            => Convert.ToBase64String(encoding.GetBytes(encode));
        
        public static string Base64Decode( this string decode )
            => decode.Base64Decode(Encoding.UTF8);
        
        public static string Base64Decode( this string decode, Encoding encoding )
            => encoding.GetString(Convert.FromBase64String(decode));
    }
}
