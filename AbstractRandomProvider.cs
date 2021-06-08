namespace WeightedRandom
{
    public abstract class AbstractRandomProvider
    {
        protected AbstractRandomProvider() { Construct(); }
        protected abstract void Construct();
        public abstract double GetRandom();

    }
}