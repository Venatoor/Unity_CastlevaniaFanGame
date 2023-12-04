using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [HideInInspector]
    private float iFrame;
    private Character character;
    private Material originalMaterial;

    //FOR TESTING ONLY
    [SerializeField]
    private Material alteredMaterial;

    private void Update()
    {
        DamageEffect();
    }

    private void Start()
    {
        originalMaterial = GetComponent<SpriteRenderer>().material;
    }

    public void DamageEffect()
    {
        if ( gameObject.GetComponent<Character>().isHit )
        {
            //FOR TESTING ONLY 
            GetComponent<SpriteRenderer>().material = alteredMaterial;
            StartCoroutine(EndRenderingEffect());
        }
    }
    public IEnumerator EndRenderingEffect()
    {
        yield return new WaitForSeconds(iFrame);
        gameObject.GetComponent<Character>().isHit = false;
        GetComponent<SpriteRenderer>().material = originalMaterial;
    }
}
