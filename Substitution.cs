namespace TheElm.Literals {
    public static class Substitution {
        /// <summary>Trim a length of string from the start of a string</summary>
        /// <param name="input"></param>
        /// <param name="fromStart"></param>
        /// <returns></returns>
        public static string TrimStart( this string input, string fromStart )
            => input.StartsWith(fromStart, StringComparison.InvariantCultureIgnoreCase) ? input[fromStart.Length..].TrimStart() : input;
        
        /// <summary>Trim a length of string from the end of a string</summary>
        /// <param name="input"></param>
        /// <param name="fromEnd"></param>
        /// <returns></returns>
        public static string TrimEnd( this string input, string fromEnd )
            => input.EndsWith(fromEnd, StringComparison.InvariantCultureIgnoreCase) ? input[..^fromEnd.Length].TrimEnd() : input;
    }
}
