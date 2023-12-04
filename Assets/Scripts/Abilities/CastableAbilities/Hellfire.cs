using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellfire : MonoBehaviour, ICastableAbility
{
    public List<GameObject> hellfireSpots;
    public Transform hellfirePrefab;

    // temp value
    public float hellfireDurationTime;

    public float hellfireProjectileSpeed;


    //TEMP
    public Transform abilityContainer;
    // This is actual temp code

    private void Start()
    {
        hellfireDurationTime = 1f;
    }
    public void ExecuteAbility()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < hellfireSpots.Count; i++)
            {
                Transform spawnable =  Instantiate(hellfirePrefab, hellfireSpots[i].transform.position, transform.root.GetChild(0).rotation );
                spawnable.gameObject.AddComponent<ObjectDestroyer>();
                spawnable.GetComponent<ObjectDestroyer>().secondsToDestroy = hellfireDurationTime;
                //spawnable.SetParent(abilityContainer);
                
                if ( transform.root.GetChild(0).rotation.y == 0 )
                StartCoroutine(TranslationMovement.Instance.DoTranslationX(spawnable,hellfireProjectileSpeed, new Vector2(1,0), 500f));

                else
                StartCoroutine(TranslationMovement.Instance.DoTranslationX(spawnable, hellfireProjectileSpeed, new Vector2(-1, 0), 500f));

            }
        }
    }

    //REDUNDANCE OF CONTAINERS BETWEEN ALL PROJECTILES ! TO FIX LATER

    //TO ADD PROJECTILE COMPONENT -> PROJECTILE COMPONENT ADD ITSELF THE PROJECTILE MOVEMENT COMPONENT

    //PERHAPS BETTER TO INHERIT FROM ABILITY RATHER THAN INTERFACE

    // Update is called once per frame
    void Update()
    {
        ExecuteAbility();
    }
}
