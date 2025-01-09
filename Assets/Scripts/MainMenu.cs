using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;
using NaughtyAttributes;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField, Range(2,8)] int _playerNumber = 2;
    [SerializeField] TMP_Text _playerNumberText;

    private void Update()
    {
        _playerNumberText.text = _playerNumber.ToString();
    }

    public void PlayGame()
    {
        SetGameData();
        SceneManager.LoadScene("Rayan");
        //SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    [Button]
    public void AddPlayer()
    {
        if (_playerNumber >= 8)
        {
            _playerNumber = 2;
            return;
        }
        _playerNumber++;
    }
    
    [Button]
    public void RemovePlayer()
    {
        if (_playerNumber == 2)
        {
            _playerNumber= 8;
            return;
        }
            
        
        _playerNumber--;
    }
    public void SetGameData()
    {
        gameData.PlayerNumber = _playerNumber;
        Debug.Log("Player count set to: " + gameData.PlayerNumber);
    }
}