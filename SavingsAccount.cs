using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class SavingsAccount : Account, ITransaction, IROI

    {

        int MaxwithdrawalAmount = 50000;
        int MaxDepositAmount = 50000;
        int minbal = 1000;



        public override void OpenAccount()
        {
            Console.WriteLine("Enter the username");
            userName = Console.ReadLine();
            Console.WriteLine("Enter the amount to be deposited");
            balance = int.Parse(Console.ReadLine());
            if (balance >= 1000)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Savings Account is created successfully ");
                Console.ResetColor();
                Console.WriteLine("AccountNumber:{0}", accountNumber);
                Console.WriteLine("AccountName:{0}", userName);
                Console.WriteLine("AccountBalance:{0}", balance);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Amount should be morethan 1000 to create an account");
                Console.ResetColor();

            }

        }

        public override void EditAccount()
        {
            Console.WriteLine("Enter the account number");
            long numcheck = long.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in MainClass.salist)
            {
                count++;

                if (item.accountNumber == numcheck)
                {
                    Console.WriteLine("AccountName:{0}", item.userName);
                    Console.WriteLine("Enter the username to be modified");
                    item.userName = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your username is modified successfully");
                    Console.WriteLine("AccountName:{0}", item.userName);
                    Console.ResetColor();
                    break;
                }
                else if (count == MainClass.salist.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the valid account number");
                    Console.ResetColor();
                }

            }

        }

        public override void Deposit()
        {
            Console.WriteLine("Enter the account number");
            long numcheck = long.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in MainClass.salist)
            {
                count++;
                if (item.accountNumber == numcheck)
                {
                    Console.WriteLine("AccountName:{0}", item.userName);
                    Console.WriteLine("Enter the amount to be deposited");
                    int deposit = int.Parse(Console.ReadLine());
                    // To check the amount is in valid range
                    //int amnt = 0;
                    //amnt = amnt + deposit;

                    try
                    {
                        if (deposit < MaxDepositAmount)
                        {
                            item.balance += deposit;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Amount is deposited successfully");
                            Console.ResetColor();

                        }

                        else
                        {
                            throw new MaxDepositAmtException("You can not deposit ammount greater than 50000 ");
                        }
                    }
                    catch (MaxDepositAmtException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;

                }
                else if (count == MainClass.salist.Count)
                {
                    Console.WriteLine("Please enter the valid account number");
                }


            }

        }


        public override void Withdrawal()
        {
            Console.WriteLine("Enter the account number");
            long numcheck = long.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in MainClass.salist)
            {
                count++;
                if (item.accountNumber == numcheck)
                {
                    Console.WriteLine("AccountName:{0}", item.userName);
                    Console.WriteLine("Enter the amount to be Withdrawn");
                    int withdraw = int.Parse(Console.ReadLine());
                    // To check the amount is in valid range
                    // int amnt = 0;
                    //amnt = amnt + deposit;

                    try
                    {

                        if (withdraw < MaxwithdrawalAmount)
                        {

                            if ((item.balance - withdraw) > minbal)
                            {
                                item.balance -= withdraw;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Amount is withdrawn successfully");
                                Console.ResetColor();
                            }

                            else
                            {
                                throw new minBalException("Withdrawal Error!-minBalance after withdrawal should be greater than 1000");
                            }

                        }

                        else
                        {
                            throw new MaxwithdrawalAmount("You can not withdraw ammount greater than 50000");
                        }
                    }
                    catch (minBalException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();

                    }

                    catch (MaxwithdrawalAmount e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();


                    }
                    break;

                }
                else if (count == MainClass.salist.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please entere the valid account number");
                    Console.ResetColor();
                }

            }

        }

        public override void CheckBalance()
        {
            Console.WriteLine("Enter the account number");
            long numcheck = long.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in MainClass.salist)
            {
                count++;
                if (item.accountNumber == numcheck)
                {
                    // Console.WriteLine("AccountBalance:{0}", item.balance);
                    GetRateOfInterest(numcheck);
                    break;
                }
                else if (count == MainClass.salist.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the valid account number");
                    Console.ResetColor();
                }
            }
        }

        public override void CloseAccount()
        {
            Console.WriteLine("Enter the account number");
            long numcheck = long.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in MainClass.salist)
            {
                count++;
                try
                {
                    if (item.accountNumber == numcheck)
                    {
                        if (item.balance == 0)
                        {
                            MainClass.salist.Remove(item);
                        }
                        else
                        {
                            throw new AccountCloseException((" To close the Account the balance should be zero"));
                        }
                    }
                    else if (count == MainClass.salist.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter the valid account number");
                        Console.ResetColor();
                    }
                }
                catch (AccountCloseException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }



        public void GetAccountDetails()
        {
            Console.WriteLine("Enter the account number");
            long numcheck = long.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in MainClass.salist)
            {
                count++;
                if (item.accountNumber == numcheck)
                {
                    Console.WriteLine("AccountNumber:{0}", item.accountNumber);
                    Console.WriteLine("AccountName:{0}", item.userName);
                    Console.WriteLine("AccountBalance:{0}", item.balance);
                    break;
                }
                else if (count == MainClass.salist.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the valid account number");
                    Console.ResetColor();
                }
            }
        }

        public void TransferAmount()
        {
            long fromaccount;
            long toaccount;
            Console.WriteLine("Enter the From account number");
            fromaccount = long.Parse(Console.ReadLine());
            int count = 0; int count1 = 0;
            foreach (var item in MainClass.salist)
            {
                count++;
                if (item.accountNumber == fromaccount)
                {
                    Console.WriteLine("Enter To account number");
                    toaccount = long.Parse(Console.ReadLine());


                    for (int i = 0; i < MainClass.salist.Count; i++)
                    {
                        count1++;
                        if (MainClass.salist[i].accountNumber == toaccount)
                        {

                            Console.WriteLine("Enter the ammount to be transfered");
                            int amount = int.Parse(Console.ReadLine());
                            if (fromaccount != toaccount)
                            {
                                if (item.balance > amount + minbal)
                                {
                                    item.balance = item.balance - amount;
                                    MainClass.salist[i].balance = MainClass.salist[i].balance + amount;
                                    Console.WriteLine("Balance is transferred successfully");
                                    Console.WriteLine($"The Available balance in the {MainClass.salist[i].accountNumber} is {MainClass.salist[i].balance }");
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient balance to transfer");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Transfer can be done between two different accounts");
                            }
                            break;

                        }
                        else if (count1 == MainClass.salist.Count)
                        {
                            Console.WriteLine("Please enter the valid account number");
                        }

                    }
                    break;
                }
                else if (count == MainClass.salist.Count)
                {
                    Console.WriteLine("Please enter the valid account number");
                }
            }
        }

        public void GetRateOfInterest(long numcheck)
        {
            double simpleinterst = 0;
            foreach (var item in MainClass.salist)
            {
                if (item.accountNumber == numcheck)
                {
                    simpleinterst = item.balance * 0.04 * 1;
                    item.balance = item.balance + (int)simpleinterst;
                    Console.WriteLine($"The Available balance in {item.accountNumber} is {item.balance}");
                }
            }
        }


    }
}
