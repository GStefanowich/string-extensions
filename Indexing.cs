namespace TheElm.Literals {
    public static class Indexing {
        extension( string input ) {
            /// <summary>
            /// Find the IndexOf a <see cref="char"/> within the provided <see cref="string"/>.
            /// If the <see cref="char"/> is not present, return the length of the <see cref="string"/>
            /// </summary>
            public int IndexOfOrLen( char ch ) {
                int index = input.IndexOf(ch);
                return index is -1 ? input.Length : index;
            }
            
            /// <summary>
            /// Find the IndexOf a <see cref="char"/> within the provided <see cref="string"/>.
            /// If the <see cref="char"/> is not present, return the length of the <see cref="string"/>
            /// </summary>
            public int IndexOfOrLen( char ch, int startPos ) {
                int index = input.IndexOf(ch, startPos);
                return index is -1 ? input.Length : index;
            }
        }
    }
}
