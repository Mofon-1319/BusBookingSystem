using System;

namespace BusApp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Home home = new Home();
            Console.ReadLine();
        }
    }

    class Home
    {
        public enum Choice { SignUp = 1, LogIn = 2, ViewBus = 3 };
        public static int readChoice;
        public Home()
        {

            AdminRepository adminRepository = new AdminRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            while (true)
            {
                Console.WriteLine("Enter your choice of account");
                Console.WriteLine("1. SignUp");
                Console.WriteLine("2. logIn");
                readChoice = Int32.Parse(Console.ReadLine());
                Choice myChoice = (Choice)readChoice;
                if (myChoice == Choice.SignUp)
                {
                    Console.WriteLine("Enter your role");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. User");
                    byte choice = Convert.ToByte(Console.ReadLine());
                    if (choice == 1)
                        adminRepository.SignUp();
                    else
                        customerRepository.SignUp();
                }
                else if (myChoice == Choice.LogIn)
                {
                    Console.WriteLine("Enter your role");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. User");
                    byte choice = Convert.ToByte(Console.ReadLine());
                    if (choice == 1)
                        adminRepository.LogIn();
                    else
                        customerRepository.LogIn();
                }
                else
                    break;
            }
        }
    }
}
