using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private LayerMask jumpableGround;

    private int health;
    private int maxHealth;
    private float inputMoveX;

    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    private enum State
    {
        idle,
        running,
        jumping,
        falling,
        hitting,
        death
    }
    private State state;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        health = 3;
        maxHealth = 3;
    }

    private void Update()
    {
        if (state == State.death) return;
        if(GameManager.instance.GetGameState() == GameManager.GameState.gameOver)
        {
            return;
        }

        if(GameManager.instance.GetGameState() == GameManager.GameState.win)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            inputMoveX = 0;
            UpdateAnimation();
            return;
        }

        InputFromUser();
    }

    private void InputFromUser()
    {
        if (rb == null) return;

        inputMoveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveSpeed * inputMoveX, rb.velocity.y);

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            if(AudioController.Instance != null)
            {
                AudioController.Instance.PlaySFX(AudioController.Instance.jump);
            }
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (animator == null) return;

        if (state == State.hitting || state == State.death) return;

        if (inputMoveX != 0)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = State.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = State.falling;
        }

        if (inputMoveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (inputMoveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        animator.SetInteger("state", (int)state);
    }

    public void UpdatePortalInAnimation()
    {
        animator.SetTrigger("portal_in");
        rb.velocity = Vector3.zero;
        rb.simulated = false;
        boxColl.enabled = false;
    }

    public void UpdatePortalOutAnimation()
    {
        animator.SetTrigger("portal_out");
        rb.velocity = Vector3.zero;
        rb.simulated = false;
        boxColl.enabled = false;
    }
    public void ResetPortalAnimation()
    {
        animator.SetInteger("state", 0);
        animator.SetInteger("state", (int)state);
        GetComponent<Rigidbody2D>().simulated = true;
        boxColl.enabled = true;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, Vector2.down, 0.1f, jumpableGround);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (GameManager.instance == null) return;

        if (state == State.death || state == State.hitting) return;

        if (col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Enemy"))
        {
            state = State.hitting;
            health = Mathf.Clamp(health - 1, 0, maxHealth);
            UIManager.instance.ShowHealthReductionUI();

            if(health <= 0)
            {
                state = State.death;
                animator.SetTrigger("death");
                if (AudioController.Instance != null)
                {
                    AudioController.Instance.PlaySFX(AudioController.Instance.death);
                }
                GameManager.instance.SetGameState(GameManager.GameState.gameOver);
                StartCoroutine(DestroyPlayerCoroutine());
            }
            else
            {
                Invoke("ResetHitAnimation", 1f);
                animator.SetInteger("state", (int)state);
            }
        }
    }

    // invoke
    private void ResetHitAnimation()
    {
        state = State.idle;
    }

    IEnumerator DestroyPlayerCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.ShowGameOverPanel(true);
        Destroy(gameObject);
    }
}
