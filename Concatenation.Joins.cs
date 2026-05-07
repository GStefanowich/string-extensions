namespace TheElm.Literals {
    public static partial class Concatenation {
        /// <param name="array"></param>
        extension( IEnumerable<string> array ) {
            public string Join(   string join = "" )
                => string.Join(join, array);
            
            public string Join(  char join )
                => string.Join(join, array);
            
            /// <summary>
            /// Join a list of string while running a function on each string
            /// </summary>
            /// <param name="func"></param>
            /// <returns></returns>
            public string Join( Func<string, string> func )
                => array.Select(func)
                    .Join();
        }
        
        extension<T>( IEnumerable<T> array ) where T : struct {
            public string Join( string join = "" )
                => array.Select(t => t.ToString() ?? string.Empty)
                    .Join(join);
            
            public string Join( char join )
                => array.Select(t => t.ToString() ?? string.Empty)
                    .Join(join);
        }
        
        extension<T>( IEnumerable<T> array ) {
            public string JoinToString( string join = "" )
                => array.JoinToString(join, t => t?.ToString() ?? string.Empty);
            
            public string JoinToString( string join, Func<T, string> cast )
                => array.Select(cast)
                    .Where(str => str is {Length: >0})
                    .Join(join);
            
            public string JoinToString( char join )
                => array.JoinToString(join, t => t?.ToString() ?? string.Empty);
            
            public string JoinToString( char join, Func<T, string> cast )
                => array.Select(cast)
                    .Where(str => str is {Length: >0})
                    .Join(join);
        }
    }
}
