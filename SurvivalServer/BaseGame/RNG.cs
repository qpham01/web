using BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseGame
{
    public static class RNG
    {
        public static Random Rand = new Random();

        static Queue<int> combatResults = new Queue<int>();

        public static int CombatResultCount { get { return combatResults.Count; } }

        public static int Dice(int sides, int times = 1, int modifier = 0)
        {
            if (sides == 0)
            {
                string message = string.Format("Called Dice with invalid {0} sides", sides);
                ExceptionHandler.Handle(new ArgumentException(message));
                return 1 + modifier;
            }
            int value = modifier;
            for (int i = 0; i < times; ++i)
            {
                value += Rand.Next(0, sides) + 1;
            }
            return value;
        }

        public static int DiceRange(int min, int max)
        {
            return Rand.Next(min, max + 1);
        }

        public static int IndexDice(int sides)
        {
            return Dice(sides, 1, -1);
        }

        public static T ListChoose<T>(List<T> list)
        {
            int r = IndexDice(list.Count);
            return list[r];
        }

        public static T ArrayChoose<T>(T[] array)
        {
            int r = IndexDice(array.Length);
            return array[r];
        }

        public static int Choice(int[] frequencies)
        {
            double[] probs = GameMath.Probabilities(frequencies);
            double result = RNG.Rand.NextDouble();
            double nextProb = 0.0;
            int choice = 0;
            for (int i = 0; i < probs.Length; ++i)
            {
                nextProb += probs[i];
                if (result < nextProb)
                {
                    choice = i;
                    break;
                }
            }
            return choice;
        }

        public static List<int> Shuffle<T>(List<T> list, int swapCountMultiplier = 2)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < list.Count; ++i)
            {
                indices.Add(i);
            }
            int swapCount = swapCountMultiplier * list.Count;
            for (int i = 0; i < swapCount; ++i)
            {
                int r1 = RNG.Dice(list.Count, 1, -1);
                int r2 = RNG.Dice(list.Count, 1, -1);
                if (r1 != r2)
                {
                    int temp = indices[r1];
                    indices[r1] = indices[r2];
                    indices[r2] = temp;
                }
            }
            return indices;
        }

        public static T ListDice<T>(List<T> list)
        {
            return list[IndexDice(list.Count)];
        }

        public static float RandFloat()
        {
            return (float) Rand.NextDouble();
        }

        public static int SetSeed(int seed)
        {
            if (seed == 0)
            {
                seed = new Random().Next();
            }

            Rand = new Random(seed);
            return seed;
        }

        public static T ListDice<T>(List<T> list, T exclude, int tries = 20)
        {
            for (int i = 0; i < tries; ++i)
            {
                T result = list[IndexDice(list.Count)];
                if (!result.Equals(exclude)) return result;
            }
            return default(T);
        }

        public static int CombatDice()
        {
            if (combatResults.Count > 0)
            {
                FLog.Info("Combat dice value size {0}", combatResults.Count);
                return combatResults.Dequeue();
            }
            else return RNG.Dice(100);
        }

        public static void SetCombatDiceValues(int[] values)
        {
            combatResults.Clear();
            for (int i = 0; i < values.Length; ++i)
            {
                combatResults.Enqueue(values[i]);
            }
        }

        public static void ClearCombatResults()
        {
            combatResults.Clear();
        }
    }
}
