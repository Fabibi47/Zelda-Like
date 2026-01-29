using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerBehavior : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int speed;

    public Vector2 dir;
    public InputActionAsset inputAction;
    public Rigidbody2D RB2D;

    public GameObject triggerObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var playerMap = inputAction.FindActionMap("Player");
        playerMap.FindAction("Interact").started += Interract;
        playerMap.FindAction("Move").started += Move;
    }

    void Move(InputAction.CallbackContext obj)
    {
        dir = obj.ReadValue<Vector2>();
    }

    void Interract(InputAction.CallbackContext obj)
    {
        triggerObject.GetComponent<Interractable>().OnInterract();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("DamageZone"))
        {
            triggerObject = other.gameObject;
        }
    }
}
