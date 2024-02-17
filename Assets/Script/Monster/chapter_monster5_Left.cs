using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chapter_monster5_Left : BasicMonster
{
    [SerializeField] private float attackAble;
    [SerializeField] private bool directionRight;
    [SerializeField] private GameObject AttackPrefab;
    private UseingItem item;
    public bool DirectionRight { get => directionRight; }  // object Direction right == 1, left == 0
    private Animator animator;


    protected override void Start()
    {
        base.Start();
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
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1.6f);

        if (directionRight)
        {
            Instantiate(AttackPrefab, transform.position + new Vector3(-0.3f, 0, 0), transform.rotation);

        }
        else
        {
            Instantiate(AttackPrefab, transform.position + new Vector3(0.3f, 0, 0), transform.rotation);
        }
    }
}