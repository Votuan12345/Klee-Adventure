using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isMoving) return;

        if (col.CompareTag("Player"))
        {
            isMoving = true;
            animator.SetBool("moving", isMoving);
            Invoke("ResetIsMoving", 2f);
        }
    }

    // OnTriggerEnter2D: Invoke
    private void ResetIsMoving()
    {
        isMoving = false;
        animator.SetBool("moving", isMoving);
    }
}
