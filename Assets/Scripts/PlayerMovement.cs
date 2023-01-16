using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sneakSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = movement * sneakSpeed;
        }
        else
        {
            rb.velocity = movement * moveSpeed;
        }
    }
}
