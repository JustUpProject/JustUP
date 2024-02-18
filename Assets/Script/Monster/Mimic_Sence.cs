using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic_Sence : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            animator.SetBool("Mimic_Sence", true);
    }
}
