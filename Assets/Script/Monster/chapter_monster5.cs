using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chapter_monster5 : BasicMonster
{
    [SerializeField] private float attackAble;
    [SerializeField] private bool directionRight;
    [SerializeField] private GameObject AttackPrefab;
    public bool DirectionRight { get => directionRight; }  // object Direction right == 1, left == 0
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttactAble());

    }
    IEnumerator AttactAble()
    {

        yield return new WaitForSeconds(attackAble);

        StartCoroutine(Attack());

        yield return new WaitForSeconds(1.5f);

        animator.SetBool("Attack", false);

        yield return StartCoroutine(AttactAble());
    }

    IEnumerator Attack()
    {
        Debug.Log("발사");
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1.6f);

        if (DirectionRight)
        {
            Debug.Log("오른쪽 발사");
            Instantiate(AttackPrefab, transform.position + new Vector3(-0.3f, 0, 0), transform.rotation);

        }
        else
        {
            Debug.Log("왼쪽 발사");
            Instantiate(AttackPrefab, transform.position + new Vector3(0.3f, 0, 0), transform.rotation);
        }
    }
}
