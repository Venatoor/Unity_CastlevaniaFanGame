using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeArmorAxe : MonoBehaviour
{
    Transform destination;
    float speed;

    float distance;
    public float time;

    float currentTime;
    float approximatedTime;

    private void Start()
    {
        distance = Vector2.Distance(transform.position, destination.position);
        time = distance / speed;
        
    }
    private void Update()
    {

        if ( currentTime <= time )
        {
            currentTime += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(TranslationMovement.Instance.DoTranslationX(transform, speed , new Vector2(-1, 0), 1f));
        }
    }

    public void SetAxeDestination(Transform transform)
    {
        destination = transform;
    }

    public void SetAxeSpeed(float speed)
    {
        this.speed = speed;
    }
}
