using System;
namespace Subtegral.WeightedRandom
{
    /// <summary>
    /// Uses SIMD Instructions to calculate
    /// </summary>
    public class UnityMathematicsRandomProvider : AbstractRandomProvider
    {
        private Random randomCache;
        public override void Construct()
        {
            randomCache = new Random();
        }

        public override double GetRandom()
        {
            return randomCache.NextDouble();
        }
    }
}