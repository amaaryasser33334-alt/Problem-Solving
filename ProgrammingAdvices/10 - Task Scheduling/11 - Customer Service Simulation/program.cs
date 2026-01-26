using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using static _11___Customer_Service_Simulation.Program;

namespace _11___Customer_Service_Simulation
{
    internal class Program
    {

        public class Customer
        {
            public int Id { get; set; }
            public int ArraivalTime { get; set; }
            public int ServiceTime { get; set; }

            public Customer(int Id, int ArraivalTime, int ServiceTime) 
            { 
                this.Id = Id;
                this.ArraivalTime = ArraivalTime;
                this.ServiceTime = ServiceTime;

                Console.WriteLine("Customer Id: " + Id + 
                                  " Arraival Time: " + ArraivalTime +
                                   " Service Time: " + ServiceTime); 
            }
        }

        static Random rnd = new Random();

        static public int GeneratRandomNumber(int Start = 0, int End = int.MaxValue)
        {

            return rnd.Next(Start, End);
        }

        static public void PrintAraivalCustomers(Queue<Customer> Customers, int CurrentTime)
        {
            Queue<int> ArraivalCutomeres = new Queue<int>
                 (
                   Customers.Where(customer => customer.ArraivalTime <= CurrentTime).Select(customer => customer.Id)
                 );

            if (ArraivalCutomeres.Count > 0)
            {
                Console.WriteLine("    Cutomers Queue: " + string.Join(", ", ArraivalCutomeres));
            }
            else
            {
                Console.WriteLine("    Cutomers Queue Is Empty");
            }
        }

        static public void CustomerServiceSimulation(Queue<Customer> Customers)
        {
            Customers =
                new Queue<Customer>(Customers.OrderBy(Customer => Customer.ArraivalTime)
                .ThenBy(Customer => Customer.Id));

            int CurrentTime = 0;
            Customer LastCustomer = null;

            while (Customers.Count > 0)
            {

                  Customer Customer = Customers.Peek();
          
                while (CurrentTime < Customer.ArraivalTime)
                {

                    Console.WriteLine("\nCurrent Time: " + CurrentTime);
                    Console.WriteLine("    Cutomers Queue Is Empty");
                    CurrentTime++;
                }
  
                Console.WriteLine("\nCurrent Time: " + CurrentTime);

                PrintAraivalCustomers(Customers, CurrentTime);

                Console.WriteLine("    Customer Id: " + Customer.Id +
                            " is Started Being Serverd With Start Time: " + CurrentTime +
                            " End Time: " + Convert.ToInt32(CurrentTime + Customer.ServiceTime));

                int LastCurrentTime = CurrentTime;
                while (CurrentTime < LastCurrentTime + Customer.ServiceTime)
                {
                    CurrentTime++;
                    Console.WriteLine("\nCurrent Time: " + CurrentTime);

                    PrintAraivalCustomers(Customers, CurrentTime);
                    Console.WriteLine("    Customer Id: " + Customer.Id + " is being Serving" );
                }
                



                LastCustomer = Customers.Dequeue();
                Console.WriteLine("    Customer Id: " + Customer.Id + " is finish  being Serving");
                PrintAraivalCustomers(Customers, CurrentTime);

                Console.WriteLine();

            }

            Console.Write("\nCurrent Time: " + CurrentTime + ", Cutomers Queue Is Empty");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {

            Queue<Customer> Customers = new Queue<Customer>();
            for (int i = 101; i < 106; i++)
            {
                Customers.Enqueue(new Customer(i, GeneratRandomNumber(0,10), GeneratRandomNumber(1,10)));
            }

            Console.WriteLine();
            Console.WriteLine("Start Customer Service Simulation...");
            Console.WriteLine();

            CustomerServiceSimulation(Customers);

            Console.WriteLine();
            Console.WriteLine("End Customer Service Simulation.");

            Console.ReadLine();

        }
    }
}
