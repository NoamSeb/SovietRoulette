using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;
using NaughtyAttributes;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] int _playerNumber = 2;
    [SerializeField] TMP_Text _playerNumberText;

    private void Update()
    {
        _playerNumberText.text = _playerNumber.ToString();
    }

    public void PlayGame()
    {
        SetGameData();
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    [Button]
    public void AddPlayer()
    {
        _playerNumber++;
    }
    
    [Button]
    public void RemovePlayer()
    {
        if (_playerNumber == 2)
            return;
        _playerNumber--;
    }
    public void SetGameData()
    {
        gameData.PlayerNumber = _playerNumber;
        Debug.Log("Player count set to: " + gameData.PlayerNumber);
    }
}