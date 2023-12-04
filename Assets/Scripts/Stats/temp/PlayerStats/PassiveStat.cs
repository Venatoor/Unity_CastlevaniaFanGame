using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveStat : Stat
{
    public abstract override void DecreaseStat();

    public abstract override void IncreaseStat();

    public abstract void IncreaseMaxStat();

    public abstract void ResetStat();

    public abstract void RegenStat();
}
