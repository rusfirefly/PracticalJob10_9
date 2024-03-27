using System;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static event Action<int> UsePoint;
    [SerializeField] private int _pointValue;

    public void AddPoint()
    {
        UsePoint?.Invoke(_pointValue);
    }
}
