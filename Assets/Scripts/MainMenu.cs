using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;
using NaughtyAttributes;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] GameData gameData;
    [SerializeField, Range(2,8)] int _playerNumber = 2;
    [SerializeField] TMP_Text _playerNumberText;
    
    [Header("SOUND")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider sliderVolume;

    private void Start()
    {
        AudioManager.instance.PlayBackground();
    }

    private void Reset()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        Slider sliderVolume = GetComponent<Slider>();
        audioSource.volume = sliderVolume.value;
    }

    private void Update()
    {
        _playerNumberText.text = _playerNumber.ToString();
    }

    public void PlayGame()
    {
        SetGameData();
        SceneManager.LoadScene("Margot");
        //SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    [Button]
    public void AddPlayer()
    {
        if (_playerNumber == 8)
            return;
        
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
    
    public void ChangeVolume()
    {
        Debug.Log("Volume set to: " + sliderVolume.value);
        AudioManager.instance.musicSource.volume = sliderVolume.value;
        //audioSource.volume = sliderVolume.value;
    }
}