using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : GameManager
{
    protected GameManager gameManager;

    public static Managers instance;


    [Header("Managers ")]

    [HideInInspector]
    public FloorManager floorManager;

    // Start is called before the first frame update
    protected override void Initialization()
    {
        base.Initialization();
        gameManager = FindObjectOfType<GameManager>();
    }
}
