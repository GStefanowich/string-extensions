namespace TheElm.Literals {
    public static class Substitution {
        /// <param name="input"></param>
        extension( string input ) {
            /// <summary>Trim a length of string from the start of a string</summary>
            /// <param name="fromStart"></param>
            /// <returns></returns>
            public  string TrimStart( string fromStart )
                => input.StartsWith(fromStart, StringComparison.InvariantCultureIgnoreCase) ? input[fromStart.Length..].TrimStart() : input;
            
            /// <summary>Trim a length of string from the end of a string</summary>
            /// <param name="fromEnd"></param>
            /// <returns></returns>
            public  string TrimEnd( string fromEnd )
                => input.EndsWith(fromEnd, StringComparison.InvariantCultureIgnoreCase) ? input[..^fromEnd.Length].TrimEnd() : input;
        }
    }
}
