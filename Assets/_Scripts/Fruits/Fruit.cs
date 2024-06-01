using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.instance.Fruits++;
            UIManager.instance.ShowFruitsUI();

            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlaySFX(AudioController.Instance.collect);
            }
            animator.SetTrigger("Collected");
            Destroy(gameObject, 0.35f);
        }
    }

}
