using System;
using System.Collections.Generic;
using System.Linq;

// Создайте коллекцию, в которую можно записывать два значения одного слова, по типу русскоангло-украинский словарь. И в ней можно для украинского слова найти либо только русское
// значение, либо только английское и вывести его на экран.

namespace Collection_with_two_means_of_one_word
{
    class Program
    {
        private static Dictionary<int, string> russian_words = new Dictionary<int, string>();

        private static Dictionary<int, string> ukrainian_1rst_mean = new Dictionary<int, string>();

        private static Dictionary<int, string> ukrainian_2nd_mean = new Dictionary<int, string>();

        private static Dictionary<int, string> english_words = new Dictionary<int, string>();

        private static void InitializeDictionary()
        {
            russian_words.Add(0, "Апельсин");
            russian_words.Add(1, "Вертолет");
            russian_words.Add(2, "Лопнул");
            russian_words.Add(3, "Глупый");
            russian_words.Add(4, "Картина");

            ukrainian_1rst_mean.Add(0, "Апельсин");
            ukrainian_1rst_mean.Add(1, "Вертоліт");
            ukrainian_1rst_mean.Add(2, "Зламаний");
            ukrainian_1rst_mean.Add(3, "Тупий");
            ukrainian_1rst_mean.Add(4, "Картина");

            ukrainian_2nd_mean.Add(0, "Оранж");
            ukrainian_2nd_mean.Add(1, "Гвинтокрил");
            ukrainian_2nd_mean.Add(2, "Розорений");
            ukrainian_2nd_mean.Add(3, "Тугий");
            ukrainian_2nd_mean.Add(4, "Розмальовка");

            english_words.Add(0, "Orange");
            english_words.Add(1, "Gelicopter");
            english_words.Add(2, "Busted");
            english_words.Add(3, "Stupid");
            english_words.Add(4, "Picture");
        }        

        private static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("Доступны следующие команды:");
            Console.WriteLine("\"D\" - для просмотра существующих слов в словаре;");
            Console.WriteLine("\"U-R\" - для использования украинско-росийского словаря;");
            Console.WriteLine("\"U-E\" - для использования украинско-английского словаря;");
            Console.WriteLine("\"Add\" - для добавления русского слова и его перевода на украинский;");
            Console.WriteLine("\"Exit\" или \"Close\" - для выхода из программы;");
            Console.WriteLine("\"?\" - для повторного отображения возможных команд.");
            Console.WriteLine();
            Console.WriteLine("Вы в главном меню.");
            Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
        }

        private static void Add()
        {
            Console.WriteLine("Вы в режиме добавления слов, для возвращения в меню напишите \"Menu\".");
            Console.WriteLine();

            string Rus_word = "";
            string Ukr_word = "";
            string Ukr_2word = "";
            string Eng_word = "";

            while (Rus_word != "Menu" & Ukr_word != "Menu" & Ukr_2word != "Menu" & Eng_word != "Menu")
            {
                int Key = english_words.Count;

                Console.WriteLine("Создание новых слов под номером: {0}", Key.ToString());
                Console.WriteLine();

                Console.WriteLine("Напишите русское слово:");
                Rus_word = Console.ReadLine();
                if (Rus_word == "Menu")
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы в главном меню.");
                    Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
                    break;
                }
                russian_words.Add(Key, Rus_word);

                Console.WriteLine("Напишите перевод на украинский язык:");
                Ukr_word = Console.ReadLine();
                if (Ukr_word == "Menu")
                {
                    Console.WriteLine("Русское слово под №{0} - удаленно;", Key.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Вы в главном меню.");
                    Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
                    russian_words.Remove(Key);
                    break; 
                } 
                ukrainian_1rst_mean.Add(Key, Ukr_word);

                Console.WriteLine("Напишите второй перевод на украинский язык:");
                Ukr_word = Console.ReadLine();
                if (Ukr_2word == "Menu")
                {
                    Console.WriteLine("Русское и украинское слово под №{0} - удаленно;", Key.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Вы в главном меню.");
                    Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
                    russian_words.Remove(Key);
                    ukrainian_1rst_mean.Remove(Key);
                    break;
                }
                ukrainian_2nd_mean.Add(Key, Ukr_word);

                Console.WriteLine("Напишите перевод на английский язык:");
                Eng_word = Console.ReadLine();
                if (Eng_word == "Menu")
                {
                    Console.WriteLine("Все добавленные слова под №{0} - удаленны;", Key.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Вы в главном меню.");
                    Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
                    russian_words.Remove(Key);
                    ukrainian_1rst_mean.Remove(Key);
                    ukrainian_2nd_mean.Remove(Key);
                    break;
                }
                english_words.Add(Key, Eng_word);

                Console.WriteLine("Данные слова сохранились в словаре под № {0}", Key);
            }
        }

        private static void Show()
        {
            Console.WriteLine("На данный моммент доступны следующие слова:");
            Console.WriteLine("English - Russian - Ukrainian_1 - Ukrainian_2");

            for (int i = 0; i < english_words.Count; i++)
            {
                Console.WriteLine("{0} - {1} - {2}, {3}", english_words[i], russian_words[i], ukrainian_1rst_mean[i], ukrainian_2nd_mean[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Вы в главном меню.");
            Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
        }

        private static void Ua_Rus_Translate()
        {
            Console.WriteLine("Для возвращения в меню, напишите: \"Menu\".");
            string Ukr_Dictionary_Value = "";

            while (Ukr_Dictionary_Value != "Menu")
            {
                Console.WriteLine();
                Console.WriteLine("Напишите украинское слово, которое хотите перевести на русский:");
                Ukr_Dictionary_Value = Console.ReadLine();

                if (ukrainian_1rst_mean.ContainsValue(Ukr_Dictionary_Value))
                {
                    int ukrainian_1rst_mean_key = ukrainian_1rst_mean.FirstOrDefault(x => x.Value == Ukr_Dictionary_Value).Key;

                    string rus_value;
                    russian_words.TryGetValue(ukrainian_1rst_mean_key, out rus_value);
                    Console.WriteLine(rus_value);
                    continue;
                }

                else if (ukrainian_2nd_mean.ContainsValue(Ukr_Dictionary_Value))
                {
                    int ukrainian_2nd_mean_key = ukrainian_2nd_mean.FirstOrDefault(x => x.Value == Ukr_Dictionary_Value).Key;

                    string rus_value;
                    russian_words.TryGetValue(ukrainian_2nd_mean_key, out rus_value);
                    Console.WriteLine(rus_value);
                    continue;
                }

                else
                {
                    if (Ukr_Dictionary_Value == "Menu")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы в главном меню.");
                        Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
                        break;
                    }
                    Console.WriteLine("{0} - нет в словаре.", Ukr_Dictionary_Value);
                    continue;
                }
            }
        }

        private static void Ua_Eng_Translate()
        {          
            Console.WriteLine("Для возвращения в меню, напишите: \"Menu\".");
            string Ukr_Dictionary_Value1 = "";

            while (Ukr_Dictionary_Value1 != "Menu")
            {
                Console.WriteLine();
                Console.WriteLine("Напишите украинское слово, которое хотите перевести на английский:");
               
                Ukr_Dictionary_Value1 = Console.ReadLine();

                if (ukrainian_1rst_mean.ContainsValue(Ukr_Dictionary_Value1))
                {
                    int ukrainian_1rst_mean_key = ukrainian_1rst_mean.FirstOrDefault(x => x.Value == Ukr_Dictionary_Value1).Key;

                    if (english_words.ContainsKey(ukrainian_1rst_mean_key))
                    {
                        string eng_value;
                        english_words.TryGetValue(ukrainian_1rst_mean_key, out eng_value);
                        Console.WriteLine(eng_value);
                        continue;
                    }
                    else Console.WriteLine();
                    Console.WriteLine("Для данного слова нет перевода на английский.");
                    continue;
                }

                else if (ukrainian_2nd_mean.ContainsValue(Ukr_Dictionary_Value1))
                {
                    int ukrainian_2nd_mean_key = ukrainian_2nd_mean.FirstOrDefault(x => x.Value == Ukr_Dictionary_Value1).Key;

                    if (english_words.ContainsKey(ukrainian_2nd_mean_key))
                    {
                        string eng_value;
                        english_words.TryGetValue(ukrainian_2nd_mean_key, out eng_value);
                        Console.WriteLine(eng_value);
                        continue;
                    }
                    else Console.WriteLine();
                    Console.WriteLine("Для данного слова нет перевода на английский.");
                    continue;
                }

                else
                {
                    if (Ukr_Dictionary_Value1 == "Menu")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы в главном меню.");
                        Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
                        break;
                    }
                    Console.WriteLine("{0} - нет в словаре.", Ukr_Dictionary_Value1);
                    continue;
                }
            }
        }

        private static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
            string choice;

            while ((choice = Console.ReadLine()) != "Close" & choice != "Exit")
            {
                if (choice == "")
                {
                    Console.WriteLine("Сделайте выбор прежде, чем нажать \"Enter\" !");
                    continue;
                }
                else if (choice != "D" & choice != "U-R" & choice != "U-E" & choice != "Add" & choice != "Exit" & choice != "Close" & choice != "?")
                {
                    Console.WriteLine("Ошибка: Введенная команда не существует! ");
                    continue;
                }

                switch (choice)
                {
                    case "D":
                        {
                            Show();
                            continue;
                        }
                    case "Add":
                        {
                            Add();
                            continue;
                        }                  

                    case "U-R":
                        {
                            Ua_Rus_Translate();
                            continue;
                        }

                    case "U-E":
                        {
                            Ua_Eng_Translate();
                            continue;
                        }

                    case "Exit":
                        {
                            Console.WriteLine("Выход из программы совершен, нажмите любую клавишу...");
                            break;
                        }

                    case "Close":
                        {
                            Console.WriteLine("Выход из программы совершен, нажмите любую клавишу...");
                            break;
                        }

                    case "?":
                        {
                            Help();                          
                            continue;
                        }
                }
            }
        }

        static void Main()
        {
            InitializeDictionary();
            Console.WriteLine("Амбициозный проект укро-руско-английский словарь \"Незнайка\".");
            Console.WriteLine("Сам добавляй слова, в базе их очень мало.");
            MainMenu();
        }
    }
}
