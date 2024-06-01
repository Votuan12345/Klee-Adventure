using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private bool isFalling = false;

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isFalling) return;

        if (col.gameObject.CompareTag("Player"))
        {
            isFalling = true;
            StartCoroutine(FallingCoroutine());
        }
    }

    private void Falling()
    {
        rb.velocity = Vector2.down * 3f;
    }

    IEnumerator FallingCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        animator.SetTrigger("falling");
        boxCollider.enabled = false;
        Falling();

        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

}
