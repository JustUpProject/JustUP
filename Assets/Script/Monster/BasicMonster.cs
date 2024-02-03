using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public enum MonsterType
{
    AttackAble,
    ItemAttackAble,
    NotAttackAble
}

public enum State
{
    Move,
    Turn,
    Attack
}

public class BasicMonster : MonoBehaviour
{
    private BasicControler player;
    private itemShield itemshield;
    private itemHunt itemhide;

    public MonsterType type;
    public State state;

    private float monsterSturnTime = 0f;

    private bool direction = false; // true = ������ x++, false = ���� x--
    [SerializeField]
    public float speedMonster;
    [SerializeField]
    private float sizeMonster;  // Move�Լ����� ����� ���꿡 �� ���� ũ��

    // Start is called before the first frame update
    protected void Start()
    {
        player = BasicControler.Instance;

        itemshield = FindObjectOfType<itemShield>();
        if(itemshield == null )
            itemshield = GetComponent<itemShield>();
        itemhide = FindObjectOfType<itemHunt>();
        if( itemhide == null ) 
            itemhide = GetComponent<itemHunt>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        monsterSturnTime -= Time.deltaTime;

        if (monsterSturnTime <= 0f) // + item Smite
        {
            if(state == State.Move)
            {
                MoveMonster();
            }
            else if (state == State.Turn) 
            {
                Turn();
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (type == MonsterType.AttackAble)
            {
                //if (itemhide.usedHunt)
                //{
                //    Destroy(this.gameObject);
                //    return;
                //}

                if (player.transform.position.y - 0.3f> transform.position.y + 0.2f)
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

            if(itemshield.onShield == false)
            {
                player.PlayerHit();
            }
            else
            {
                itemshield.onShield = false;
            }
        }
    }

    protected virtual void MoveMonster()
    {
        TurnMonster();
        if (transform.localScale.x > 0)
            this.transform.position -= new Vector3(speedMonster * Time.deltaTime, 0, 0);
        else if (transform.localScale.x < 0)
            this.transform.position += new Vector3(speedMonster * Time.deltaTime, 0, 0);
    }

    protected void Turn()
    {
        Debug.Log("��");
        state = State.Move;
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        OnDirectionChanged();
    }

    protected void TurnMonster()
    {
        
        if(transform.localScale.x > 0)
        {

            Vector2 originL = transform.position - new Vector3(sizeMonster, 0, 0);
            Vector2 directionDown = Vector2.down;

            Vector2 origin = transform.position;
            Vector2 direction = Vector2.left;

            RaycastHit2D hit = Physics2D.Raycast(originL, directionDown, 1);
            RaycastHit2D hitFoward = Physics2D.Raycast(origin, direction);

            Debug.Log(hitFoward);

            if (hit.collider == null || hitFoward.collider.gameObject.CompareTag("Wall"))
            {
                Debug.Log(hitFoward.collider);
                Debug.Log("��");
                Turn();
            }
        }
        else if(transform.localScale.x < 0)
        {
            Vector2 originR = transform.position + new Vector3(sizeMonster, 0, 0);
            Vector2 directionDown = Vector2.down;

            Vector2 origin = transform.position;
            Vector2 direction = Vector2.right;

            RaycastHit2D hit = Physics2D.Raycast(originR, directionDown, 1);
            RaycastHit2D hitFoward = Physics2D.Raycast(origin, direction, 1);

            if (hit.collider == null || hitFoward.collider.CompareTag("Wall"))
            {
                Debug.Log("��");
                Turn();
            }
        }
    }

    protected virtual void OnDirectionChanged()
    {
        // This method can be overridden by derived classes
    }

    public void setSturnTime(float time) // + item Smite
    {
        monsterSturnTime = time;
    }
}
