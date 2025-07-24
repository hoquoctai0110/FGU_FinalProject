using UnityEngine;

public class ToolPointController : MonoBehaviour
{
    public Transform player;
    public Transform toolPoint;
    [SerializeField] public float distance = 0.75f;

    private Vector2 direct;
    private Vector2 lastDirection = Vector2.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direct.x = Input.GetAxisRaw("Horizontal");
        direct.y = Input.GetAxisRaw("Vertical");

        if(direct != Vector2.zero)
        {
            lastDirection = direct.normalized;
        }

        Vector3 offset = new Vector3(lastDirection.x, lastDirection.y, 0f) * distance;
        toolPoint.position = player.position + offset;


    }
}
