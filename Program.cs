using System.Xml.Linq;

namespace dtp6_contacts
{
    class MainClass
    {
        static Person[] contactList = new Person[100];
        class Person
        {
            public string persname, surname, phone, address, birthdate;
        }

        static string Input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static string[] commandLine;
        static string lastFileName;
        public static void Main(string[] args)
        {
            lastFileName = "address.lis";
            Console.WriteLine("Hello and welcome to the contact list");
            Help();
            do
            {
                commandLine = Input("> ").Split(' ');
                if (commandLine[0] == "quit")
                {
                    // NYI! safe quit
                    Console.WriteLine("Not yet implemented: safe quit");
                }
                // NYI: "list"
                else if (commandLine[0] == "load")
                {
                    Load();
                }
                else if (commandLine[0] == "save")
                {
                    Save();
                }
                else if (commandLine[0] == "new")
                {
                    New();
                }
                else if (commandLine[0] == "help")
                {
                    Help();
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{commandLine[0]}'");
                }
            } while (commandLine[0] != "quit");
        }
        private static void New() // Lägger till ny person
        {
            if (commandLine.Length < 2)
            {
                string persname = Input("personal name: ");
                string surname = Input("surname: ");
                string phone = Input("phone: ");
                // NYI: Create person here, and insert in phone list
            }
            else
            {
                // NYI! new /person/
                Console.WriteLine("Not yet implemented: new /person/");
            }
        }
        private static void Load() // Laddar in filen
        {
            if (commandLine.Length < 2)
            {
                lastFileName = "address.lis";
                using (StreamReader infile = new StreamReader(lastFileName))
                {
                    string line;
                    while ((line = infile.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] attrs = line.Split('|');
                        Person p = new Person();
                        p.persname = attrs[0];
                        p.surname = attrs[1];
                        string[] phones = attrs[2].Split(';');
                        p.phone = phones[0];
                        string[] addresses = attrs[3].Split(';');
                        p.address = addresses[0];
                        for (int ix = 0; ix < contactList.Length; ix++)
                        {
                            if (contactList[ix] == null)
                            {
                                contactList[ix] = p;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                lastFileName = commandLine[1];
                using (StreamReader infile = new StreamReader(lastFileName))
                {
                    string line;
                    while ((line = infile.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] attrs = line.Split('|');
                        Person p = new Person();
                        p.persname = attrs[0];
                        p.surname = attrs[1];
                        string[] phones = attrs[2].Split(';');
                        p.phone = phones[0];
                        string[] addresses = attrs[3].Split(';');
                        p.address = addresses[0];
                        for (int ix = 0; ix < contactList.Length; ix++)
                        {
                            if (contactList[ix] == null)
                            {
                                contactList[ix] = p;
                                break;
                            }
                        }
                    }
                }
            }
        }
        private static void Save() // Sparar filen, dock trasig just nu, förstör filen
        {
            if (commandLine.Length < 2)
            {
                using (StreamWriter outfile = new StreamWriter(lastFileName))
                {
                    foreach (Person p in contactList)
                    {
                        if (p != null)
                            outfile.WriteLine($"{p.persname};{p.surname};{p.phone};{p.address};{p.birthdate}");
                    }
                }
            }
            else
            {
                // NYI! save /file/
                Console.WriteLine("Not yet implemented: save /file/");
            }
        }
        private static void Help() // Hjälpkommandon
        {
            Console.WriteLine("Avaliable commands: ");
            Console.WriteLine("  delete       - emtpy the contact list");
            Console.WriteLine("  delete /persname/ /surname/ - delete a person");
            Console.WriteLine("  load        - load contact list data from the file address.lis");
            Console.WriteLine("  load /file/ - load contact list data from the file");
            Console.WriteLine("  new        - create new person");
            Console.WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
            Console.WriteLine("  quit        - quit the program");
            Console.WriteLine("  save         - save contact list data to the file previously loaded");
            Console.WriteLine("  save /file/ - save contact list data to the file");
            Console.WriteLine();
        }
    }
}
