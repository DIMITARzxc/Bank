using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcc
{

    public class Account
    {
        public int Acc { get; private set; }//номер счета
        public int Sum { get; set; }



        public Account(int _acc)
        {
            Acc = _acc;
        }
    }
    public class Transaction<T> where T : Account
    {
        public T FromAcc { get; set; }//перевод с заданного счета
        public T ToAcc { get; set; }//перевод на заданный счет
        public int Sum { get; set; }//сумма перевода
        public string User { get; set; }

        public void AddUser()
        {
            Console.WriteLine("Do you wanna register new account in bank system(y/n)");
            string userInput = Console.ReadLine();
            while (userInput != "y" && userInput != "n")
            {
                Console.WriteLine("Could not understand.(y / n)");
                userInput = Console.ReadLine();
            }
            if (userInput == "y")
            {
                Console.WriteLine("Enter your Lastname");
                User = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry you don't wanna register new account in our system and we can't provide the services of our bank");



            }

        }

        public void AddMoney()
        {



            Console.WriteLine($" {User} please enter your transaction sum");
            Sum = Convert.ToInt32(Console.ReadLine());


        }
        public void Execute()
        {
            if (FromAcc.Sum > Sum)
            {
                FromAcc.Sum -= Sum;
                ToAcc.Sum += Sum;
                Console.WriteLine($"Account{FromAcc.Acc}:{FromAcc.Sum}$ \nAccount{ToAcc.Acc}:{ToAcc.Sum}$");
            }
            else
            {
                Console.WriteLine($"Sum in account less than transaction{FromAcc.Acc}");
            }
        }
        public void PrintAcc()
        {

        }
    }
    class Program
    {

        static void Main(string[] args)
        {




            Console.WriteLine("Enter the account number to which you want to transfer money");
            int pushacc = Convert.ToInt32(Console.ReadLine());
            Account acc2 = new Account(pushacc) { Sum = 5000 };

            Console.WriteLine("Enter the account number from which you want to withdraw money");
            int takeacc = Convert.ToInt32(Console.ReadLine());
            Account acc1 = new Account(takeacc) { Sum = 4500 };
            Transaction<Account> transaction1 = new Transaction<Account>
            {
                FromAcc = acc1,
                ToAcc = acc2,


            };
            transaction1.AddUser();


            transaction1.AddMoney();
            transaction1.Execute();





            Console.ReadLine();
        }
    }
}
