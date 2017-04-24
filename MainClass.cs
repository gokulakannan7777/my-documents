using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class MainClass
    {
        public static List<SavingsAccount> salist = new List<SavingsAccount>();
        public static List<CurrentAccount> calist = new List<CurrentAccount>();
        static void Main(string[] args)
        {
            string Confirm;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to the Banking Services");
                Console.WriteLine("1. SavingAccount \n2. CurrentAccount");
                Console.ResetColor();
                int choice = GetInt("Enter the choice");


                switch (choice)
                {
                    case 1:
                        displayMenu();
                        SavingsAccount sa = new SavingsAccount();
                        accountOptions(sa);
                        break;

                    case 2:
                        displayMenu();
                        CurrentAccount ca = new CurrentAccount();
                        accountOptions(ca);
                        break;

                    default:
                        Console.WriteLine("Please choose a valid option");
                        break;
                }
                Console.WriteLine("Enter 'y' to continue");
                Confirm = Console.ReadLine().ToUpper();
            } while (Confirm == "Y");


        }

        private static int GetInt(string message)
        {
            int val = 0;
            while (true)
            {

                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out val))
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The entered number is not in correct format please try again");
                Console.ResetColor();
            }
            return val;
        }

        public static void displayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1.Create an account");
            Console.WriteLine("2.Edit Account");
            Console.WriteLine("3.Deposit");
            Console.WriteLine("4.Withdrawal");
            Console.WriteLine("5.Check Balance");
            Console.WriteLine("6.CloseAccount");
            Console.WriteLine("7.Amount Transactions");


            Console.ResetColor();

        }

        public static void accountOptions(SavingsAccount obj)
        {
            int choice = GetInt("Enter the choice");
            switch (choice)
            {
                case 1:
                    obj.OpenAccount();
                    salist.Add(obj);
                    break;
                case 2:
                    obj.EditAccount();
                    break;
                case 3:
                    obj.Deposit();
                    break;
                case 4:
                    obj.Withdrawal();
                    break;
                case 5:
                    obj.CheckBalance();
                    break;
                case 6:
                    obj.CloseAccount();
                    break;
                case 7:
                    obj.TransferAmount();
                    break;
                default:
                    Console.WriteLine("Please choose a valid option");
                    break;
            }
        }

        public static void accountOptions(CurrentAccount obj)
        {
            int choice = GetInt("Enter the choice");
            switch (choice)
            {
                case 1:
                    obj.OpenAccount();
                    calist.Add(obj);
                    break;
                case 2:
                    obj.EditAccount();
                    break;
                case 3:
                    obj.Deposit();
                    break;
                case 4:
                    obj.Withdrawal();
                    break;
                case 5:
                    obj.CheckBalance();
                    break;
                case 6:
                    obj.CloseAccount();
                    break;
                case 7:
                    obj.TransferAmount();
                    break;
                default:
                    Console.WriteLine("Please choose a valid option");
                    break;
            }
        }
    }
    }

