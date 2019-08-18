using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel
{

    public class HumanInventory
    {
        public Double Food { get; set; }
    }

    // primitif ;  
    public class Humanoid
    {
        
        public Double Fullness { get; set; }
        public Double Intelligence {get;set;}
        public HumanInventory inventory = new HumanInventory();

        public Humanoid()
        {
            
            Fullness = 50;
            inventory.Food = 100;

        }
        
        public async Task ConsumeFood(Double FoodAmount)
        {
            if (Fullness > 0)
                Fullness -= FoodAmount;
            else Fullness = 0;
            await Task.Delay(0);
        }

        public async Task EatFood(Double Foodamount)
        {
            Fullness += Foodamount;
            inventory.Food -= Foodamount;
            if (inventory.Food < 0) inventory.Food = 0;
            await Task.Delay(0);
        }

        public async Task Work(Double Worktime)
        {
            await EatFood(0.1D * Worktime).ConfigureAwait(false);
            await StackFood(Worktime * 0.2D).ConfigureAwait(false);
            
        }

        public async Task StackFood(Double Foodamount)
        {
            await EatFood(0.1D).ConfigureAwait(false);
            inventory.Food += Foodamount;
            if (inventory.Food > 100) inventory.Food = 100;
            

        }



        public async Task LifeCycleAsync()
        {


            await ConsumeFood(localmethods.Randomic(0, 1)).ConfigureAwait(false); 
            if (Fullness < 20) await EatFood(localmethods.Randomic(0, 3)).ConfigureAwait(false);
            
            if (inventory.Food<5) Work(localmethods.Randomic(1,3)).ConfigureAwait(false).GetAwaiter();

        }




    }
}