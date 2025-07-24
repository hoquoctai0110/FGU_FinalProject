using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen)
        {
            animator.ResetTrigger("CloseDoor");
            animator.SetTrigger("OpenDoor");
            isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isOpen)
        {
            animator.ResetTrigger("OpenDoor");
            animator.SetTrigger("CloseDoor");
            isOpen = false;
        }
    }
}
