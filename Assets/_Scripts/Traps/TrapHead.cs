using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHead : GameObjectMovement
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Bink());
    }

    IEnumerator Bink()
    {
        animator.SetBool("blink", false);
        yield return new WaitForSeconds(5f);

        animator.SetBool("blink", true);
        yield return new WaitForSeconds(0.3f);

        StartCoroutine(Bink());
    }
}
