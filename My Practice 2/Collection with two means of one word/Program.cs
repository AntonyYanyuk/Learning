using System;
using System.Collections.Generic;
using System.Linq;

// Создайте коллекцию, в которую можно записывать два значения одного слова, по типу русскоангло-украинский словарь. И в ней можно для украинского слова найти либо только русское
// значение, либо только английское и вывести его на экран.

namespace Collection_with_two_means_of_one_word
{
    class Program
    {
        static Dictionary<int, string> russian_words = new Dictionary<int, string>();

        static Dictionary<int, string> ukrainian_1rst_mean = new Dictionary<int, string>();

        static Dictionary<int, string> ukrainian_2nd_mean = new Dictionary<int, string>();

        static Dictionary<int, string> english_words = new Dictionary<int, string>();

        static void Main()
        {          

            #region Standart Dictionary
                  
            russian_words.Add(0, "Апельсин");
            russian_words.Add(1, "Вертолет");
            russian_words.Add(2, "Потрачено");
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
            #endregion Dictionary

            Console.WriteLine("Амбициозный проект укро-руско-английский словарь \"незнайка\".");
            Console.WriteLine("Сам добавляй слова, в базе их очень мало.");

            Reference:
            Console.WriteLine();
            Console.WriteLine("Доступны следующие команды:");
            Console.WriteLine("\"D\" - для просмотра существующих слов в словаре;");
            Console.WriteLine("\"U-R\" - для использования украинско-росийского словаря.");
            Console.WriteLine("\"U-E\" - для использования украинско-английского словаря.");
            Console.WriteLine("\"Add\" - для добавления русского слова и его перевода на украинский;");
            Console.WriteLine("\"Addition\" - для добавления второго значения для украинского слова. ");
            Console.WriteLine("\"Exit\" или \"Close\" - для выхода из программы.");
            Console.WriteLine("\"?\" - для повторного отображения возможных команд.. ");

        #region Choice(switch-case)
        Choice:
            Console.WriteLine();
            Console.WriteLine("Сделайте ваш выбор, для справки введите: \"?\".");
            string choice = Console.ReadLine();

            if (choice == "")
            {
                Console.WriteLine("Сделайте выбор прежде, чем нажать \"Enter\" !");
                goto Choice;
            }

            else if (choice != "D" & choice != "U-R" & choice != "U-E" & choice != "Add" & choice != "Addition" & choice != "Exit" & choice != "Close" & choice != "?")
            {
                Console.WriteLine("Ошибка: введенная команда не существует! ");
                goto Choice;
            }
            
            switch (choice)
            {
                case "D":
                    {
                        Console.WriteLine("На данный моммент доступны следующие слова:");
                        Console.WriteLine("English - Russian - Ukrainian_1 - Ukrainian_2");

                        for (int i = 0; i < english_words.Count; i++)
                        {
                            Console.WriteLine("{0} - {1} - {2}, {3}", english_words[i], russian_words[i], ukrainian_1rst_mean[i], ukrainian_2nd_mean[i]);
                        }

                        goto Choice;
                    }
                case "Add":
                    {
                        Console.WriteLine("Вы в режиме добавления слов, для возвращения в меню напишите \"Menu\"." );
                        Console.WriteLine();

                        string Rus_word = "";
                        string Ukr_word = "";
                        string Eng_word = "";

                        while (Rus_word != "Menu" & Ukr_word != "Menu" & Eng_word != "Menu")
                        {
                            int Key = english_words.Count;                    

                            Console.WriteLine("Создание новых слов под номером: {0}", Key.ToString());
                            Console.WriteLine();

                            Console.WriteLine("Напишите русское слово:");
                            Rus_word = Console.ReadLine();
                            if (Rus_word == "Menu") goto Choice; 
                            russian_words.Add(Key,Rus_word);

                            Console.WriteLine("Напишите перевод на украинский язык:");
                            Ukr_word = Console.ReadLine();
                            if (Ukr_word == "Menu") goto Choice;
                            ukrainian_1rst_mean.Add(Key, Ukr_word);

                            Console.WriteLine("Напишите перевод на английский язык:");
                            Eng_word = Console.ReadLine();
                            if (Eng_word == "Menu") goto Choice;
                            english_words.Add(Key, Eng_word);

                            Console.WriteLine("Данные слова сохранились в словаре под № {0}", Key);
                        }
                        goto Choice;
                    }
                case "Addition":
                    {
                        Console.WriteLine("Укажите номер украинского слова, для которого будет записано второе значение:");
                        string string_key = Console.ReadLine();
                        int key = Convert.ToInt32(string_key);

                        string ukr_value;
                        ukrainian_1rst_mean.TryGetValue(key, out ukr_value);
                                          
                        if (ukrainian_1rst_mean.ContainsKey(key))
                        {
                            goto Step;
                        }
                        else
                        {
                            Console.WriteLine("Нет слова под данным номером!");
                            goto Choice;
                        }

                        Step:
                        Console.WriteLine("Напишите перевод на украинский для слова \"{0}\":", ukr_value);
                      
                            string Ukr_word_2 = Console.ReadLine();
                        ukrainian_2nd_mean.Add(key, Ukr_word_2);
                        goto Choice;
                    }

                case "U-R":
                    {
                        Console.WriteLine("Для возвращения в меню напишите \"Menu\".");
                        string Ukr_Dictionary_Value = "";

                        while (Ukr_Dictionary_Value != "Menu")
                          {
                            Console.WriteLine("Напишите украинское слово которое хотите перевести на русский:");
                            Ukr_Dictionary_Value = Console.ReadLine();

                            if (ukrainian_1rst_mean.ContainsValue(Ukr_Dictionary_Value))
                            {
                                int ukrainian_1rst_mean_key = ukrainian_1rst_mean.FirstOrDefault(x => x.Value == Ukr_Dictionary_Value).Key;


                                string rus_value;
                                russian_words.TryGetValue(ukrainian_1rst_mean_key, out rus_value);
                                Console.WriteLine(rus_value);
                                Ukr_Dictionary_Value = Console.ReadLine();
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
                                    goto Choice;
                                }
                                Console.WriteLine("{0} - нет в словаре.", Ukr_Dictionary_Value);
                                continue;
                              }
                          }
                        goto Choice;
                    }

                case "U-E":
                    {
                        Console.WriteLine("Напишите украинское слово которое хотите перевести на английский:");
                        string Ukr_Dictionary_Value1 = Console.ReadLine();

                        if (ukrainian_1rst_mean.ContainsValue(Ukr_Dictionary_Value1))
                        {
                            int ukrainian_1rst_mean_key = ukrainian_1rst_mean.FirstOrDefault(x => x.Value == Ukr_Dictionary_Value1).Key;

                            if (english_words.ContainsKey(ukrainian_1rst_mean_key))
                            {
                                string eng_value;
                                english_words.TryGetValue(ukrainian_1rst_mean_key, out eng_value);
                                Console.WriteLine(eng_value);
                                goto Choice;
                            }
                            else Console.WriteLine();
                            Console.WriteLine("Для данного слова нет перевода на английский.");
                            goto Choice;
                        }

                        else if (ukrainian_2nd_mean.ContainsValue(Ukr_Dictionary_Value1))
                        {
                            int ukrainian_2nd_mean_key = ukrainian_2nd_mean.FirstOrDefault(x => x.Value == Ukr_Dictionary_Value1).Key;
                            
                            if (english_words.ContainsKey(ukrainian_2nd_mean_key))
                            {
                                string eng_value;
                                english_words.TryGetValue(ukrainian_2nd_mean_key, out eng_value);
                                Console.WriteLine(eng_value);
                                goto Choice;
                            }
                            else Console.WriteLine();
                            Console.WriteLine("Для данного слова нет перевода на английский.");
                            goto Choice;
                        }

                        else
                        {
                            Console.WriteLine("{0} - нет в словаре.", Ukr_Dictionary_Value1);
                            goto Choice;
                        }
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
                        goto Reference;
                    }
            }
            
            #endregion Choice
        }
    }
}
