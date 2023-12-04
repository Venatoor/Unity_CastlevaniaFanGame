using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveStat : Stat
{
    public abstract override void DecreaseStat();

    public abstract override void IncreaseStat();
}
