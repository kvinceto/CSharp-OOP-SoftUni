using System.Collections.Generic;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private Dictionary<string, IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new Dictionary<string, IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.Values;

        public void AddItem(IPlanet model)
        {
            if (!this.planets.ContainsKey(model.Name))
            {
                this.planets.Add(model.Name, model);
            }
        }

        public IPlanet FindByName(string name)
        {
            if (this.planets.ContainsKey(name))
            {
                return this.planets[name];
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (this.planets.ContainsKey(name))
            {
                this.planets.Remove(name);
                return true;
            }
            return false;
        }
    }
}
