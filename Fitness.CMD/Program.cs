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

            Console.WriteLine("Enter Gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter Date");
            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();
        }
    }
}