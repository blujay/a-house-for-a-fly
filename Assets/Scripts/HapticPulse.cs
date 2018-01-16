﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HapticPulse : ScriptableObject {
    public AnimationCurve shape;
    public float duration;

    public int Length
    {
        get
        {
            return Mathf.RoundToInt(320 * duration); ;
        }
    }

    public byte[] GetBytes()
    {
        int len = Length;
        byte[] data = new byte[len];

        for (int i = 0; i < len; i++)
        {
            float t = 1f * i / (len - 1);
            data[i] = (byte)Mathf.RoundToInt(255 * shape.Evaluate(t));
        }

        return data;
    }

}
