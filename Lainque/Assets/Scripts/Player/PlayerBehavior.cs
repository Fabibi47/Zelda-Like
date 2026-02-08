using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerBehavior : MonoBehaviour
{
    public bool isRanged = false;
    public int health;
    public int maxHealth;
    public int speed;

    public Vector2 dir;
    public InputActionAsset inputAction;
    public Rigidbody2D RB2D;

    public SwordAttack SwordObject;
    public BowAttack BowObject;
    public GameObject triggerObject;
    public GameObject WeaponObject;
    public GameObject HealthUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var playerMap = inputAction.FindActionMap("Player");
        playerMap.FindAction("Interact").started += Interract;
        playerMap.FindAction("Move").performed += Move;
        playerMap.FindAction("Move").canceled += StopMove;
        playerMap.FindAction("Attack").performed += Attack;
        playerMap.FindAction("Switch").performed += Switch;
    }

    void Switch(InputAction.CallbackContext obj)
    {
        if (isRanged)
        {
            isRanged = false;
            SwordObject.gameObject.SetActive(true);
            BowObject.gameObject.SetActive(false);
        } else
        {
            isRanged = true;
            BowObject.gameObject.SetActive(true);
            SwordObject.gameObject.SetActive(false);
        }
    }

    void Attack(InputAction.CallbackContext obj)
    {
        if (isRanged)
        {
            BowObject.Attack();
        } else
        {
            SwordObject.Attack();
        }
    }

    void Move(InputAction.CallbackContext obj)
    {
        dir = obj.ReadValue<Vector2>();
    }

    void StopMove(InputAction.CallbackContext obj)
    {
        dir = new Vector2(0, 0);
    }

    void Interract(InputAction.CallbackContext obj)
    {
        triggerObject.GetComponent<Interractable>().OnInterract();
    }

    // Update is called once per frame
    void Update()
    {
        HealthUI.GetComponent<RectTransform>().sizeDelta = new Vector2(health * 50, 50);
    }

    private void FixedUpdate()
    {
        RB2D.linearVelocity = dir * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            other.GetComponent<Chest>().ActivateText();
            triggerObject = other.gameObject;
        } else if (other.gameObject.CompareTag("EnnemyProjectile"))
        {
            health -= other.GetComponent<Projectile>().damage;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            other.GetComponent<Chest>().DeactivateText();
            triggerObject = null;
        }
    }
}
