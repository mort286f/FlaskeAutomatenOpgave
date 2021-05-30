using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlaskeAutomatenOpgave
{
    class Producer
    {
        //List that contains the Drink class, which Beer and Soda derives from
        public static Queue<Drink> prodQueue;
        public Producer()
        {
            prodQueue = new Queue<Drink>();
        }

        //Produces either one beer or soda with a name and serial number
        public void Produce()
        {
            while (true)
            {
                try
                {
                    Random rndm = new Random();
                    int typeSwitch = rndm.Next(1, 3);

                    Monitor.Enter(Drink.drinkLock);
                    while (prodQueue.Count == 10)
                    {
                        Console.WriteLine("Producer could not produce any drinks, waiting...");
                        Monitor.Wait(Drink.drinkLock);
                    }

                    if (prodQueue.Count <= 10)
                    {
                        if (typeSwitch == 1)
                        {
                            prodQueue.Enqueue(new Beer("Tuborg"));
                            Console.Write("Producer produces 1 Beer");
                            Thread.Sleep(500);
                        }
                        if (typeSwitch == 2)
                        {
                            prodQueue.Enqueue(new Soda("Fanta"));
                            Console.Write("Producer produces 1 Soda");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine(". There is now " + prodQueue.Count + " drinks in queue");
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    Monitor.Exit(Drink.drinkLock);
                }
            }
        }
    }

}

