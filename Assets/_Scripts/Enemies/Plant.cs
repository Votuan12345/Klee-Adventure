using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Plant : Enemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointShooting;
    [SerializeField] private float waitingTime;
    [SerializeField] private bool isLeft;

    private bool canAttack = false;

    private void Start()
    {
        StartCoroutine(ResetCanAttack());
    }

    private void Update()
    {
        if (canAttack == false) return;

        if (isLeft)
        {
            if(CheckTarget_OnLeft())
            {
                StartCoroutine(ResetAnimationAttack());
            }
            else animator.SetBool("Attack", false);
        }
        else
        {
            if (CheckTarget_OnRight())
            {
                StartCoroutine(ResetAnimationAttack());
            }
            else animator.SetBool("Attack", false);
        }
    }

    // call from animation
    private void Shooting()
    {
        GameObject bulletNew = Instantiate(bullet, pointShooting.position, quaternion.identity);
        Bullet bulletNewScript = bulletNew.GetComponent<Bullet>();
        if(bulletNewScript != null)
        {
            bulletNewScript.Direction = isLeft ? Vector2.left : Vector2.right;
        }
    }

    IEnumerator ResetAnimationAttack()
    {
        animator.SetBool("Attack", true);
        canAttack = false;
        StartCoroutine(ResetCanAttack());

        yield return new WaitForSeconds(0.4f);
        animator.SetBool("Attack", false);
    }

    IEnumerator ResetCanAttack()
    {
        yield return new WaitForSeconds(waitingTime);
        canAttack = true;
    }
}
