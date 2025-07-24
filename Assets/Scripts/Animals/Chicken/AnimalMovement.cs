using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 1f;          
    public float changeDirectionTime = 2f; 

    private Vector2 moveDirection;
    private float directionTimer = 0f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChooseRandomDirection();
    }

    void Update()
    {
        directionTimer -= Time.deltaTime;
        if (directionTimer <= 0f)
        {
            ChooseRandomDirection();
        }

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void ChooseRandomDirection()
    {
        if (Random.value < 0.25f)
            moveDirection = Vector2.zero;
        else
            moveDirection = Random.insideUnitCircle.normalized; 

        directionTimer = Random.Range(1f, changeDirectionTime);
    }
}
