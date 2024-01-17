using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatHook
{
    choice,
    shooting,
    fix
}
public class Item_hook : MonoBehaviour
{
    private StatHook hook;
    private Transform arrow;
    [SerializeField] private bool direction;
    [SerializeField] private int speed;
    [SerializeField] private float angle;
    // Start is called before the first frame update
    void Start()
    {
        direction = true;
        arrow = transform.Find("Arrow");
        if (arrow == null) Debug.Log("¸øÃ£À½");

       hook = StatHook.choice;
    }

    // Update is called once per frame
    void Update()
    {
        if (hook == StatHook.choice)
        {
            if (Input.GetKeyUp(KeyCode.H))
            {
                GetComponent<SpriteRenderer>().enabled = true;
                arrow.gameObject.SetActive(true);
                hook = StatHook.shooting;
            }
        }
        
        else if (hook == StatHook.shooting)
        {
            if (arrow.transform.rotation.z > angle)
            {
                direction = false;
            }
            if (arrow.transform.rotation.z < -angle)
            {
                direction = true;
            }
        }

       else if(hook == StatHook.fix)
        {

        }
    }

    private void FixedUpdate()
    {
        transform.position = BasicControler.Instance.transform.position + new Vector3(0, 0.5f, 0);
        if (hook == StatHook.shooting)
        {
            if (direction)
            {
                arrow.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (!direction)
            {
                arrow.transform.Rotate(Vector3.back * speed * Time.deltaTime);
            }
        }
        
    }
}
