using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ChestData", menuName = "Scriptable Objects/ChestData")]
public class ChestData : Interractable
{

    public override void OnInterract()
    {
        SceneManager.LoadScene("WinMenu");
    }
}
