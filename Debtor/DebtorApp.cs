using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debtor.Core;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();
        public void IntroduceDebtorApp()
        {
            Console.WriteLine("Cześć witaj w apliakcji dłużnik, zapisuje osoby które pożyczyl od ciebie pieniądze ");
        }
        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz dodać do listy");

            var userName = Console.ReadLine();

            Console.WriteLine("Podaj kwotę długu");

            var userAmount = Console.ReadLine();

            var amoutnInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amoutnInDecimal))
            {
                Console.WriteLine("Podano nie poprawną kwotę");

                Console.WriteLine("Podaj kwotę długu");

                userAmount = Console.ReadLine();

            }
            BorrowerManager.AddBorrower(userName, amoutnInDecimal);



        }
        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz usunąć z listy");

            var userName = Console.ReadLine();

            BorrowerManager.DeleteBorrower(userName);

            Console.WriteLine("Udało się usunąć dłużnika");

        }
        public void ListAllBorrowers()
        {
            Console.WriteLine("Lista dłużników:");

            foreach(var borrower in BorrowerManager.ListBorrower())
            {
                Console.WriteLine(borrower);
            }
            BorrowerManager.CountDebators();

        }
        public void AskForAction()
        {
            var userInput = default(string);
            while (userInput != "exit")
            {
                Console.WriteLine("Co chciałbyś wykonać:");
                Console.WriteLine("add - Dodaj dłużnika");
                Console.WriteLine("del - Usuń dłużnika");
                Console.WriteLine("list - Wypisywanie listy dłużników");
                Console.WriteLine("exit - Wyjście z programu");

                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch (userInput)
                {
                    case "add":
                        AddBorrower();
                        break;
                    case "del":
                        DeleteBorrower();
                        break;
                    case "list":
                        ListAllBorrowers();
                        break;
                    default:
                        Console.WriteLine("Podałeś złą wartość");
                        break;
                }
            }
            
        }
    }
}
