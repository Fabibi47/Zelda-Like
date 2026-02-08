using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 1;
    public int speed = 5;
    public Vector2 attackDir;
    public Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = attackDir * speed * Time.fixedDeltaTime;
    }
}
