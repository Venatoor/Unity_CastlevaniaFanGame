using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : Character
{
    protected Character character;
    public bool dashUnlocked;
    public bool doubleJumpUnlocked;
    // Start is called before the first frame update
    protected override void Initialization()
    {
        base.Initialization();
        character = GetComponent<Character>();
        
    }
}
