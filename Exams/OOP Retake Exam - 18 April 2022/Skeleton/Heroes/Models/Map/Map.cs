using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public Map()
        {

        }

        public string Fight(ICollection<IHero> players)
        {
            List<Barbarian> barbarians = new List<Barbarian>();
            List<Knight> knights = new List<Knight>();
            foreach (IHero hero in players)
            {
                if (hero is Barbarian)
                    barbarians.Add((Barbarian)hero);
                else if (hero is Knight)
                    knights.Add((Knight)hero);
            }

            int turn = 0;

            while (barbarians.Any(b => b.IsAlive == true) &&
                   knights.Any(k => k.IsAlive == true))
            {
                turn++;
                if (turn % 2 != 0)
                {
                    foreach (var knight in knights.Where(x => x.Health > 0))
                    {
                        foreach (var barbarian in barbarians.Where(x => x.Health > 0))
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }
                else
                {
                    foreach (var barbarian in barbarians.Where(x => x.Health > 0))
                    {
                        foreach (var knight in knights.Where(x => x.Health > 0))
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
            }

            if (barbarians.Any(b => b.IsAlive))
            {
                return $"The barbarians took {barbarians.Where(b => b.Health == 0).ToList().Count} casualties but won the battle.";
            }

            return $"The knights took {knights.Where(k => k.Health == 0).ToList().Count} casualties but won the battle.";
        }
    }
}
