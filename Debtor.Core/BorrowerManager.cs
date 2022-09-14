using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtor.Core
{
    public class BorrowerManager
    {
        private List<Borrower> Borrowers { get; set; }

        private string FileName { get; set; } = "borrowers.txt";

        public BorrowerManager()
        {
            Borrowers = new List<Borrower>();

            if (!File.Exists(FileName))
            {
                return;
            }

            var fileLines = File.ReadAllLines(FileName);

            foreach(var line in fileLines)
            {
                var lineItems = line.Split(';');

                if(decimal.TryParse(lineItems[1], out var amoutnInDecimal))
                {
                    AddBorrower(lineItems[0],amoutnInDecimal, false);
                }
            }
        }

        public void AddBorrower(string name, decimal amount, bool shouldSaveToFile =true)
        {
            var borrower = new Borrower
            {
                Name = name,
                Amount = amount
            };

            Borrowers.Add(borrower);

            if (shouldSaveToFile)
            {
                File.WriteAllLines(FileName, new List<string> {borrower.ToString()} );
            }
        }
        public void DeleteBorrower(string name, bool shouldSaveToFile = true)
        {
            foreach (var borrower in Borrowers)
            {
                if(borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    break;
                }
            }

            if (shouldSaveToFile)
            {
                var borrowesToSave = new List<string>();

                foreach(var borrower in Borrowers)
                {
                    borrowesToSave.Add(borrower.ToString());
                }
                File.Delete(FileName);

                File.WriteAllLines(FileName, borrowesToSave);
            }
        }
        public List<string> ListBorrower()
        {
            var borrowersStrings = new List<string>();

            var indexer = 1;

            foreach(var borrower in Borrowers)
            {
                var borrowerString = indexer + ". " + borrower.Name + " - " + borrower.Amount + "zł";
                indexer++;
                borrowersStrings.Add(borrowerString);
            }
            return borrowersStrings;
        }
        //mój kod
        public void CountDebators()
        {
            decimal allDebt = 0;
            foreach(var borrower in Borrowers)
            {
                allDebt += borrower.Amount;
            }
            if(allDebt == 0)
            {
                Console.WriteLine("W tym momencie nie masz żadnych dłużników");
            }
            else
            {
                Console.WriteLine("Łączna liczba długów - " + allDebt);
            }
        }

   

    }
}
