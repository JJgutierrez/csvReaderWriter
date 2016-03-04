using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CSVReaderWriter
{
    class ChooseOptions
    {
        private string pathFile = @"PeopleData.csv";
        private string option;
        FileReader filereader = new FileReader();
        FileWriter filewriter = new FileWriter();
        string AddNewPerson = "1";
        string SearchByName = "2";
        string SearchByPhone = "3";
        string ShowAlltheList = "4";
        string Exit = "5";

        public void Cases()
        {
            FileReader filereader = new FileReader();
            FileWriter filewriter = new FileWriter();
            OptionScreen screen = new OptionScreen();
            DataTable temPeoples = filereader.GetCsvData(pathFile);
            try {

                while (option != "6")
                {
                    screen.ScreenOptions();
                    option = Console.ReadLine();
                    Console.Clear();

                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Lastname:");
                            string lastname = Console.ReadLine();
                            Console.WriteLine("Enter Address:");
                            string address = Console.ReadLine();
                            Console.WriteLine("Enter Phone number:");
                            string phonenumber = Console.ReadLine();
                            DataRow newrow = temPeoples.NewRow();
                            newrow[0] = name;
                            newrow[1] = lastname;
                            newrow[2] = address;
                            newrow[3] = phonenumber;
                            temPeoples.Rows.Add(newrow);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            Console.WriteLine("Enter The Name of the person:");
                            string nameTofind = Console.ReadLine();
                            DataRow[] result = temPeoples.Select("NAME ='" + nameTofind + "'");
                            foreach (DataRow row in result)
                            {
                                Console.WriteLine("{0}, {1}, {2}, {3}", row[0], row[1], row[2], row[3]);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3":
                            Console.WriteLine("Enter The Phone number: ");
                            string phoneToFind = Console.ReadLine();
                            DataRow[] PhoneResult = temPeoples.Select("PhoneNumber ='" + phoneToFind + "'");
                            foreach (DataRow row in PhoneResult)
                            {
                                Console.WriteLine("{0}, {1}, {2}, {3}", row[0], row[1], row[2], row[3]);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "4":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            // filereader.ViewData(pathFile);
                            filereader.DisplayData(temPeoples);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                    filewriter.CreateCSVFile(temPeoples, pathFile);
                }
            }
            catch(DataException)
            {
                Console.WriteLine("Something went wrong ..... please try again");
                Console.ReadKey();
                Cases();
            }
        }
    }
}
