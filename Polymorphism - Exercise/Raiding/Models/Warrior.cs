namespace Raiding.Models
{
    using Interfaces;

    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.name} hit for {this.Power} damage";
        }
    }
}
