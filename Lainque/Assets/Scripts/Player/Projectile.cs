using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    public int speed = 300;
    public Vector2 attackDir;
    public Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x < -500 || transform.position.x > 500 || transform.position.y < -500 || transform.position.y > 500)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = attackDir * speed * Time.fixedDeltaTime;
    }
}
