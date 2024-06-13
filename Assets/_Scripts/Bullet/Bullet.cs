using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 direction;

    public Vector2 Direction { get => direction; set => direction = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
