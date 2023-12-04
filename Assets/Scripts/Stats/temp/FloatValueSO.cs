using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValueSO : ScriptableObject
{
    [SerializeField]
    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChange?.Invoke(_value);
        }
    }
    public event System.Action<float> OnValueChange;
}
