using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel
{

    class Program
    {
        static List<Humanoid> humanoids = Enumerable.Range(1, 50000).Select(i => new Humanoid()).ToList();


        public static void Main(string[] args)
        {


            while (true)
            {

                GlobalCycle();
                Console.WriteLine("Humanoid 0 Fullness : " + humanoids[0].Fullness.ToString("F2") + " Food Stock: " + humanoids[0].inventory.Food.ToString("F2"));
            }

        }

        public static void GlobalCycle()
        {
            humanoids.AsParallel().WithDegreeOfParallelism(Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.8) * (511/8))))
            .ForAll(h =>
            {
                h.LifeCycleAsync().ConfigureAwait(true).GetAwaiter();
            });







        }
    }
}