using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using TheElm.Literals.Objects;

namespace TheElm.Literals {
    public static partial class Casing {
        extension( string? value ) {
            /// <summary>
            /// Change the Character Casing of a String
            /// </summary>
            [return: NotNullIfNotNull(nameof(value))]
            public string? To( CharacterCasing casing )
                => value.To(CultureInfo.InvariantCulture, casing);
            
            /// <summary>
            /// Change the Character Casing of a String
            /// </summary>
            [return: NotNullIfNotNull(nameof(value))]
            public string? To( CultureInfo info, CharacterCasing casing )
                => value.To(info.TextInfo, casing);
            
            /// <summary>
            /// Change the Character Casing of a String
            /// </summary>
            [return: NotNullIfNotNull(nameof(value))]
            public string? To( TextInfo info, CharacterCasing casing ) {
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
        }
    }
}
