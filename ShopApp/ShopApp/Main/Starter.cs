using System.Collections.Generic;
using System.Globalization;
using ShopApp.Helpers;
using ShopApp.Models;
using ShopApp.Services.Abstractions;

namespace ShopApp.Main
{
    public class Starter
    {
        private readonly ILoggerService _loggerService;
        public Starter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void Run()
        {
            Contact alex = new Contact("Alex", "060465808");
            Contact bethany = new Contact("Bethany", "035357383");
            Contact sophie = new Contact("Sophie", "060465808");
            Contact shop = new Contact("7 days", "893839319");
            Contact boris = new Contact("Борис", "239823023");
            Contact nikita = new Contact("Никита", "534746379");
            Contact tolik = new Contact("Анатолий", "534746379");
            Contact alina = new Contact("Алина", "3748134813");
            Contact sophia = new Contact("Соня", "348429234");
            Contact room = new Contact("24 комната", "323268923");

            MyContactDictionary contactDict = new MyContactDictionary();
            contactDict.Add(bethany);
            contactDict.Add(alex);
            contactDict.Add(sophie);
            contactDict.Add(shop);
            contactDict.Add(boris);
            contactDict.Add(nikita);
            contactDict.Add(alina);

            _loggerService.DisplayContacts(contactDict);

            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

            contactDict.InitAlphabet(CultureInfo.CurrentCulture.Name);
            contactDict.Add(sophia);
            contactDict.Add(room);
            contactDict.Add(tolik);

            // contactDict.Remove(new KeyValuePair<string, Contact>("Н", nikita));
            _loggerService.DisplayContacts(contactDict);
        }
    }
}
