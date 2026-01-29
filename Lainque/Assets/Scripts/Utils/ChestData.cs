using UnityEngine;

[CreateAssetMenu(fileName = "ChestData", menuName = "Scriptable Objects/ChestData")]
public class ChestData : Interractable
{

    public override void OnInterract()
    {
        Debug.Log("Ouverture du coffre.");
    }
}
