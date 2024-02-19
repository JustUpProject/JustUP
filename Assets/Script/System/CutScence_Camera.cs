using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScence_Camera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 57.0f)
            transform.position += new Vector3(0, 2.0f * Time.deltaTime, 0);
    }
}
