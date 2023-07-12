using System;

namespace ATM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double balance = 5000.00;
            int pin = 1514;

            int tries = 3;
            bool isCardBlocked = false;

            while (tries != 0 && !isCardBlocked)
            {
                Console.WriteLine("Enter Your PIN: ");
                int user_pin = Convert.ToInt32(Console.ReadLine());

                if (user_pin == pin)
                {
                    Console.WriteLine("Login successful!");

                    while (true)
                    {
                        Console.WriteLine("\nSelect an option: ");
                        Console.WriteLine("1. Check Balance");
                        Console.WriteLine("2. Deposit");
                        Console.WriteLine("3. Withdraw");
                        Console.WriteLine("4. Transfer Funds");
                        Console.WriteLine("5. Exit");

                        int option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Your current balance is: " + balance);
                                break;

                            case 2:
                                Console.WriteLine("Enter the amount you want to deposit: ");
                                double depositAmount = Convert.ToDouble(Console.ReadLine());
                                balance = Deposit(balance, depositAmount);
                                Console.WriteLine("Your deposit was successful. Your new balance is: " + balance);
                                break;

                            case 3:
                                Console.WriteLine("Enter the amount you want to withdraw: ");
                                double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                if (withdrawAmount <= balance)
                                {
                                    balance = Withdraw(balance, withdrawAmount);
                                    Console.WriteLine("Your withdrawal was successful. Your new balance is: " + balance);

                                    Console.WriteLine("Enter the denomination of notes you want to withdraw (e.g., 20, 50): ");
                                    int noteDenomination = Convert.ToInt32(Console.ReadLine());
                                    int numberOfNotes = (int)(withdrawAmount / noteDenomination);

                                    Console.WriteLine("Dispensing $" + withdrawAmount + " as " + noteDenomination + " notes: " + numberOfNotes);
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient funds!");
                                }
                                break;

                            case 4:
                                Console.WriteLine("Enter the amount you want to transfer: ");
                                double transferAmount = Convert.ToDouble(Console.ReadLine());

                                if (transferAmount <= balance)
                                {
                                    Console.WriteLine("Enter the recipient's account number: ");
                                    string recipientAccount = Console.ReadLine();

                                    // Perform the transfer logic here

                                    balance = Withdraw(balance, transferAmount);
                                    Console.WriteLine("Your transfer was successful. Your new balance is: " + balance);
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient funds!");
                                }
                                break;

                            case 5:
                                Console.WriteLine("Thank you for using the ATM. Goodbye!");
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("Invalid option! Please select a valid option.");
                                break;
                        }
                    }
                }
                else
                {
                    tries--;
                    if (tries > 0)
                    {
                        Console.WriteLine("Incorrect PIN. " + tries + " attempts remaining. Please try again.");
                    }
                    else if (tries == 0)
                    {
                        Console.WriteLine("Incorrect PIN. Card blocked!!");
                        isCardBlocked = true;
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
