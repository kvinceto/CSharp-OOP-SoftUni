using System.Collections.Generic;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> list;

        public BoothRepository()
        {
            this.list = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => this.list;

        public void AddModel(IBooth model)
        {
           this.list.Add(model);
        }
    }
}
