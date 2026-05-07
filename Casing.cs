using System.Globalization;

namespace TheElm.Literals {
    public static partial class Casing {
        public static string UppercaseFirst( this string input, CultureInfo? cultureInfo = null ) {
            if ( input.ToCharArray() is not {Length: >0} array ) {
                return string.Empty;
            }
            
            // Modify the first char
            array[0] = char.ToUpper(array[0], cultureInfo ?? CultureInfo.CurrentCulture);
            
            // Create a new string from the array
            return new string(array);
        }
        
        extension( TextInfo info ) {
            private string RandomCase( string str ) {
                Random random = Random.Shared;
                return str.Select(c => info.RandomCase(c, random)).JoinToString();
            }
            
            private char RandomCase( char val )
                => info.RandomCase(val, Random.Shared);
            
            private char RandomCase( char val, Random random )
                => random.NextDouble() >= 0.5 ? info.ToUpper(val) : info.ToLower(val);
        }
        
        private static string CamelCase( this string str ) {
            if (string.IsNullOrEmpty(str))
                return str;
            
            return string.Join(".", str.Split('.')
                .Select(part => char.ToLowerInvariant(part[0]) + part[1..]));
        }
    }
}
