using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    [SerializeField]
    protected Transform player;
    [SerializeField]
    protected float xUIAdjust;
    [SerializeField]
    protected float yUIAdjust;
    [SerializeField]
    protected float zUIAdjust;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x + xUIAdjust, player.position.y + yUIAdjust, zUIAdjust);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + xUIAdjust, player.position.y + yUIAdjust, zUIAdjust);
    }
}
