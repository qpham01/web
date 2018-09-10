using System;

namespace BaseModel
{
    public class BaseMath
    {
        public static int Clamp(int value, int minValue, int maxValue = int.MaxValue)
        {
            if (value < minValue) value = minValue;
            if (value > maxValue) value = maxValue;
            return value;
        }

        public static float ClampF(float value, float minValue, float maxValue = float.MaxValue)
        {
            if (value < minValue) value = minValue;
            if (value > maxValue) value = maxValue;
            return value;
        }

        public static float ClampDegree(float degree)
        {
            while (degree < 0) degree += 360.0f;
            while (degree >= 360.0f) degree -= 360.0f;
            return degree;
        }

    }
}
