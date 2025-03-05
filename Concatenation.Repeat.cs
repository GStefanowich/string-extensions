namespace TheElm.Literals {
    public static partial class Concatenation {
        /// <summary>Create a repeating string using a string</summary>
        /// <param name="string"></param>
        /// <param name="repeat"></param>
        /// <returns></returns>
        public static string Repeat(this string @string, int repeat)
            => repeat <= 0 ? string.Empty : string.Concat(Enumerable.Repeat(@string, repeat));
        
        /// <summary>Create a repeating string using a char</summary>
        /// <param name="character"></param>
        /// <param name="repeat"></param>
        /// <returns></returns>
        public static string Repeat(this char character, int repeat) {
            if (repeat < 0)
                throw new ArgumentOutOfRangeException(nameof(repeat), $"Not possible to repeat '{character}' {repeat} times.");
            
            return new string(character, repeat);
        }
    }
}
