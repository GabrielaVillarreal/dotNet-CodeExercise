using ApManageStudents.CN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApManageStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------Manage Students-----------");
            OptionList();
        }
        public static void OptionList()
        {
            string option = "0";
            int vCriteria = 0;
            string valor, vtypeStudent, vName, vGender = string.Empty;
            string confirmationDelete = string.Empty;
            string valorModify = string.Empty;
            ManagerStudent managerStudent = new ManagerStudent();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug", "");
            //string[] lines = File.ReadAllLines(path + @"/Files/studentSolution.csv");
            Console.Clear();
            do
            {
                string[] lines = File.ReadAllLines(path + @"/Files/studentSolution.csv");
                Console.WriteLine("WELCOME MENU OPTIONS : \n\n Please select the opcion you want: \n" +
                        "\n1.- Register Student" +
                        "\n2.- Search Student" +
                        "\n3.- Delete Student" +
                        "\n4.- Modify Student" +
                        "\n5.- Show Student Information" +
                        "\n0.- Salir\n");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Introduce the dates for register the student");
                        Console.WriteLine("Introduce the Type Student");
                        vtypeStudent = Console.ReadLine();
                        Console.WriteLine("Introduce the Name");
                        vName = Console.ReadLine();
                        Console.WriteLine("Introduce the Gender F Female or M Male");
                        vGender = Console.ReadLine();
                     
                        managerStudent.RegisterStudent(lines, vtypeStudent,  vName, vGender);
                        break;
                    case "2":
                        Console.WriteLine("Choose a search criteria: \n" +
                      "\n1.- By ID" +
                      "\n2.- By Type Student" +
                      "\n3.- By Name" +
                      "\n4.- By Gender" +
                      "\n5.- Salir\n");
                        vCriteria = Convert.ToInt16(Console.ReadLine());
                        switch (vCriteria)
                        {
                            case 1: // by ID
                                Console.WriteLine("Introduce the ID Student");
                                ShowStudents(managerStudent.SearchStudent(lines,vCriteria, Console.ReadLine()));
                                break;
                            case 2: // by type student
                                Console.WriteLine("Introduce the Type Student");
                                ShowStudents(managerStudent.SearchStudent(lines, vCriteria, Console.ReadLine()));
                                break;
                            case 3: // by name                                                               
                                Console.WriteLine("Introduce the name for search");
                                ShowStudents(managerStudent.SearchStudent(lines, vCriteria, Console.ReadLine()));
                                break;

                            case 4: // by gender
                                Console.WriteLine("Introduce the Gender F for Female and M for Male");
                                ShowStudents(managerStudent.SearchStudent(lines, vCriteria, Console.ReadLine()));
                                break;
                            case 5:
                                Console.WriteLine("Go to back");
                                OptionList();
                                break;
                            default:
                                Console.WriteLine("Please select a valid option");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case "3":
                        ShowStudents(lines);
                        Console.WriteLine("Introduce the ID Student you want delete");
                        valor = Console.ReadLine();
                        Console.WriteLine("Are you shure do you want to delete the student introduce  Y to yesor N to not?");
                        confirmationDelete = Console.ReadLine();
                        if (confirmationDelete=="Y")
                            ShowStudents(managerStudent.DeleteStudent(lines, valor));
                        break;
                    case "4":
                        ShowStudents(lines);
                        Console.WriteLine("Introduce the ID Student that you want to modify");
                        string idStudent = Console.ReadLine();
                        Console.WriteLine("Choose a modify criteria: \n" +
                    "\n1.- Type Student" +
                    "\n2.- Name" +
                    "\n3.- Go to back \n");
                        vCriteria = Convert.ToInt16(Console.ReadLine());
                        switch (vCriteria)
                        {
                            case 1: // by type student
                                Console.WriteLine("Introduce the new valor");
                                valorModify = Console.ReadLine();
                                managerStudent.ModifyStudent(lines, vCriteria, idStudent, valorModify);
                                break;
                            case 2: // by name                                                               
                                Console.WriteLine("Introduce the new valor");
                                valorModify = Console.ReadLine();
                                managerStudent.ModifyStudent(lines, vCriteria, idStudent, valorModify);
                                break;
                            case 3:
                                Console.WriteLine("Go to back");
                                OptionList();
                                break;
                        }
                        break;
                    case "5":
                        ShowStudents(lines);
                        break;
                    case "0":
                        Console.WriteLine("Thanks for using the aplication");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;


                }
            } while (option != "0");
        }
        public static void ShowStudents(string[] lines)
        {
            string formatString = "yyyyMMddHHmmss";
            DateTime de;
            Console.WriteLine("------------Results----------------");
            foreach (var line in lines)
            {
           
                if (line != null)
                {
                    var value = line.Split(';');
                    de = DateTime.ParseExact(value[4], formatString, null);
                    Console.WriteLine("ID: " + value[0] + "\n" +
                    "Type Student: " + value[1] + "\n" +
                    "Name: " + value[2] + "\n" +
                    "Gender: " + value[3] + "\n" +
                    "ModifyDatetime: " +de.ToString()  + "\n" +
                    ""                   
                    );
                }

               
            }
            Console.WriteLine("-----------------------------------");
            
        }
    }

}
