using System;

namespace WeightedRandom
{
    /// <summary>
    /// Uses SIMD Instructions to calculate
    /// </summary>
    public class UnityMathematicsRandomProvider : AbstractRandomProvider
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
    }
}