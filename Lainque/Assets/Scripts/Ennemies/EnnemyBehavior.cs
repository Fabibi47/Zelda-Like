using UnityEngine;

public class EnnemyBehavior : MonoBehaviour
{
    public bool isRanged;

    public int damage;
    public int hp;
    public int maxhp;
    public int moveSpeed;
    public int shootDistance;
    public float shootCd = 1.5f;
    private float timeStamp = 1.5f;

    public Transform playerTransform;
    public Rigidbody2D rb;

    public GameObject projectile;
    public GameObject loot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timeStamp += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
        {
            if (isRanged)
            {
                if (Vector2.Distance(playerTransform.position, transform.position) < shootDistance && timeStamp >= shootCd)
                {
                    Shoot();
                    timeStamp = 0;
                    rb.linearVelocity = Vector2.zero;
                } else
                {
                    rb.linearVelocity = playerTransform.position - transform.position * moveSpeed * Time.fixedDeltaTime;
                }
            } else
            {
                if (Vector2.Distance(playerTransform.position, transform.position) < 1 && timeStamp >= shootCd)
                {
                    Attack();
                    rb.linearVelocity = Vector2.zero;
                }
                else
                {
                    rb.linearVelocity = playerTransform.position - transform.position * moveSpeed * Time.fixedDeltaTime;
                }
            }
        }
    }

    private void Attack()
    {
        playerTransform.GetComponent<PlayerBehavior>().health -= damage;
    }

    private void Shoot()
    {
        projectile.GetComponent<Projectile>().attackDir = playerTransform.position;
        Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            hp -= collision.GetComponent<SwordAttack>().damage;
            if (hp <= 0)
            {
                Loot();
                Destroy(gameObject);
            }
        }
    }

    void Loot()
    {

    }
}
