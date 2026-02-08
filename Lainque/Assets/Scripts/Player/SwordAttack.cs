using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage;

    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
