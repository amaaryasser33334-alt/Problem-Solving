using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1___Coin_Change_Problem
{
    internal class Program
    {
        static List<int> MinCurrencyDenominations(int ReturnValue)
        {
            List<int> CurrencyDenominations = new List<int> { 1, 5, 10, 20, 50, 100 };
            List<int> ReturnCurrencyDenominationsList = new List<int> { };

            byte ConuterCurrencyDenominations = 5;

            while (ReturnValue > 0)
            {
                if ((ReturnValue >= ReturnCurrencyDenominationsList[ConuterForChangeList]))
                {
                    ReturnCurrencyDenominationsList.Add(ReturnCurrencyDenominationsList[ConuterCurrencyDenominations]);
                    ReturnValue -= ReturnCurrencyDenominationsList[ConuterCurrencyDenominations];

                }
                else
                {
                    ConuterCurrencyDenominations--;

                }

            }

            return (ReturnCurrencyDenominationsList);
        }

        static void Main(string[] args)
        {
            int ChangeValue = 0;
            Console.WriteLine("Enter the change value: ");
            ChangeValue = Convert.ToInt32(Console.ReadLine());
            List<int> ReturnCurrencyDenominations = MinCurrencyDenominations(ChangeValue);
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("Number of Banknotes: " + ReturnCurrencyDenominations.Count());
            Console.Write("List of Banknotes:  ");
            ReturnCurrencyDenominations.ForEach(Change => Console.Write(Change + " ,"));
            Console.ReadLine();
        }
    }
}
