using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePlatform : Platform
{

    public float delayTime;
    public float repopTime;

    public Collider2D col;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("OnTouch", delayTime);
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
    }

    public override void OnTouch()
    {
        
        gameObject.SetActive(false);
        Invoke("ReactivatePlatform", repopTime);
    }

    public  void ReactivatePlatform()
    {
        gameObject.SetActive(true);
    }


}
