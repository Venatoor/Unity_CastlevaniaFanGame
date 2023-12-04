using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkInferno : MonoBehaviour, ICastableAbility
{
    public List<Transform> darkInfernoSpots;
    public Transform darkInfernoPrefab;

    public Transform launcher;
    public Transform temp;

    public int darkInfernoCount;
    public float darkInfernoDurationTime;
    public float intervalTimeSpawn;

 


    // REDUNDANCY BETWEEN HELLFIRE AND DARK INFERNO 
    public void ExecuteAbility()
    {
        if ( Input.GetKeyDown(KeyCode.Keypad5))
        {
            
            StartCoroutine(DarkInfernoLaunch());
        }
    }

    public IEnumerator DarkInfernoLaunch()
    {
       for (int i = 0; i < darkInfernoCount; i++)
          {

            Invoke("DarkInfernoLaunch", intervalTimeSpawn);
            Transform spawnable = Instantiate(darkInfernoPrefab, darkInfernoSpots[0].transform.position, transform.root.GetChild(0).rotation);
            spawnable.gameObject.AddComponent<ObjectDestroyer>();
            spawnable.GetComponent<ObjectDestroyer>().secondsToDestroy = darkInfernoDurationTime;
            Permute();
            yield return new WaitForSeconds(intervalTimeSpawn);

        }

    }

    //FOR TESTING PURPOSES 
    // Start is called before the first frame update
    void Start()
    {
        darkInfernoDurationTime = 1f;
        darkInfernoCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteAbility();
    }

    // ALGORITHMIC REDUNDANCY FOR PERMUTE 
    private void Permute()
    {
        temp = darkInfernoSpots[0];
        darkInfernoSpots[0] = darkInfernoSpots[1];
        darkInfernoSpots[1] = temp;
        launcher = darkInfernoSpots[0].transform;
    }
}
