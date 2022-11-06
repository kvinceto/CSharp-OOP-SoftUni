namespace Raiding.Models
{
    using Interfaces;

    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.name} healed for {this.Power}";
        }
    }
}
