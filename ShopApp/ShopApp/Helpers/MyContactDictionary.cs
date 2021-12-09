using System;
using System.Collections;
using System.Collections.Generic;
using ShopApp.Configs;
using ShopApp.Services;
using ShopApp.Models;

namespace ShopApp.Helpers
{
    public class MyContactDictionary : IEnumerable, IEnumerator
    {
        private readonly LocaleProviderConfig _localeProviderConfig;
        private readonly Config _config;
        private readonly ConfigService _configService;
        private readonly Dictionary<string, string[]> _localeDictionary;
        private List<KeyValuePair<string, Contact>> _listOfContacts;
        private string[] _alphabet;
        private int _position;

        public MyContactDictionary()
        {
            _listOfContacts = new List<KeyValuePair<string, Contact>>();
            _configService = new ConfigService();
            _config = _configService.DeserializeConfig();
            _localeProviderConfig = _config.LocaleProvider;
            _localeDictionary = _localeProviderConfig.LocaleAlphabets;
            _position = -1;
            _alphabet = _localeDictionary["en-EN"];
            Count = 0;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _listOfContacts[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public int Count { get; set; }
        object IEnumerator.Current
        {
            get { return Current; }
        }

        public KeyValuePair<string, Contact> this[int index]
        {
            get { return _listOfContacts[index]; }
            set { _listOfContacts[index] = value; }
        }

        public void InitAlphabet(string local)
        {
            _alphabet = _localeDictionary[local];
            for (var i = 0; i < _listOfContacts.Count; i++)
            {
                var flag = false;
                var decrementFlag = false;
                for (var j = 0; j < _alphabet.Length; j++)
                {
                    if ((_listOfContacts[i].Value.FullName[0].ToString() == _alphabet[j] && _listOfContacts[i].Key != _alphabet[j]) || _listOfContacts[i].Key == "0-9")
                    {
                        if (_listOfContacts[i].Key == "0-9")
                        {
                            decrementFlag = true;
                        }

                        Add(_listOfContacts[i].Value);
                        RemoveAt(i);
                        Sort();
                        flag = true;
                        break;
                    }
                    else if (_listOfContacts[i].Value.FullName[0].ToString() == _alphabet[j] && _listOfContacts[i].Key == _alphabet[j])
                    {
                        decrementFlag = true;
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    if (!decrementFlag)
                    {
                        i--;
                    }

                    continue;
                }

                _listOfContacts.Add(new KeyValuePair<string, Contact>("#", _listOfContacts[i].Value));
                _listOfContacts.RemoveAt(i);
                Sort();
            }
        }

        public void Add(Contact contact)
        {
            Count++;
            for (var i = 0; i < _alphabet.Length; i++)
            {
                if (_alphabet[i] == contact.FullName[0].ToString())
                {
                    _listOfContacts.Add(new KeyValuePair<string, Contact>(_alphabet[i], contact));
                    Sort();
                    return;
                }
            }

            var isFirstNumber = int.TryParse(contact.FullName[0].ToString(), out int number);
            if (isFirstNumber)
            {
                _listOfContacts.Add(new KeyValuePair<string, Contact>("0-9", contact));
                Sort();
                return;
            }

            _listOfContacts.Add(new KeyValuePair<string, Contact>("#", contact));
            Sort();
        }

        public void Remove(KeyValuePair<string, Contact> item)
        {
            Count--;
            _listOfContacts.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Count--;
            _listOfContacts.RemoveAt(index);
        }

        public void Sort()
        {
            _listOfContacts.Sort(new KeyValueComparer());
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _listOfContacts.Count;
        }

        public void Reset()
        {
            _position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return _listOfContacts.GetEnumerator();
        }
    }
}
