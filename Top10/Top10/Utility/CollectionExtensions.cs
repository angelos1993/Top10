using System;
using System.Collections.Generic;

namespace Top10.Utility
{
    public static class CollectionExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var random = new Random();
            var listCount = list.Count;
            while (listCount > 1)
            {
                listCount--;
                var index = random.Next(listCount + 1);
                var value = list[index];
                list[index] = list[listCount];
                list[listCount] = value;
            }
        }
    }
}