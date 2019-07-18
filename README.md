# Weighted Randomizer for Unity
Allows you to get generic biased random selections depending on provided weight.

**Best part of this randomizer is, it doesn't require to provide 100% total. 
It auto-calculates weights regarding to your weights.**

So you can pass  _Add->80%-Tremors _Add->70%-Zombies_ in the same total.

## Usage
Simple example:
```c#
WeightedRandom<Monsters> rnd = new WeightedRandom<Monsters>();
rnd.Add(new Ghost(),0.5f);
rnd.Add(new Zombie(),0.3f);

rnd.Next(); //This will return a biased random result.
```

## Alternative parameters
WeightedRandom uses _System.Random_ and _FairBiased_ algorithm *by default.*

**You can choose custom options on the constructor.**

### WeightAlgorithm
There are two algorithms right now.
- *UnfairBiased:* Provides a larger probability scale but results can be less predictable.
- *FairBiased:* Provides a steady bias and therefor more predictable results.

### Weight Providers
Weight providers are basically random api's which have provided by Unity and C#(System) libraries.
- *SystemRandomProvider:* Uses System.Random implementation
- *UnityEngineRandomProvider:* Uses UnityEngine.Random.Range implementation
- *UnityMathematicsRandomProvider:* Uses Unity's new SIMD math library with Unity.Random implementation

## TO-DO
- AddRange for multiple queries at once.
- GetInstance() implementation on other providers with _T where:class_
