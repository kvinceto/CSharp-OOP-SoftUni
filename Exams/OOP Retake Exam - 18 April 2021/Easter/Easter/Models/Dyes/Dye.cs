using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                else
                {
                    this.power = value;
                }
            }
        }

        public void Use()
        {
            this.power -= 10;
            if (this.power < 0)
            {
                this.power = 0;
            }
        }

        public bool IsFinished() => this.power == 0;
    }
}
