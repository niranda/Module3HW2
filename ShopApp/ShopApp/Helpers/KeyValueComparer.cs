using System.Collections.Generic;
using ShopApp.Models;

namespace ShopApp.Helpers
{
    public class KeyValueComparer : IComparer<KeyValuePair<string, Contact>>
    {
        public int Compare(KeyValuePair<string, Contact> p1, KeyValuePair<string, Contact> p2)
        {
            return string.Compare(p1.Key, p2.Key);
        }
    }
}
