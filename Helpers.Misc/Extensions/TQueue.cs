using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static TQueue EnqueueItem<T, TQueue>(this TQueue source, T item)
                where TQueue : Queue<T>
            {
                source.Enqueue(item);
                return source;
            }

        }
    }
}