namespace Subtegral.WeightedRandom
{
    public abstract class AbstractRandomProvider
    {
        protected AbstractRandomProvider() { Construct(); }
        public abstract void Construct();
        public abstract double GetRandom();

    }
}