using System.Security.Cryptography;
using System.Text;

namespace TheElm.Literals {
    public static class RandomString {
        /// <summary>
        /// Create a random length string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Create( int length ) {
            // Create a span
            Span<char> span = [ ..Enumerable.Repeat(Literals.ALL_VALID, 5).SelectMany(str => str.ToCharArray()) ];
            
            // Shuffle the span
            RandomNumberGenerator.Shuffle(span);
            
            // Get the span result
            return new string(span[..length]);
        }
        
        public static string CreateAlphanumeric(in int length)
            => RandomString.Random(Literals.ALPHANUMERICAL, in length);
        
        public static string CreateAlphabetic(in int length)
            => RandomString.Random(Literals.ALPHABETIC, in length);
        
        public static string CreateNumeric(in int length)
            => RandomString.Random(Literals.NUMBERIC, in length);
        
        /// <summary>Create a random string using the characters provided in the input string</summary>
        /// <param name="characters"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Random( in string characters, in int length ) {
            StringBuilder @string = new();
            
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) {
                byte[] buffer = new byte[sizeof(uint)];
                
                for (int i = length; i > 0; i--) {
                    rng.GetBytes(buffer);
                    
                    uint num = BitConverter.ToUInt32(buffer, 0);
                    
                    @string.Append(characters[(int)(num % (uint)characters.Length)]);
                }
            }
            
            return @string.ToString();
        }
    }
}
