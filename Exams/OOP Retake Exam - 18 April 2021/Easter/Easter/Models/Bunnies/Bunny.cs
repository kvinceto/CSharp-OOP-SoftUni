using System;
using System.Collections.Generic;
using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.EnergySetter(energy);
            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBunnyName));
                }

                this.name = value;
            }
        }

        public int Energy { get; protected set; }

        protected void EnergySetter(int n)
        {
            this.Energy =  n < 0 ? 0 : n;
        }
        public ICollection<IDye> Dyes => this.dyes;

        public virtual void Work()
        {
            this.Energy -= 10;
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }

        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}"
                   + Environment.NewLine
                   + $"Energy: {this.Energy}"
                   + Environment.NewLine
                   + $"Dyes: {this.Dyes.Where(d => d.IsFinished() == false).ToList().Count} not finished";

        }
    }
}
