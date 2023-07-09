// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double balance = 5000.00;
            int pin = 1514;

            int tries = 3;

            while (tries != 0)
            {
                Console.WriteLine("Enter Your PIN: ");
                int user_pin = Convert.ToInt32(Console.ReadLine());

                if (user_pin == pin)
                {
                    Console.WriteLine("Enter the transaction type you wish to perform: \n D: Deposit \n W: withdrawal");
                    string transType = Console.ReadLine();

                    if (transType.Equals("D") || transType.Equals("d"))
                    {
                        Console.WriteLine("Enter the amount you want to desposit: ");
                        double amnt = Convert.ToDouble(Console.ReadLine());

                        balance = Deposit(balance, amnt);

                        Console.WriteLine("\n Your transaction was successfull.\n Your balance is : " + balance);
                    }
                    else if (transType.Equals("W") || transType.Equals("w"))
                    {
                        Console.WriteLine("Enter the amount you want to withdraw: ");
                        double amnt = Convert.ToDouble(Console.ReadLine());
                        balance = Withdraw(balance, amnt);
                        Console.WriteLine("\n Your transaction was successfull.\n Your balance is : " + balance);

                    }
                    else
                    {
                        Console.WriteLine("Invalid transaction type");
                    }
                    break;
                }

                else
                {
                    tries--;
                    if (tries > 0)
                    {
                        Console.WriteLine("Inconrrect PIN \n\n Try again");
                    }
                    else if (tries == 0)
                    {
                        Console.WriteLine("Incorrect PIN \n Card Blocked!!");
                    }

                }



            }


            Console.ReadKey();
        }

        public static double Deposit(double balance, double amount)
        {
            return balance + amount;
        }

        public static double Withdraw(double balance, double amount)
        {
            return balance - amount;
        }
    }
}


