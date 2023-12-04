using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attribute : Stat

{
    public event Action<Attribute> OnAttributeChanged;

    public List<ActiveStat> listOfConcernedStats;

    public abstract override  void DecreaseStat();

    public abstract override void IncreaseStat(); 

    public class Link {

        ActiveStat linkedStat;
        Attribute currentAttribute;

        public Link(ActiveStat linkedStat, Attribute currentAttribute)
        {
            this.linkedStat = linkedStat;
            this.currentAttribute = currentAttribute;
        }

    }

}
