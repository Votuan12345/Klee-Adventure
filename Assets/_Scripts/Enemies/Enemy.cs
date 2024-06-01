using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float range;
    [SerializeField] protected LayerMask targetLayer;
    
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Vector2 direction;
    
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Move()
    {
        if(rb != null)
        {
            rb.velocity = direction * moveSpeed;
        }
    }

    protected virtual bool CheckTarget_OnLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, targetLayer);
        if (hit.collider != null) direction = Vector2.left;

        return hit.collider != null;
    }

    protected virtual bool CheckTarget_OnRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, targetLayer);
        if (hit.collider != null) direction = Vector2.right;

        return hit.collider != null;
    }

    protected virtual void Attack()
    {

    }
}
