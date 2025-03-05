namespace TheElm.Literals {
    public static partial class Concatenation {
        public static string PadLeft(string val, string padWith, int minLength)
            => $"{padWith.Repeat(minLength - val.Length)}{val}";
        
        public static string PadLeft(string val, char padWith, int minLength)
            => $"{padWith.Repeat(minLength - val.Length)}{val}";
        
        public static string PadRight(string val, string padWith, int minLength)
            => $"{val}{padWith.Repeat(minLength - val.Length)}";
        
        public static string PadRight(string val, char padWith, int minLength)
            => $"{val}{padWith.Repeat(minLength - val.Length)}";
    }
}
