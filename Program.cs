using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel
{

    class Program
    {
        // creating 10000 humanoids
        static List<Humanoid> humanoids = Enumerable.Range(1, 10000).Select(i => new Humanoid()).ToList();


        public static void Main(string[] args)
        {

            // infinite
            while (true)
            {
                //iterate all 
               
                GlobalCycle();
              
                Console.WriteLine("Humanoid 0 Fullness : " + humanoids[0].Fullness.ToString("F2") + " Food Stock: " + humanoids[0].inventory.Food.ToString("F2"));
                //observer

            }

        }

        public static void GlobalCycle()
        {

            // parallalelismos  50K objects are iteated once on each cycle.

            //80% thread load is given for this.
            humanoids.AsParallel().WithDegreeOfParallelism(Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.8) * (511/8))))
            .ForAll(h =>
            {
                h.LifeCycleAsync().ConfigureAwait(true).GetAwaiter();
            });







        }
    }
}