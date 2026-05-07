namespace TheElm.Literals {
    public static partial class Concatenation {
        extension( string val ) {
            public string PadLeft( string padWith, int minLength )
                => $"{padWith.Repeat(minLength - val.Length)}{val}";
            
            public string PadLeft( char padWith, int minLength )
                => $"{padWith.Repeat(minLength - val.Length)}{val}";
            
            public string PadRight( string padWith, int minLength )
                => $"{val}{padWith.Repeat(minLength - val.Length)}";
            
            public string PadRight( char padWith, int minLength )
                => $"{val}{padWith.Repeat(minLength - val.Length)}";
        }
    }
}
