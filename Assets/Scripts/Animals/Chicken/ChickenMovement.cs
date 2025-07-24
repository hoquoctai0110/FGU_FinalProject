using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if(movement.x < 0)
        {
            spriteRenderer.flipX = true;
        } else if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        rb.MovePosition(rb.position + movement * Time.deltaTime * speed);
    }
}
