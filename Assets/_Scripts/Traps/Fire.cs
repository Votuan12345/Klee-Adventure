using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float countDown;
    [SerializeField] private bool isOn;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if(countDown <= 0)
        {
            animator.SetBool("On", true);
        }
        else StartCoroutine(FireOn());
    }

    IEnumerator FireOn()
    {
        animator.SetBool("On", isOn);

        yield return new WaitForSeconds(countDown);
        animator.SetBool("On", !isOn);

        yield return new WaitForSeconds(countDown);
        StartCoroutine(FireOn());
    }
}
