using System.Collections.Generic;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> list;

        public DelicacyRepository()
        {
            this.list = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => this.list;

        public void AddModel(IDelicacy model)
        {
            this.list.Add(model);
        }
    }
}
