using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Subtegral.WeightedRandom
{
    public class UnityEngineRandomProvider : AbstractRandomProvider
    {
        public override void Construct() { }

        public override double GetRandom()
        {
            return Random.Range(0f, 1f);
        }
    }
}