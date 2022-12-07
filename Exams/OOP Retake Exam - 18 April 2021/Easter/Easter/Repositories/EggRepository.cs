using System.Collections.Generic;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private Dictionary<string, IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new Dictionary<string,IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.eggs.Values;

        public void Add(IEgg model)
        {
            if (!this.eggs.ContainsKey(model.Name))
            {
                this.eggs.Add(model.Name, model);
            }
        }

        public bool Remove(IEgg model)
        {
            if (this.eggs.ContainsKey(model.Name))
            {
                this.eggs.Remove(model.Name);
                return true;
            }
            return false;
        }

        public IEgg FindByName(string name)
        {
            if (this.eggs.ContainsKey(name))
            {
                return this.eggs[name];
            }
            return null;
        }
    }
}
