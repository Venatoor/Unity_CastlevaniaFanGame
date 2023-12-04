using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected Character character;
    protected GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }


    protected virtual void Initialization()
    {
        player = FindObjectOfType<Character>().gameObject;
        character = player.GetComponent<Character>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
