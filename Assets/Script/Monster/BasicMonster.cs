using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BasicMonster : MonoBehaviour
{
    BasicControler player;


    [System.Serializable]
    public enum MonsterType
    {
        AttackAble,
        ItemAttackAble,
        NotAttackAble
    }

    public MonsterType type;
    private bool direction = false; // true = 오른쪽 x++, false = 왼쪽 x--
    [SerializeField]
    public float speedMonster;
    [SerializeField]
    private float sizeMonster;  // Move함수에서 사용할 연산에 들어갈 몬스터 크기

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        TurnMonster();
        MoveMonster();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (type == MonsterType.AttackAble)
            {
                if (player.transform.position.y > transform.position.y)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 3, 0);
                    Destroy(this.gameObject);
                    return;
                }
            }

            else if (type == MonsterType.ItemAttackAble)
            {

            }

            else if (type == MonsterType.NotAttackAble)
            {

            }

            player.PlayerHit();
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

}
