using System;
using System.Collections.Generic;
using System.Linq;

namespace WeightedRandom
{
    public sealed class WeightedRandom<T>
    {
        private Dictionary<T, float> _probabiltyTable = new Dictionary<T, float>();
        private List<KeyValuePair<T, float>> _sortedPair;
        private WeightAlgorithm algorithm;
        private AbstractRandomProvider _randomProvider;

        #region Constructors
        public WeightedRandom() : this(new SystemRandomProvider(), WeightAlgorithm.FairBiased) { }

        private WeightedRandom(WeightAlgorithm algorithm)
        {
            _randomProvider = new SystemRandomProvider();
            this.algorithm = algorithm;
        }
        public WeightedRandom(AbstractRandomProvider provider) : this(WeightAlgorithm.FairBiased)
        {
            _randomProvider = provider ?? throw new Exception("Random provider is not instantiated.");
        }

        private WeightedRandom(AbstractRandomProvider provider, WeightAlgorithm algorithm)
        {
            _randomProvider = provider ?? throw new Exception("Random provider is not instantiated.");
            this.algorithm = algorithm;
        }
        #endregion

        public void Add(T val, float probability)
        {
            _probabiltyTable.Add(val, probability);
            _sortedPair = _probabiltyTable.OrderBy(i => i.Value).ToList();
        }

        public T Next()
        {
            if (_sortedPair == null || _sortedPair.Count == 0)
                throw new Exception("No elements added to probability calculation!");

            float totalProbability = _sortedPair.Sum(x => x.Value);
            double randomValue = _randomProvider.GetRandom() * totalProbability;
            for (var i = 0; i < _sortedPair.Count; i++)
            {
                //TO-DO:Implement an algorithm factory and decouple it from here.
                if (algorithm == WeightAlgorithm.FairBiased)
                {

                    randomValue -= _sortedPair[i].Value;
                    if (randomValue <= 0)
                        return _sortedPair[i].Key;
                }
                else
                {
                    if (randomValue < _sortedPair[i].Value)
                        return _sortedPair[i].Key;

                    randomValue -= _sortedPair[i].Value;
                }

            }
            return default; //Replace with random pick;
        }

    }
}
