using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    protected Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    public virtual void SetNextLevelExp(int exp)
    {
        slider.maxValue = exp;
    }

    public virtual void SetExperience(int exp)
    {
        slider.value = exp;
    }
}
