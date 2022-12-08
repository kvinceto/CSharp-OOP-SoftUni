using System.Collections.Generic;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        Dictionary<string, IHero> heroesByName;

        public HeroRepository()
        {
            this.heroesByName = new Dictionary<string, IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroesByName.Values;

        public void Add(IHero model)
        {
            if(!this.heroesByName.ContainsKey(model.Name))
                this.heroesByName.Add(model.Name, model);
        }

        public bool Remove(IHero model)
        {
            if (this.heroesByName.ContainsKey(model.Name))
            {
                this.heroesByName.Remove(model.Name);
                return true;
            }

            return false;
        }

        public IHero FindByName(string name)
        {
           if(this.heroesByName.ContainsKey(name))
               return this.heroesByName[name];

           return null;
        }
    }
}
