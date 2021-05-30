using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomatenOpgave
{
    class Consumer
    {
        public string Name { get; set; }
        public static Queue<Soda> sodaQueue = new Queue<Soda>();
        public static Queue<Beer> beerQueue = new Queue<Beer>();

        public Consumer(string name)
        {
            this.Name = name;
        }

        public void Consume()
        {

        }
    }
}
