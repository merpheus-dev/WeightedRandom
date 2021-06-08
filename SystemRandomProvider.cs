using System;

namespace WeightedRandom
{
    public class SystemRandomProvider : AbstractRandomProvider
    {
        private Random _randomCache;

        protected override void Construct()
        {
            _randomCache = new Random();
        }

        public override double GetRandom()
        {
            return _randomCache.NextDouble();
        }

        public static SystemRandomProvider GetInstance()
        {
            return new SystemRandomProvider();
        }
    } 
}