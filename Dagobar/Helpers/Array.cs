/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using System;
using System.Collections.Generic;

namespace Dagobar.Helpers
{
    public class Array
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
