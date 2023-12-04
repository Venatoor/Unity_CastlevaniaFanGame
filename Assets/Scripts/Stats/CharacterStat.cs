using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStat 
{
    public float baseValue;

    protected float lastBaseValue = float.MinValue;

    public CharacterStatType characterStatType;

    protected readonly List<StatModifier> statModifiers;

    protected float _value;

    protected bool isDirty = true;


    public CharacterStat()
    {
        List<StatModifier> _statModifiers = new List<StatModifier>();
        statModifiers = _statModifiers;
    }

    public CharacterStat(float baseValue) : this()
    {
        this.baseValue = baseValue;
    }

    public virtual float Value
    {
        get
        {
            if ( isDirty || lastBaseValue != baseValue)
            {
                lastBaseValue = baseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }




    public virtual void AddModifier(StatModifier statModifier) 
    {
        isDirty = true;
        statModifiers.Add(statModifier);
        statModifiers.Sort(CompareModifierOrder);
    }

    public virtual bool RemoveModifier(StatModifier statModifier)
    {
        if ( statModifiers.Remove(statModifier))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if ( a.order < b.order)
        {
            return -1;
        }
        else if ( a.order > b.order )
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = baseValue;
        float sumPercentAdd = 0;

        for ( int i = 0; i < statModifiers.Count; i++ )
        {
            StatModifier mod = statModifiers[i];
            if (mod.statModType == StatModType.Flat)
            {
                finalValue += mod.value;
            }
            else if (mod.statModType == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.value;
                if ( i+1 > statModifiers.Count || statModifiers[i+1].statModType != StatModType.PercentAdd )
                {
                    finalValue *= 1 + mod.value;
                    sumPercentAdd = 0;
                }
            }
            else if  (mod.statModType == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.value;
            }
        }
        return (float)System.Math.Round(finalValue, 4);
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }
}


public enum CharacterStatType
{
    DefenseStat,
    ActiveStat,
    PassiveStat,
}

public enum StatModType
{
    Flat= 100, PercentAdd= 200, PercentMult= 300,
}
