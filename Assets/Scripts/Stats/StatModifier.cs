using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier
{
    public readonly float  value;
    public  readonly StatModType statModType;
    public readonly int order;
    public readonly object source;

    public StatModifier(float value, StatModType statModType, int order, object source)
    {
        this.value = value;
        this.statModType = statModType;
        this.order = order;
        this.source = source;
    }
    // Start is called before the first frame update


    public StatModifier(float value, StatModType statModType) : this(value, statModType, (int)statModType, null) { }
    public StatModifier(float value, StatModType statModType, int order) : this(value, statModType, order, null) { }

    public StatModifier(float value, StatModType statModType, object source) : this(value, statModType, (int)statModType, source) { }
}
