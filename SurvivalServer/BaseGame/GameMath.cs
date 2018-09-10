using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseGame
{
    public static class GameMath
    {
        public static double[] Softmax(int[] values)
        {
            double[] doubles = new double[values.Length];
            for (int i = 0; i < values.Length; ++i)
            {
                doubles[i] = values[i];
            }
            return Softmax(doubles);
        }

        public static double[] Softmax(double[] values)
        {
            double[] expValues = new double[values.Length];
            double[] probabilities = new double[values.Length];

            double sum = 0;
            for (int i = 0; i < values.Length; ++i)
            {
                expValues[i] = Math.Exp(values[i]);
                sum += expValues[i];
            }
            for (int i = 0; i < values.Length; ++i)
            {
                probabilities[i] = expValues[i] / sum;
            }
            return probabilities;
        }

        public static int Sum(int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; ++i)
            {
                sum += values[i];
            }
            return sum;
        }

        public static double Sum(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; ++i)
            {
                sum += values[i];
            }
            return sum;
        }

        public static double[] Probabilities(int[] values)
        {
            double[] doubles = new double[values.Length];
            for (int i = 0; i < values.Length; ++i)
            {
                doubles[i] = values[i];
            }
            return Probabilities(doubles);
        }

        public static double[] Probabilities(double[] values)
        {
            double[] probabilities = new double[values.Length];

            double sum = GameMath.Sum(values);
            for (int i = 0; i < values.Length; ++i)
            {
                probabilities[i] = values[i] / sum;
            }
            return probabilities;
        }

        public static double Max(double[] values)
        {
            double max = double.MinValue;
            for (int i = 0; i < values.Length; ++i)
            {
                max = Math.Max(max, values[i]);
            }
            return max;
        }

        public static int Max(int[] values)
        {
            int max = int.MinValue;
            for (int i = 0; i < values.Length; ++i)
            {
                max = Math.Max(max, values[i]);
            }
            return max;
        }

        public static double Min(double[] values)
        {
            double min = double.MaxValue;
            for (int i = 0; i < values.Length; ++i)
            {
                min = Math.Min(min, values[i]);
            }
            return min;
        }

        public static int Min(int[] values)
        {
            int min = int.MaxValue;
            for (int i = 0; i < values.Length; ++i)
            {
                min = Math.Min(min, values[i]);
            }
            return min;
        }

    }
}
