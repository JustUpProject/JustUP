using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chu : MonoBehaviour
{
    private bool direction = true;
    public int speed;
    public float time;
    public float tick;

    private float angle;

    void Update()
    {
        tick += Time.deltaTime;
        //angle = tick * angle;

        if (time < tick)
        {
            tick = 0;
            direction = !direction;
        }

        if (direction == true)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);


        }
        else if(direction == false)
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);

        }
    }
}
