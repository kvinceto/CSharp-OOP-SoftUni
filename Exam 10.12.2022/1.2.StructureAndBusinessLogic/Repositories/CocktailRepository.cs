using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> list;

        public CocktailRepository()
        {
            this.list = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => this.list;

        public void AddModel(ICocktail model)
        {
            this.list.Add(model);
        }
    }
}
