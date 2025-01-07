using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private int playerNumber;

    public int PlayerNumber
    {
        get => playerNumber;
        set => playerNumber = value;
    }
}
