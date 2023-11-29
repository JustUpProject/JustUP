using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chapter_monster5 : BasicMonster
{
    [SerializeField] private float attackAble;
    [SerializeField] private bool directionRight;
    public bool DirectionRight { get => directionRight; }  // object Direction right == 1, left == 0
    private GameObject fireball;


    private void Start()
    {
        fireball = Resources.Load<GameObject>("Prefab/FireBall");
        StartCoroutine(AttactAble());

    }
    IEnumerator AttactAble()
    {
        yield return new WaitForSeconds(attackAble);

        Attack();

        yield return StartCoroutine(AttactAble());
    }

    private void Attack()
    {
        if(DirectionRight)
        {
            Debug.Log("오른쪽 발사");
            Instantiate(fireball, transform.position + new Vector3(-0.3f, 0, 0), transform.rotation);

        }
        else
        {
            Debug.Log("왼쪽 발사");
            Instantiate(fireball, transform.position + new Vector3(0.3f, 0, 0), transform.rotation);
        }
    }
}
