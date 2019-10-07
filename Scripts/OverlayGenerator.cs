using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayGenerator
{
    public static float[,] GenerateOverlayMap(int size)
    {


        float[,] map = new float[size, size];
        float[,] map2 = new float[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                float x = i / (float)size;
                float y = j / (float)size * 2 - 1;

                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                map[i, j] = Evaluate(value);
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                float x = i / (float)size - 1;
                float y = j / (float)size * 2 - 1;

                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                map2[i, j] = Evaluate2(value);
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                float x = i / size;

                float y = j / size;

                map[i, j] = map[i, j] - 0.2f + map2[i, j];
            }
        }

        return map;
    }

    static float Evaluate(float value)
    {

        float a = 1f;
        float b = 4f;

        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
    }

    static float Evaluate2(float value)
    {

        float a = 5f;
        float b = 10f;

        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
    }
}
