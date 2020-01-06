using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;

namespace Family_Tree
{
    class UI
    {
        string input;
        Regex regexName = new Regex(@"^[a-zA-Z]{1,25}\s*$");
        Regex regexDateOfBirth = new Regex(@"^[0-9]{2}/[0-9]{2}/[0-9]{4}\s*$");
        public void PrintIntro()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*             Family Tree Creator               *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*                                 by Oatesoscar *");
            Console.WriteLine("*************************************************");
        }

        public void CreatePersonUI()
        {
            Console.Clear();
            Console.WriteLine("*************************************************");
            Console.WriteLine("*                Create Person                  *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*         [*] Redo your previous step           *");
            Console.WriteLine("*         [#] Main Menu                         *");
            Console.WriteLine("*************************************************");
        }

        public void PrintMainMenu()
        {
            Console.WriteLine("[1] Create Person");
            Console.WriteLine("[2] Edit Person");
            Console.WriteLine("[3] List People");
            Console.WriteLine("[4] List Families");
            Console.WriteLine("[5] Print Family Tree(s)");
            Console.WriteLine("[6] Do something else I guess");
            Console.WriteLine("[7] Exit App ");
        }

        public void MainMenu()
        {
            Console.Clear();
            PrintIntro();
            PrintMainMenu();
            MainMenuFunctions();
        }

        public void MainMenuFunctions()
        {
            string input;
            Console.WriteLine("Enter Number Response");
        jump0:
            input = Console.ReadLine();
            bool isInt = Int32.TryParse(input, out int result);
            if (isInt)
            {
                switch (result)
                {
                    case 1:
                        CreatePersonUI();
                        CreatePerson();
                        Console.WriteLine("\nOperation Complete\n");
                        AskMainMenu();
                        break;
                    case 2:
                        Console.WriteLine("Set It Up");
                        Console.WriteLine("Going back to main menu");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("Set It Up");
                        Console.WriteLine("Going back to main menu");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        MainMenu();

                        break;
                    case 4:
                        Console.WriteLine("Set It Up");
                        Console.WriteLine("Going back to main menu");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        MainMenu();

                        break;
                    case 5:
                        Console.WriteLine("Set It Up");
                        Console.WriteLine("Going back to main menu");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        MainMenu();

                        break;
                    case 6:
                        Console.WriteLine("Set It Up");
                        Console.WriteLine("Going back to main menu");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        MainMenu();

                        break;
                    case 7:
                        Environment.ExitCode = -1;
                        break;
                    default:
                        Console.WriteLine("Please Select A Menu Action");
                        break;
                }               
            }
            else
            {
                Console.WriteLine("Please Select A Menu Action");
                goto jump0;
            }
        }

        private void CreatePerson()
        {
            Person person = new Person();

            GetFirstName(person);
            GetMiddleName(person);
            GetLastName(person);
            GetDateOfBirth(person);
            GetCityOfBirth(person);
            GetCountryOfBirth(person);
            CheckIsAlive(person);
            CheckIsAFamilyMember(person);
            CheckHasParents(person);
            CheckHasSiblings(person);
            CheckHasChildren(person);
            CheckHasAFamilyOfOwn(person);
            Console.WriteLine($"{person.LastName} {person.FirstName} was created");
            CheckToSavePerson(person);
            Console.WriteLine("Going back to Main Menu");

        }

        private void CheckToSavePerson(Person person)
        {
            Console.WriteLine($"Do you want to save {person.LastName} {person.FirstName} Yes:1 , No:2");
        jump13:
            input = Console.ReadLine();
            bool isInt9 = Int32.TryParse(input, out int result9);
            if (isInt9)
            {
                switch (result9)
                {
                    case 1:
                        SavePerson(person);
                        Console.WriteLine($"{person.LastName} {person.FirstName} was saved");
                        break;
                    case 2:
                        Console.WriteLine($"{person.LastName} {person.FirstName} was Deleted(DUMMY TEXT)");
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2");
                        break;
                }
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump13;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto jump13;
            }
        }

        public void SavePerson(Person person)
        {
            string path = @"..\Files\People.json";
            List<Person> people = new List<Person>();
            if (File.Exists(path))
            {
                string peopleString = File.ReadAllText(path).ToString();
                try
                {
                    people = JsonConvert.DeserializeObject<List<Person>>(peopleString);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("I had a problem with the People.json file");
                }

                people.Add(person);

                try
                {
                    string newPeopleString = JsonConvert.SerializeObject(people, Formatting.Indented);
                    File.WriteAllText(path, newPeopleString);
                }
                catch (Exception)
                {
                    Console.WriteLine("I had a problem with the People.json file");
                }
            }
            else
            {
                Console.WriteLine("The File People.json Doesnt exist Fix it");
                Console.WriteLine("Going back to main menu");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

        }

        private void CheckHasAFamilyOfOwn(Person person)
        {
            Console.WriteLine($"Does {person.FirstName} have a Family?  Yes:1 , No:2");
        jump12:
            input = Console.ReadLine();
            bool isInt8 = Int32.TryParse(input, out int result8);
            if (isInt8)
            {
                switch (result8)
                {
                    case 1:
                        person.HasFamily = true;
                        break;
                    case 2:
                        person.HasFamily = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2");
                        break;
                }
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump12;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto jump12;
            }
        }

        private void CheckHasChildren(Person person)
        {
            Console.WriteLine($"Does {person.FirstName} have Children?  Yes:1 , No:2");
        jump11:
            input = Console.ReadLine();
            bool isInt7 = Int32.TryParse(input, out int result7);
            if (isInt7)
            {
                switch (result7)
                {
                    case 1:
                        person.HasChildren = true;
                        break;
                    case 2:
                        person.HasChildren = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2");
                        break;
                }
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump11;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto jump11;
            }

        }

        private void CheckHasSiblings(Person person)
        {
            Console.WriteLine($"Does {person.FirstName} have Siblings?  Yes:1 , No:2");
        jump10:
            input = Console.ReadLine();
            bool isInt6 = Int32.TryParse(input, out int result6);
            if (isInt6)
            {
                switch (result6)
                {
                    case 1:
                        person.HasSiblings = true;
                        break;
                    case 2:
                        person.HasSiblings = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2");
                        break;
                }
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump10;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto jump10;
            }

        }

        private void CheckIsAFamilyMember(Person person)
        {
            Console.WriteLine($"Is {person.FirstName} a member of a family?  Yes:1 , No:2");
        jump8:
            input = Console.ReadLine();
            bool isInt3 = Int32.TryParse(input, out int result3);
            if (isInt3)
            {
                switch (result3)
                {
                    case 1:
                        person.IsAFamilyMember = true;
                        Console.WriteLine($"Do you want to use '{person.LastName}' As Family Name?  Yes:1 , No:2");
                        input = Console.ReadLine();
                        bool isInt4 = Int32.TryParse(input, out int result4);
                        if (isInt4)
                        {
                            switch (result4)
                            {
                                case 1:
                                    person.FamilyName = person.LastName;
                                    break;
                                case 2:
                                    Console.WriteLine("Enter Family Name");
                                jump15:
                                    input = Console.ReadLine();
                                    if (regexName.IsMatch(input))
                                    {
                                        person.FamilyName = input;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a family name please");
                                        goto jump15;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Please enter 1 or 2");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        person.IsAFamilyMember = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2");
                        break;
                }
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump8;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto jump8;
            }
        }

        private void CheckHasParents(Person person)
        {
            Console.WriteLine($"Does {person.FirstName} have Parents?  Yes:1 , No:2");
        jump9:
            input = Console.ReadLine();
            bool isInt5 = Int32.TryParse(input, out int result5);
            if (isInt5)
            {
                switch (result5)
                {
                    case 1:
                        person.HasParents = true;
                        Console.WriteLine("Enter Dad's First Name. Leave empty if Unknown");
                        person.DadFirstName = Console.ReadLine();
                        Console.WriteLine("Enter Dad's Last Name. Leave empty if Unknown");
                        person.DadLastName = Console.ReadLine();
                        Console.WriteLine("Enter Mum's First Name. Leave empty if Unknown");
                        person.MumFirstName = Console.ReadLine();
                        Console.WriteLine("Enter Mum's Last Name. Leave empty if Unknown");
                        person.MumLastName = Console.ReadLine();
                        break;
                    case 2:
                        person.HasParents = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2");
                        break;
                }
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump9;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto jump9;
            }
        }

        private void CheckIsAlive(Person person)
        {
            Console.WriteLine($"Is {person.FirstName} alive?  Yes:1 , No:2");
        jump7:
            input = Console.ReadLine();
            bool isInt2 = Int32.TryParse(input, out int result2);
            if (isInt2)
            {
                switch (result2)
                {
                    case 1:
                        person.IsAlive = true;
                        break;
                    case 2:
                        person.IsAlive = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2");
                        break;
                }
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump7;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto jump7;
            }

        }

        private void GetCountryOfBirth(Person person)
        {
            Console.WriteLine("Enter Country of Birth");
        jump6:
            input = Console.ReadLine();
            if (regexName.IsMatch(input))
            {
                person.BirthCountry = input;
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump6;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Enter a Coutry please");
                goto jump6;
            }
        }

        private void GetCityOfBirth(Person person)
        {
            Console.WriteLine("Enter City of Birth");
        jump5:
            input = Console.ReadLine();
            if (regexName.IsMatch(input))
            {
                person.BirthCity = input;
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump5;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Enter a city please");
                goto jump5;
            }
        }

        private void GetDateOfBirth(Person person)
        {

            Console.WriteLine("Enter Date Of Birth 'mm/dd/yyy'");
        jump4:
            input = Console.ReadLine();
            if (regexDateOfBirth.IsMatch(input))
            {
                person.DateOfBirth = input;
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump4;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please enter Date of Birth in The Format 'Month/Day/Year'");
                goto jump4;
            }
        }

        private void GetLastName(Person person)
        {
            Console.WriteLine("Enter Last Name");
        jump3:
            input = Console.ReadLine();
            if (regexName.IsMatch(input))
            {
                person.LastName = input;
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump3;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Enter a name without any special character nor space");
                goto jump3;
            }
        }

        private void GetMiddleName(Person person)
        {
            Console.WriteLine("Enter Middle Name or Leave Blank for No Middle Name");
        jump2:
            input = Console.ReadLine();
            if (regexName.IsMatch(input) || input == string.Empty)
            {
                person.MiddleName = input;
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump2;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Please Enter a middle name or leave it blank");
                goto jump2;
            }
        }

        private void GetFirstName(Person person)
        {
            Console.WriteLine("Enter First Name");
        jump1:
            input = Console.ReadLine();
            if (regexName.IsMatch(input))
            {
                person.FirstName = input;
            }
            else if (input == "*")
            {
                Console.WriteLine("Redoing current step");
                goto jump1;
            }
            else if (input == "#")
            {
                AskMainMenu();
            }
            else
            {
                Console.WriteLine("Enter a name without any special character nor space");
                goto jump1;
            }
        }

        private void AskMainMenu()
        {
            string input;
            int result;
            Console.WriteLine("Do you want to go back to the main menu?");
            Console.WriteLine("[1]Yes [2]No ");
            input = Console.ReadLine();
            bool isInt = Int32.TryParse(input, out result);
            if (isInt)
            {
                switch (result)
                {
                    case 1:
                        MainMenu();
                        break;
                    case 2:
                        Console.WriteLine("(Needs Set UP)");
                        break;
                    default:
                        Console.WriteLine("Enter 1 or 2");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter 1 or 2 ");
            }
        }

    }
}
