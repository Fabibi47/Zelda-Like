using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public bool attacking;

    public int damage;
    public float timeStamp;

    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        timeStamp += Time.deltaTime;
        attacking = timeStamp < 5/6;
    }

    public void Attack()
    {
        timeStamp = 0;
        anim.SetTrigger("Attack");
    }
}
