using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{

    //On Input Do Effect attached to it 

    public SoulSteal castableAbility1;
    public ICastableAbility castableAbility2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Keypad8))
        {
            castableAbility1.ExecuteAbility();
        }
    }
}
