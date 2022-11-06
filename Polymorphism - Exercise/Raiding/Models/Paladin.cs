namespace Raiding.Models
{
    using Interfaces;

    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.name} healed for {this.Power}";
        }
    }
}
