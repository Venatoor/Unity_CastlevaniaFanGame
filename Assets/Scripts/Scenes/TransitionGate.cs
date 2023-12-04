using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionGate : MonoBehaviour
{
    public Floor next;
    public Transform transitionPointNext;

    public bool allowTransition = true;

    const float transitionResetTime = 0.8f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>() && allowTransition)
        {
            FloorManager.Instance.UpdateFloor(next);
            FloorManager.Instance.PrepareTransition(next);
            OnDoTransition(collision);
        }
    }



    //USABLE FOR OBSERVER IN TRANSITION
    public void OnDoTransition(Collider2D collision)
    {
        collision.transform.position = transitionPointNext.transform.position;
    }
}
