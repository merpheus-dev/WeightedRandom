using System.Collections.Generic;
using System.Linq;
using System;
namespace Subtegral.WeightedRandom
{
    public class WeightedRandom<T>
    {
        private Dictionary<T, float> probabiltyTable = new Dictionary<T, float>();
        private List<KeyValuePair<T, float>> sortedPair;
        private WeightAlgorithm algorithm;
        private AbstractRandomProvider randomProvider;

        #region Constructors
        public WeightedRandom() : this(new SystemRandomProvider(), WeightAlgorithm.FairBiased) { }
        public WeightedRandom(WeightAlgorithm algorithm)
        {
            randomProvider = new SystemRandomProvider();
            this.algorithm = algorithm;
        }
        public WeightedRandom(AbstractRandomProvider provider) : this(WeightAlgorithm.FairBiased)
        {
            randomProvider = provider ?? throw new Exception("Random provider is not instantiated.");
        }
        public WeightedRandom(AbstractRandomProvider provider, WeightAlgorithm algorithm)
        {
            randomProvider = provider ?? throw new Exception("Random provider is not instantiated.");
            this.algorithm = algorithm;
        }
        #endregion

        public void Add(T val, float probability)
        {
            probabiltyTable.Add(val, probability);
            sortedPair = probabiltyTable.OrderBy(i => i.Value).ToList();
        }

        public T Next()
        {
            if (sortedPair == null || sortedPair.Count == 0)
                throw new Exception("No elements added to probability calculation!");

            float totalProbability = sortedPair.Sum(x => x.Value);
            double randomValue = randomProvider.GetRandom() * totalProbability;
            for (var i = 0; i < sortedPair.Count; i++)
            {
                //TO-DO:Implement an algorithm factory and decouple it from here.
                if (algorithm == WeightAlgorithm.FairBiased)
                {

                    randomValue -= sortedPair[i].Value;
                    if (randomValue <= 0)
                        return sortedPair[i].Key;
                }
                else
                {
                    if (randomValue < sortedPair[i].Value)
                        return sortedPair[i].Key;

                    randomValue -= sortedPair[i].Value;
                }

            }
            return default; //Replace with random pick;
        }

    }
}
