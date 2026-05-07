using System.Globalization;
using TheElm.Literals.Objects;

namespace TheElm.Literals {
    public static partial class Casing {
        extension( char value ) {
            /// <summary>
            /// Change the Casing of a Character
            /// </summary>
            public char To( CharacterCasing casing )
                => value.To(CultureInfo.InvariantCulture, casing);
            
            /// <summary>
            /// Change the Casing of a Character
            /// </summary>
            public char To( CultureInfo info, CharacterCasing casing )
                => value.To(info.TextInfo, casing);
            
            /// <summary>
            /// Change the Casing of a Character
            /// </summary>
            public char To( TextInfo info, CharacterCasing casing )
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
}
