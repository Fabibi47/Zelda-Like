using UnityEngine;

[CreateAssetMenu(fileName = "Interractable", menuName = "Scriptable Objects/Interractable")]
public abstract class Interractable : ScriptableObject
{
    public abstract void OnInterract();
}
