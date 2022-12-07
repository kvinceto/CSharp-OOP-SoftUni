using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private Dictionary<string, IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new Dictionary<string, IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models  => this.bunnies.Values;

        public void Add(IBunny model)
        {
            if(!this.bunnies.ContainsKey(model.Name))
                this.bunnies.Add(model.Name, model);
        }

        public bool Remove(IBunny model)
        {
            if (this.bunnies.ContainsKey(model.Name))
            {
                this.bunnies.Remove(model.Name);
                return true;
            }
            return false;
        }

        public IBunny FindByName(string name)
        {
            if (this.bunnies.ContainsKey(name))
            {
                return this.bunnies[name];
            }
            return null;
        }
    }
}
