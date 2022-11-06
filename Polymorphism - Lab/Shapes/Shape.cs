namespace Shapes
{
    public abstract class Shape
    {
        protected Shape()
        {
            
        }
        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();

        public virtual string Draw() => "";
    }
}
