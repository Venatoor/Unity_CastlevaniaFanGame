using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    protected Slider slider;

    [SerializeField]
    private Image sliderImage;

    [SerializeField]
    private FloatValueSO floatValue;

    void Start()
    {
        slider = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    public virtual void SetMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    public virtual void SetHealth(int health)
    {
        slider.value = health;
    }

    private void OnEnable()
    {
        floatValue.OnValueChange += SetValue;
    }

    private void OnDisable()
    {
        floatValue.OnValueChange -= SetValue;
    }

    private void SetValue(float currentValue)
    {
        slider.value = Mathf.Clamp01(currentValue);
    }
}
