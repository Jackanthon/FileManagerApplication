using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Day3Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to my file manager");
            Menu();
        }
        static void User()
        {
            Console.Write("\nWhat's your name? ");
            string userName = Console.ReadLine();
            Console.Write("What's your age? ");
            int userAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Tell us about yourself? ");
            string userInfo = Console.ReadLine();
            Person person = new Person()
            {
                Name = userName,
                Age = userAge,
                Description = userInfo
            };
            CreateFile(person);
        }
        static void CreateFile(Person person)
        {
            string path = @"C:\Users\JackA\MSSA\Week 2\Files\";
            string filename = $"{person.Name}'s file.txt";
            path += filename;


            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                try
                {
                    Console.WriteLine("\nYour file is being created...");
                    sw.Write($"{person.Name} - {person.Age}\n");
                    sw.WriteLine(person.Description);
                    Console.WriteLine("File has been created.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sw.Close();
                }
            }
            else
            {
                Console.WriteLine("File already exists. You can add to or delete your file.");
            }
            Menu();
            Console.ReadLine();
        }
        static void Add()
        {
            string path = @"C:\Users\JackA\MSSA\Week 2\Files\";
            Console.WriteLine("\nEnter file name you'd like to add to");
            string filename = Console.ReadLine();
            path += filename;
            StreamWriter appendwriter = File.AppendText(path);
            Console.WriteLine("Add your information: ");
            string userInput = Console.ReadLine();
            appendwriter.WriteLine(userInput);
            appendwriter.Close();
            Menu();
        }
        static void Read()
        {
            string path = @"C:\Users\JackA\MSSA\Week 2\Files\";
            Console.WriteLine("\nEnter file name you'd like to read");
            try
            {
                string filename = Console.ReadLine();
                path += filename;
                string readFile = File.ReadAllText(path);
                Console.WriteLine(readFile);
                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Menu();
        }
        static void Copy()
        {
            string path = @"C:\Users\JackA\MSSA\Week 2\Files\";
            Console.WriteLine("\nEnter file name you'd like to copy");
            string fileName = Console.ReadLine();
            Console.WriteLine("\nWhat would you like to name the file");
            string newName = Console.ReadLine();
            var destination = @"C:\Users\JackA\MSSA\Week 2\Files\" + newName;
            path += fileName;
            try
            {
                File.Copy(path, destination);
                //File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("File copied\n");
            Menu();
        }


        static void DeleteFile()
        {
            string path = @"C:\Users\JackA\MSSA\Week 2\Files\";
            Console.WriteLine("\nEnter file name you'd like to delete");
            string filename = Console.ReadLine();
            path += filename;
            File.Delete(path);
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("Choose whether you'd like to create, add to or delete a file.\n" +
                "Please choose from this option:"); Console.ForegroundColor = ConsoleColor.White; Console.Write("| Create | Add | Read | Copy | Delete | Exit |\n"); Console.ForegroundColor = ConsoleColor.DarkRed;
            string userChoice = Console.ReadLine();
            userChoice = userChoice.ToUpper();
            if (userChoice == "CREATE") { User(); }
            if (userChoice == "ADD") { Add(); }
            if (userChoice == "READ") { Read(); }
            if (userChoice == "COPY") { Copy(); }
            if (userChoice == "DELETE") { DeleteFile(); }
            else { Environment.Exit(0); }


            Console.ReadLine();
        }
    }
}
//Write a console application to create a text file and save your basic details like name, age, address 
//    ( use dummy data). Read the details from same file and print on console.