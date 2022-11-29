using System.Collections.Generic;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private HashSet<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new HashSet<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IFormulaOneCar model)
        {
            bool inCollection = this.models.Any(m => m.Model == model.Model);
            if (!inCollection)
            {
                this.models.Add(model);
            }
        }

        public bool Remove(IFormulaOneCar model)
        {
            IFormulaOneCar carToRemove = this.models.FirstOrDefault(m => m.Model == model.Model);
            if (carToRemove != null)
            {
                this.models.Remove(carToRemove);
                return true;
            }

            return false;
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }
    }
}
