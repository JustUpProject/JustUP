using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class chapter1_monster4 : BasicMonster
{
    public float raylength;

    protected override void Update()
    {
        base.Update(); // Call the Update method of the base class
    }

    protected override void OnDirectionChanged()
    {
        base.OnDirectionChanged(); // Call the base class method
        MoveAlongFloor(); // Call MoveAlongFloor when direction changes
    }

    private void MoveAlongFloor()
    {
        RaycastHit2D hitDown = CastRay(Vector2.down);
        RaycastHit2D hitUp = CastRay(Vector2.up);

        if (hitDown.collider != null)
        {
            if (hitDown.collider.gameObject.CompareTag("Floor"))
            {
                // Move up along the floor
                transform.position = new Vector2(transform.position.x, hitUp.point.y + transform.localScale.y);
            }
        }
        else if (hitUp.collider != null)
        {
            if (hitUp.collider.gameObject.CompareTag("Floor")) 
            {
                // Move up along the floor
                transform.position = new Vector2(transform.position.x, hitUp.point.y - transform.localScale.y);
            }
        }
    }

    private RaycastHit2D CastRay(Vector2 direction)
    {
        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, raylength);

        return hit;
    }
}   