using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterAttribute : CharacterStat
{
    private List<Link> links;

    public class Link 
    {
        private float preservedValue;
        private float linkValue;
        public CharacterStat linkedStat;

        public Link(float linkValue, CharacterStat linkedStat)
        {
            this.linkValue = linkValue;
            this.linkedStat = linkedStat;
            preservedValue = 0f;
        }

        public float GetLinkValue()
        {
            return linkValue;
        }

        public CharacterStat GetLinkedStat()
        {
            return linkedStat;
        }

        public float GetPreservedValue()
        {
            return preservedValue;
        }

        public void SetPreservedValue(float preservedValue)
        {
            this.preservedValue = preservedValue;
        }
    }


    public void AddLink(float linkValue, CharacterStat linkedStat)
    {
        links.Add(new Link(linkValue, linkedStat));
    }


    public List<Link> GetLinks()
    {
        return links;
    }
    // an attribute has more elements than a simple stat with it being linked to a stat, or stats and for each do a proper distribution 
    // Start is called before the first frame update
    
    
    
}
