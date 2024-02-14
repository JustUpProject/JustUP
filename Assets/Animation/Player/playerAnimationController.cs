using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{
    public Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
