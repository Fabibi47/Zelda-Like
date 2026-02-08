using UnityEngine;

public class BowAttack : MonoBehaviour
{
    public GameObject arrow;

    public void Attack()
    {
        Instantiate(arrow, gameObject.GetComponentInParent<Transform>());
    }
}
