using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBlocker : MonoBehaviour
{
    protected Character character;
    protected GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Character>().gameObject;
        character = GetComponent<Character>();
        Physics2D.IgnoreCollision(character.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
