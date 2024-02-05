using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using stateSheild;
public class BasicMonster : MonoBehaviour
{
    BasicControler player;
    itemShield itemshield;
    itemHunt itemhunt;

    [System.Serializable]
    public enum MonsterType
    {
        AttackAble,
        ItemAttackAble,
        NotAttackAble
    }

    public MonsterType type;

    private float monsterSturnTime = 0f;

    private bool direction = false; // true = ������ x++, false = ���� x--
    [SerializeField]
    public float speedMonster;
    [SerializeField]
    private float sizeMonster;  // Move�Լ����� ����� ���꿡 �� ���� ũ��

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();

        itemshield = FindObjectOfType<itemShield>();
        if(itemshield == null )
            itemshield = GetComponent<itemShield>();

        itemhunt = FindObjectOfType<itemHunt>();
        if( itemhunt == null ) 
            itemhunt = GetComponent<itemHunt>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(monsterSturnTime <= 0f) // + item Smite
        {
            TurnMonster();
            MoveMonster();
        }
        monsterSturnTime -= Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (type == MonsterType.AttackAble)
            {
                //if (itemhunt.usedHunt)
                //{
                //    Destroy(this.gameObject);
                //    return;
                //}
                //else
                //{
                //    if (player.transform.position.y > transform.position.y)
                //    {
                //        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 3, 0);
                //        Destroy(this.gameObject);
                //        return;
                //    }
                //}
                
            }

            else if (type == MonsterType.ItemAttackAble)
            {

            }

            else if (type == MonsterType.NotAttackAble)
            {

            }

            if (itemshield.shield == StatShield.broken)
            {
                itemshield.timer = 1f;
            }
            else
            {
                player.PlayerHit();
            }
        }
    }

    protected virtual void MoveMonster()
    {
        if(direction)
        {
            this.transform.position += new Vector3(speedMonster * Time.deltaTime, 0, 0);
        }
        if (!direction)
        {
            this.transform.position -= new Vector3(speedMonster * Time.deltaTime, 0, 0);
        }

    }

    protected void Turn()
    {
        direction = !direction;
        OnDirectionChanged();
    }

    protected void TurnMonster()
    {
        Vector2 originR = transform.position + new Vector3(sizeMonster, 0, 0);
        Vector2 originL = transform.position - new Vector3(sizeMonster, 0, 0);
        Vector2 direction = Vector2.down;

        RaycastHit2D hitR = Physics2D.Raycast(originR, direction, 1);
        RaycastHit2D hitL = Physics2D.Raycast(originL, direction, 1);

        if(hitR.collider == null)
        {
            Turn();
            
        }
        if(hitL.collider == null)
        {
            Turn();
        }
        
    }

    protected virtual void OnDirectionChanged()
    {
        // This method can be overridden by derived classes
    }

    public void setSturnTime(float time) // + item Smite
    {
        monsterSturnTime = time;
        Debug.Log("sutrn" +" "+ time);
    }
}
