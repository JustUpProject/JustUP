using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHunt : MonoBehaviour
{
    private float huntTime = 5.0f;
  
    public bool usedHunt = false;

    private void Awake()
    {

    }

    private void Update()
    {
        useHide();

        if (usedHunt)
        {
            huntTime -= Time.deltaTime;
        }
        if(huntTime < 0)
        {
            usedHunt = false;
        }
    }

    public void useHide()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            usedHunt = true;
            huntTime = 5.0f;
            Debug.Log(usedHunt);
        }

    }
}
