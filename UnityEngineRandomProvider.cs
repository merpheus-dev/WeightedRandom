using UnityEngine;

namespace WeightedRandom
{
    public class UnityEngineRandomProvider : AbstractRandomProvider
    {
        protected override void Construct() { }

        public override double GetRandom()
        {
            return Random.Range(0f, 1f);
        }
    }
}