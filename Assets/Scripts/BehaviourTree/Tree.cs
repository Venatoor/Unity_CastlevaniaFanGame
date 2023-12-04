using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tree : MonoBehaviour
{
    private Node root = null;

    public FieldOfView fov;
    public Steering[] steerings;
    public BattleSystem battleSystem;
    // Start is called before the first frame update
    public virtual void Start()
    {
        root = SetupTree();
        steerings = GetComponents<Steering>();
        fov = GetComponent<FieldOfView>();
        battleSystem = GetComponent<BattleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        if ( root != null )
        {

            root.Evaluate();
        }
    }

    public abstract Node SetupTree();


    public void DesactivateSteerings()
    {
        foreach (Steering steering in steerings)
        {
            steering.DesactivateSteering();
        }
    }

    public Steering[] GetSteerings()
    {
        return steerings;
    }
}
