using System.Collections;
using System.Collections.Generic;
using System;

namespace Subtegral.WeightedRandom
{
    public class SystemRandomProvider : AbstractRandomProvider
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

        public static SystemRandomProvider GetInstance()
        {
            return new SystemRandomProvider();
        }
    } 
}