using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel
{
    // Inventory of single human  note: all kind of goods should be defined here statically ? or should i call from an object bucket ? cuz trables.. hmm we'll see
    // should be max weight imho
    public class HumanInventory
    {
        //primitive consumable
        public Double Food { get; set; }
    }

    // primitif ;  
    public class Humanoid
    {
        
        // min 0 max 100
        public Double Fullness { get; set; }

        // not implemented 0.00D-->1.00D ?
        public Double Intelligence {get;set;}

        // not implemented. handycrafty maybe ?  0.00 --> 1 ?
        public Double Efficiency { get; set; }

        // not implemented. Shit may happen
        public Double Chance { get; set; }

        // definition of inventory 
        public HumanInventory inventory = new HumanInventory();

        public Humanoid()
        {
            // society balance first
            Fullness = 50;

            // adam's eve
            inventory.Food = 100;

        }
        
        // consumes from Fullness , Fullness is like human energy for now
        public async Task ConsumeFood(Double FoodAmount)
        {
           
            if (Fullness > 0)
                Fullness -= FoodAmount;
            else Fullness = 0;
            await Task.Delay(0);
        }

        // get food from inventory to stomach, inceease same amount of fullness ( can go for energy conversion from between foods in inventory.)
        public async Task EatFood(Double Foodamount)
        {
            
            Fullness += Foodamount;
            inventory.Food -= Foodamount;
            if (inventory.Food < 0) inventory.Food = 0;
            await Task.Delay(0);
        }

        // when inventory goes empty , our primitive humanoid go for hunting ?  or walk on map ( also, the more he cant find anything the more he comsumes energy) 
        public async Task Work(Double Worktime)
        {
          
            await ConsumeFood(0.1D * Worktime).ConfigureAwait(false);
            await StackFood(Worktime * 0.2D).ConfigureAwait(false);
            // note: those worktimes will be limited to something like 24 hours 
        }

        // from hunting to inventory, during this job. it consumes energy too
        public async Task StackFood(Double Foodamount)
        {
            
            await ConsumeFood(0.1D).ConfigureAwait(false);
            inventory.Food += Foodamount;
            if (inventory.Food > 100) inventory.Food = 100;
            

        }



        public async Task LifeCycleAsync()
        {

            // daily this will be handled after a while.  for now it comsumes energy at all iteration.
            await ConsumeFood(localmethods.Randomic(0, 1)).ConfigureAwait(false); 

            // if Hunger comes he eats food from inventory
            if (Fullness < 20) await EatFood(localmethods.Randomic(0, 3)).ConfigureAwait(false);
            
            // if inventory goes empty, he goes out to find food ( will do better later )
            if (inventory.Food<5) Work(localmethods.Randomic(1,3)).ConfigureAwait(false).GetAwaiter();

        }




    }
}