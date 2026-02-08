using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (FindAnyObjectByType<GameManager>())
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
