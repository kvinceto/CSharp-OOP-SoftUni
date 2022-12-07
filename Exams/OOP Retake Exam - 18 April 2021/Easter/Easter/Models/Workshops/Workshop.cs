using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
            
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
               if(egg.IsDone())
                   break;
               if(bunny.Energy == 0)
                   break;
               if(bunny.Dyes.All(d => d.IsFinished() == true))
                   break;

               foreach (var dye in bunny.Dyes)
               {
                   while (!dye.IsFinished())
                   {
                       if(egg.IsDone())
                           break;
                       dye.Use();
                       egg.GetColored();
                       bunny.Work();
                       if(bunny.Energy == 0)
                           break;
                   }
                   if(egg.IsDone())
                       break;
                   if(bunny.Energy == 0)
                       break;
               }
            }
        }
    }
}
