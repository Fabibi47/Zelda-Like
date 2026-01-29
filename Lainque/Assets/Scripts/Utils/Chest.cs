using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject textObject;
    public GameObject content;
    public Interractable data;

    public void ActivateText()
    {
        textObject.SetActive(true);
    }

    public void DeactivateText()
    {
        textObject.SetActive(false);
    }

    public void OnInterract()
    {
        data.OnInterract();
    }
}
