using System.Globalization;
using TheElm.Literals.Objects;

namespace TheElm.Literals {
    public static partial class Casing {
        extension( Enum e ) {
            /// <summary>
            /// Change the Character Casing of a String
            /// </summary>
            public string To( CharacterCasing casing )
                => e.To(CultureInfo.InvariantCulture, casing);
            
            /// <summary>
            /// Change the Character Casing of a String
            /// </summary>
            public string To( CultureInfo info, CharacterCasing casing )
                => e.To(info.TextInfo, casing);
            
            /// <summary>
            /// Change the Character Casing of an Enum
            /// </summary>
            public string To( TextInfo info, CharacterCasing casing )
                => casing switch {
                    CharacterCasing.LOWER => info.ToLower(e.ToString()),
                    CharacterCasing.NORMAL => e.ToString(),
                    CharacterCasing.UPPER => info.ToUpper(e.ToString()),
                    CharacterCasing.TITLE => info.ToTitleCase(e.ToString()),
                    CharacterCasing.RANDOM => info.RandomCase(e.ToString()),
                    CharacterCasing.CAMEL => e.ToString()
                        .CamelCase(),
                    _ => throw new ArgumentOutOfRangeException(nameof(casing), casing, null)
                };
        }
    }
}
