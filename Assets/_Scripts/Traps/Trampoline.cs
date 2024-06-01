using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private LayerMask targetLayer;

    private Animator animator;
    private GameObject target;
    private BoxCollider2D boxCollider2D;

    private bool isJump = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(isJump == false)
        {
            CheckPlayer();
        }
    }

    private void CheckPlayer()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.up, 0.1f, targetLayer);
        if(hit.collider != null)
        {
            target = hit.collider.gameObject;
            isJump = true;
            animator.SetBool("Jump", isJump);
            Invoke("ResetJumpAnimation", 1f);
        }
    }

    // call from animation
    private void Jump()
    {
        if (isJump == false) return;

        if (target != null && target.GetComponent<Rigidbody2D>())
        {
            target.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            target = null;
        }
    }

    // CheckPlayer: invoke
    private void ResetJumpAnimation()
    {
        isJump = false;
        animator.SetBool("Jump", isJump);
    }
}

