using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlaskeAutomatenOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            Producer prod = new Producer();
            Consumer cons1 = new Consumer("Hans");
            Consumer cons2 = new Consumer("Grete");

            Thread prodThread = new Thread(prod.Produce);
            Thread consOne = new Thread(cons1.Consume);
            Thread consTwo = new Thread(cons2.Consume);


            prodThread.Start();
        }

        public void SplitDrinks()
        {
            while (true)
            {
                lock (Producer.prodQueue)
                {

                    try
                    {
                        while (Producer.prodQueue.Count == 0)
                        {
                            Monitor.Wait(Producer.prodQueue);
                        }
                        lock (Consumer.beerQueue)
                        {

                            while (Producer.prodQueue.Count > 0)
                            {
                                for (int i = 0; i < Producer.prodQueue.Count; i++)
                                {

                                    if (Producer.prodQueue.GetType() == typeof(Beer))
                                    {
                                        Consumer.beerQueue.Enqueue(Producer.prodQueue.ElementAt(i));
                                    }
                                    if (Producer.prodQueue.GetType() == typeof(Soda))
                                    {
                                        Consumer.sodaQueue.Enqueue(Producer.prodQueue.ElementAt(i));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
