using System;
using System.Collections.Generic;

namespace Dagobar.Helpers
{
    class Array
    {
        // A function that check if a variable is inside an array
        public static bool Contains(Object[] array, Object value)
        {
            bool ret = false;
            foreach (Object o in array)
            {
                if (o == value)
                {
                    ret = true;
                    break;
                }
                else if (array.GetType().GetElementType() == typeof(string) && String.Equals((string)o, (string)value)) // For strings
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        // Cast Generic Array to List
        public static List<T> ArrayToList<T>(T[] array)
        {
            List<T> list = new List<T>();
            foreach (T o in array) list.Add(o);

            return list;
        }
    }
}
