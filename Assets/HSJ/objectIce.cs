using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.UI.Image;

public class objectIce : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    private BasicControler player;

    private float originSlide;
    private float changedSlide;
    private bool checkPlayer;
    private float moveSpeedPlayer;
    private float changedMoveSpeed;

    public bool isWall = true; //wall형태로 배치할려면 true체크표시 아닐시 false체크해제
    public bool dir=false; //false = L배치 true =R배치
    public float rayLength;
    // Start is called before the first frame update

    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
    }

    void Start()
    {
        originSlide = player.slidingSpeed;
        changedSlide = 1.0f;
        moveSpeedPlayer = player.moveSpeed;
        changedMoveSpeed = player.moveSpeed + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWall)
        {
            if (dir)
            {
                checkPlayer = PlayerCheckLeft();
                if (checkPlayer)
                    player.slidingSpeed = changedSlide;
                else
                    player.slidingSpeed = originSlide;
            }
            else
            {
                checkPlayer = PlayerCheckRight();
                if (checkPlayer)
                    player.slidingSpeed = changedSlide;
                else
                    player.slidingSpeed = originSlide;
            }
        }
        else 
        {
            checkPlayer = PlayerCheckVertical();
            if (checkPlayer)
            {
                player.moveSpeed = changedMoveSpeed;
            }
            else
            {
                player.moveSpeed = moveSpeedPlayer;
            }
        }      
    }
    private bool PlayerCheckRight()
    {
        Vector2 origin = this.transform.position;
        Vector2 size = this.transform.localScale;

        Vector2 direction = Vector2.right;
        RaycastHit2D hits = Physics2D.BoxCast(origin, size, 0, direction, rayLength, playerMask);
        if (hits.collider != null)
        {
            if (hits.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private bool PlayerCheckLeft()
    {
        Vector2 origin = this.transform.position;
        Vector2 size = this.transform.localScale;

        Vector2 direction = Vector2.left;
        RaycastHit2D hits = Physics2D.BoxCast(origin, size, 0, direction, rayLength, playerMask);
        if (hits.collider != null)
        {
            if (hits.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private bool PlayerCheckVertical()
    {
        Vector2 origin = this.transform.position;

        Vector2 direction = Vector2.up;
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, rayLength, playerMask);

        foreach (RaycastHit2D hit in hits)
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        return false;
    }
}
