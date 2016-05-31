using System;

namespace PhoneBookNamespace
{
    class Program
    {
        private static void PrintMenu()
        {
            Console.WriteLine("	0 - to Exit");
            Console.WriteLine("	1 - to add telephone record(name and number of the telephone)");
            Console.WriteLine("	2 - to search phone number using name");
            Console.WriteLine("	3 - to search name using telephone number");
            Console.WriteLine("	4 - to print data base to console");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Enter one of these commands, please:");
            var command = "5";
            var phoneBook = new PhoneBook();
            PrintMenu();
            while (command != "0")
            {
                Console.Write(" your command: ");
                command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        {
                            break;
                        }

                    case "1":
                        {
                            Console.WriteLine("	-Enter  name,   please:  ");
                            string name = Console.ReadLine();
                            Console.WriteLine("	-Enter   phone  number, please:  ");
                            string number = Console.ReadLine();
                            phoneBook.Add(new Record { Name = name, Number = number });
                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("	-Enter  name,   please:  ");
                            string name = Console.ReadLine();
                            phoneBook.FindByName(name);
                            break;
                        }

                    case "3":
                        {
                            Console.Write("	-Enter   phone  number, please:  ");
                            string number = Console.ReadLine();
                            phoneBook.FindByNumber(number);
                            break;
                        }

                    case "4":
                        {
                            phoneBook.Print();
                            break;
                        }

                    case "5":
                        {
                            PrintMenu();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("incorrect command, press 5 to print a menu");
                            break;
                        }
                }

                
            }
        }
    }
}

            
