using System;
using System.Collections.Generic;
using ShopApp.Models;
using ShopApp.Helpers;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class LoggerService : ILoggerService
    {
        public void DisplayContacts(MyContactDictionary contactDictionary)
        {
            Console.WriteLine("__________________");
            var newKey = string.Empty;

            foreach (KeyValuePair<string, Contact> i in contactDictionary)
            {
                if (newKey != i.Key)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"  {i.Value.FullName} {i.Value.PhoneNumber}");
                    continue;
                }

                newKey = i.Key;
                Console.WriteLine($"{i.Key}");
                Console.WriteLine($"  {i.Value.FullName} {i.Value.PhoneNumber}");
            }

            Console.WriteLine("__________________");
        }
    }
}
