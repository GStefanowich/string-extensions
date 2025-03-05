namespace TheElm.Literals {
    public static class Indexing {
        /// <summary>
        /// Find the IndexOf a <see cref="char"/> within the provided <see cref="string"/>.
        /// If the <see cref="char"/> is not present, return the length of the <see cref="string"/>
        /// </summary>
        public static int IndexOfOrLen( this string input, char ch ) {
            int index = input.IndexOf(ch);
            return index is -1 ? input.Length : index;
        }
        
        /// <summary>
        /// Find the IndexOf a <see cref="char"/> within the provided <see cref="string"/>.
        /// If the <see cref="char"/> is not present, return the length of the <see cref="string"/>
        /// </summary>
        public static int IndexOfOrLen( this string input, char ch, int startPos ) {
            int index = input.IndexOf(ch, startPos);
            return index is -1 ? input.Length : index;
        }
    }
}
