using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using TheElm.Literals.Objects;

namespace TheElm.Literals {
    public static class Casing {
        public static string UppercaseFirst( this string input, CultureInfo? cultureInfo = null ) {
            if ( input.ToCharArray() is not {Length: >0} array ) {
                return string.Empty;
            }
            
            // Modify the first char
            array[0] = char.ToUpper(array[0], cultureInfo ?? CultureInfo.CurrentCulture);
            
            // Create a new string from the array
            return new string(array);
        }
        
        private static string RandomCase( this TextInfo info, string str ) {
            System.Random random = new();
            return str.Select(c => info.RandomCase(c, random)).JoinToString();
        }
        
        private static char RandomCase( this TextInfo info, char val )
            => info.RandomCase(val, new System.Random());
        
        private static char RandomCase( this TextInfo info, char val, System.Random random )
            => random.NextDouble() >= 0.5 ? info.ToUpper(val) : info.ToLower(val);
        
        private static string CamelCase( this string str ) {
            if (string.IsNullOrEmpty(str))
                return str;
            return string.Join(".", str.Split('.')
                .Select(part => char.ToLowerInvariant(part[0]) + part[1..]));
        }
        
        /// <summary>
        /// Change the Character Casing of a String
        /// </summary>
        [return: NotNullIfNotNull(nameof(value))]
        public static string? To( this string? value, CharacterCasing casing )
            => value.To(CultureInfo.InvariantCulture, casing);
        
        /// <summary>
        /// Change the Character Casing of a String
        /// </summary>
        [return: NotNullIfNotNull(nameof(value))]
        public static string? To( this string? value, CultureInfo info, CharacterCasing casing )
            => value.To(info.TextInfo, casing);
        
        /// <summary>
        /// Change the Character Casing of a String
        /// </summary>
        [return: NotNullIfNotNull(nameof(value))]
        public static string? To( this string? value, TextInfo info, CharacterCasing casing ) {
            if (value is null)
                return null;
            
            return casing switch {
                CharacterCasing.LOWER => info.ToLower(value),
                CharacterCasing.NORMAL => value,
                CharacterCasing.UPPER => info.ToUpper(value),
                CharacterCasing.TITLE => info.ToTitleCase(value),
                CharacterCasing.RANDOM => info.RandomCase(value),
                CharacterCasing.CAMEL => value.CamelCase(),
                _ => throw new ArgumentOutOfRangeException(nameof(casing), casing, null)
            };
        }
        
        public static char To( this char value, CharacterCasing casing )
            => value.To(CultureInfo.InvariantCulture, casing);
        
        public static char To( this char value, CultureInfo info, CharacterCasing casing )
            => value.To(info.TextInfo, casing);
        
        public static char To( this char value, TextInfo info, CharacterCasing casing )
            => casing switch {
                CharacterCasing.LOWER => info.ToLower(value),
                CharacterCasing.NORMAL => value,
                CharacterCasing.UPPER => info.ToUpper(value),
                CharacterCasing.TITLE => value,
                CharacterCasing.RANDOM => info.RandomCase(value),
                CharacterCasing.CAMEL => value,
                _ => throw new ArgumentOutOfRangeException(nameof(casing), casing, null)
            };
    }
}
