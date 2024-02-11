using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicControler : MonoBehaviour
{
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private LayerMask wallMask;
    SlidingPartical partical;

    object_wind_sub objectwind;

    [SerializeField]
    private bool direction = false; //true = ���������� �̵�, false = �������� �̵�

    GameData gameData;

    private bool firstJumpAble = true; //�÷��̾��� ���� ���� ���� üũ
    private bool doubleJumpAble = true; //�÷��̾��� ���� ���� ���� ���� üũ
    private bool isSlidingOnWall = false; //�÷��̾ ���� ����ִ��� ���� üũ
    private bool velocityInit = true;

    public float rayLength;
    public float rayLengthFloor;
    public float moveSpeed;
    public float jumpPower;
    public float slidingSpeed; //�����̵����� �������� �ӵ�
    
    private int playerHealth;
    public int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    Vector3 wallPos; //�浹�� ���� ��ġ ����

    private static BasicControler instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static BasicControler Instance
    {
        get
        {
            return instance;
        }
    }

    void Start()
    {
        playerHealth = 3;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
        partical = GetComponent<SlidingPartical>();

        //if(partical == null)
        //    partical = this.AddComponent<SlidingPartical>();

        transform.position = gameData.SavePoint;
        objectwind = FindObjectOfType<object_wind_sub>();
    }

    void Update()
    {
        isSlidingOnWall = false;
        WallCheck();  
        FloorCheck();
        JumpPlayer();


        if ((isSlidingOnWall == true && FloorCheck() == false))
        {
            return;
        }
        velocityInit = true;
        MovePlayer();
    }

    

    private void MovePlayer()
    {
        if (direction == true)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            
        }
        else if (direction == false) //변경사항 &&FloorCheck()
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            
        }
    }

    private void JumpPlayer()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && doubleJumpAble == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            isSlidingOnWall = false;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);

            if (firstJumpAble == false)
            {
                doubleJumpAble = false;
            }
            firstJumpAble = false;

        }
    }

    private void WallSliding()
    {
        if(velocityInit) { GetComponent<Rigidbody2D>().velocity = Vector3.zero; }

        velocityInit = false;
        isSlidingOnWall = true;

        GetComponent<Rigidbody2D>().gravityScale = slidingSpeed;
        if (partical.isParticleCycle == true)
            partical.SpwanParticle();

    }

    public void InitJump()
    {
        firstJumpAble = true;
        doubleJumpAble = true;
    }


    public bool FloorCheck()
    {

        Vector2 origin = this.transform.position + new Vector3(0, -0.35f, 0);
        Vector2 direction = Vector2.down;

        RaycastHit2D[] hits = Physics2D.BoxCastAll(origin, new Vector3(0.3f, 0.01f, 0), 0.0f, direction, rayLengthFloor);
        

        foreach (RaycastHit2D hit in hits)
        {
            
            if (hit.collider.CompareTag("Floor"))
            {
                InitJump();
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Vector2 origin = this.transform.position + new Vector3(0, -0.37f, 0);
        Vector2 direction = Vector2.down;

        Gizmos.color = Color.yellow;
        RaycastHit2D[] hits = Physics2D.BoxCastAll(origin, new Vector3(0.5f, 0.01f, 0), 0.0f, direction, rayLengthFloor);

        foreach(RaycastHit2D hit in hits)
        {
            Gizmos.DrawCube(hit.point, new Vector3(0.5f, 0.01f, 0));
        }
    }

    public int WallCheck()
    {
        Vector2 origin = this.transform.position;

        Vector2 direction = Vector2.right;
        RaycastHit2D hits = Physics2D.Raycast(origin, direction, rayLength, wallMask);

        if(hits.collider != null)
        {
            if (hits.collider.CompareTag("Wall"))
            {
                InitJump();
                
                wallPos = hits.collider.transform.position;
                Trun(wallPos);
                WallSliding();

                return 1;

            }

        }
        direction = Vector2.left;

        hits = Physics2D.Raycast(origin, direction, rayLength, wallMask);

        if(hits.collider != null)
        {
            if (hits.collider.CompareTag("Wall"))
            {
                InitJump();
                
                wallPos = hits.collider.transform.position;
                Trun(wallPos);
                WallSliding();
            }
        }

        return 0;
    }

    private void Trun(Vector3 wallPos)
    {
        if (wallPos.x < transform.position.x)
        {
            this.direction = true;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (wallPos.x > transform.position.x)
        {
            this.direction = false;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void PlayerHit()
    {
        playerHealth -= 1;
        PlayerDie();
    }

    private void PlayerDie()
    {
        if(playerHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void SetDir()
    {
       direction = !direction;
    }
    public bool getPrivateDir()
    {
        return direction;
    }
}
