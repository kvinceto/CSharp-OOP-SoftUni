namespace Raiding.Models.Interfaces
{
    public abstract class BaseHero
    {
        protected string name;

        protected BaseHero(string name)
        {
            this.name = name;
        }

        public int Power { get; set; }

        public abstract string CastAbility();
    }
}
