using System.Xml.Linq;

namespace dtp6_contacts
{
    class MainClass
    {
        static Person[] contactList = new Person[100];
        class Person
        {
            public string persname { get; set; }
            public string surname { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public string birthdate { get; set; }
        }

        static string Input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void PrintContactList()
        {
            for(int i = 0; i < contactList.Length; i++)
            {
                Person p = contactList[i];
                if(p != null)
                {
                    Console.WriteLine($"{p.persname}, {p.surname}, {p.phone}, {p.address}, {p.birthdate}");
                }
            }
        }

        static string[] commandLine;
        static string lastFileName;
        public static void Main(string[] args)
        {
            lastFileName = "address.lis";
            Console.WriteLine("Hello and welcome to the contact list");
            WriteHelp();
            do
            {
                commandLine = Input("> ").Split(' ');
                if (commandLine[0] == "quit")
                {
                    // NYI! safe quit
                    Console.WriteLine("Not yet implemented: safe quit");
                }
                // NYI: "list"
                else if (commandLine[0] == "list")
                {
                    PrintContactList();
                }
                else if (commandLine[0] == "load")
                {
                    if (commandLine.Length < 2)
                    {
                        lastFileName = "address.lis";
                        ReadContactListFromFile(lastFileName);
                    }
                    else
                    {
                        lastFileName = commandLine[1];
                        ReadContactListFromFile(lastFileName);
                    }
                }
                else if (commandLine[0] == "save")
                {
                    if (commandLine.Length < 2)
                    {
                        WriteContactListToFile(lastFileName);
                    }
                    else
                    {
                        // NYI! save /file/
                        Console.WriteLine("Not yet implemented: save /file/");
                        lastFileName = commandLine[1];
                        WriteContactListToFile(lastFileName);
                    }
                }
                else if (commandLine[0] == "new")
                {
                    New();
                }
                else if (commandLine[0] == "help")
                {
                    WriteHelp();
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
        private static void ReadContactListFromFile(string lastFileName) // Laddar in filen
        {
            using (StreamReader infile = new StreamReader(lastFileName)) // FIXME: om filen inte finns!
            {
                string line;
                while ((line = infile.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
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
        private static void WriteContactListToFile(string lastFileName) // Skriver till filen, trasigt
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
        private static void WriteHelp() // Hjälpkommandon
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
