using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5.0f;

    Rigidbody2D rb2D;

    Vector2 movementInput;

    private Animator animator;

    private int currentHealth;
    public int maxHealth = 100;

    private bool gameIsPaused = false;

    private bool isAttacking = false;
    private bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        UIManager.Instance.UpdateHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
            canMove = false;
        else
            canMove = true;

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized;
        animator.SetFloat("Horizontal", Mathf.Abs(movementInput.x));
        animator.SetFloat("Vertical", Mathf.Abs(movementInput.y));

        CheckFlip();
        OpenCloseInventory();
        OpenClosePauseMenu();
        Attack();
    }
    void FixedUpdate()
    {

        if (canMove)
        {
            rb2D.linearVelocity = movementInput * speed;

        }
        else
        {
            rb2D.linearVelocity = Vector2.zero;

        }


    }

    void CheckFlip()
    {
        if (movementInput.x > 0 && transform.localScale.x < 0 || movementInput.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void OpenCloseInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Instance.OpenOrCLoseInventory();
        }
    }

    void OpenClosePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                UIManager.Instance.ResumeGame();
                gameIsPaused = false;
            }
            else
            {
                UIManager.Instance.PauseGame();
                gameIsPaused = true;
            }
        }
    }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            int randomIndex = Random.Range(0, 2);
            animator.SetInteger("AttackIndex", randomIndex);
            animator.SetTrigger("DoAttack");
        }
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}
