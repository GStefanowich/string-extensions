namespace TheElm.Literals {
    public static partial class Concatenation {
        public static string Join<T>( this IEnumerable<T> array, string join = "" ) where T : struct
            => array.Select(t => t.ToString() ?? string.Empty)
                .Join(join);
        
        public static string Join( this IEnumerable<string> array, string join = "" )
            => string.Join(join, array);
        
        public static string Join<T>( this IEnumerable<T> array, char join ) where T : struct
            => array.Select(t => t.ToString() ?? string.Empty)
                .Join(join);
        
        public static string Join( this IEnumerable<string> array, char join )
            => string.Join(join, array);
        
        public static string JoinToString<T>( this IEnumerable<T> array, string join = "" )
            => array.JoinToString(join, t => t?.ToString() ?? string.Empty);
        
        public static string JoinToString<T>( this IEnumerable<T> array, string join, Func<T, string> cast )
            => array.Select(cast)
                .Where(str => str is {Length: >0})
                .Join(join);
        
        public static string JoinToString<T>( this IEnumerable<T> array, char join )
            => array.JoinToString(join, t => t?.ToString() ?? string.Empty);
        
        public static string JoinToString<T>( this IEnumerable<T> array, char join, Func<T, string> cast )
            => array.Select(cast)
                .Where(str => str is {Length: >0})
                .Join(join);
        
        /// <summary>
        /// Join a list of string while running a function on each string
        /// </summary>
        /// <param name="array"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string Join( this IEnumerable<string> array, Func<string, string> func )
            => array.Select(func)
                .Join();
    }
}
