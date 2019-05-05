using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitness.BL.Model;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in new Aplication");
            Console.WriteLine("Enter User Name");
            var name = Console.ReadLine();
           
            //Console.WriteLine("Enter Gender");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Enter Date");
            //var birthdate = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Weight");
            //var weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Height");
            //var height = double.Parse(Console.ReadLine());
           
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Enter gender:  ");
                var gender = Console.ReadLine();
                var birthDate=ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                birthDate = ParseDateTime();

                userController.SetUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();


        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter birth date(dd.mm.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("vrong date format");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;

                }
                else
                {
                    Console.WriteLine($"vrong {name} format");
                }
            }

        }
    }
}