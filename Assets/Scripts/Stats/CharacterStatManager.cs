using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatManager : MonoBehaviour
{
    public event System.Action<CharacterAttribute, float> OnAttributeValueChange;

    public CharacterStat PhysicalDefense;
    public CharacterStat MagicalDefense;

    public CharacterStat PhysicalAttack;
    public CharacterStat MagicalAttack;

    public CharacterAttribute Strength;
    public CharacterAttribute Constitution;
    public CharacterAttribute Intelligence;
    public CharacterAttribute Mind;


    private void Start()
    {
        ManageStats();
    }

    private void ManageStats()
    {
        Strength.AddLink(1, PhysicalAttack);

        Constitution.AddLink(2, PhysicalDefense);

        Intelligence.AddLink(1, MagicalAttack);

        Mind.AddLink(2, MagicalDefense);
    }

    public float LinearMultiplicationStats(float y, float x, float alpha)
    {
        y = alpha * x;

        return y;

    }

    public float GetAttributeValue(CharacterAttribute attribute)
    {
        return attribute.Value;
    }


    public void AddAttributeLinksValue(CharacterAttribute attribute) 
    {
        float x = attribute.Value;

        List<CharacterAttribute.Link> links = attribute.GetLinks();

        foreach ( CharacterAttribute.Link link in links)
        {
            float alpha = link.GetLinkValue();
            CharacterStat linkedStat = link.GetLinkedStat();

            //Do a substraction modifier using ancient preserved value
            linkedStat.RemoveModifier(new StatModifier(link.GetPreservedValue(), StatModType.Flat));
            linkedStat.AddModifier(new StatModifier(alpha * x, StatModType.Flat)); // NOT WORKING
            link.SetPreservedValue(alpha * x);
        }
    }


    
}


