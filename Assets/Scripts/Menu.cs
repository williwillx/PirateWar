using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Menu : MonoBehaviour
{
    public TMP_InputField _gameSessionTime;
    public TMP_InputField _enemySpawnTime;
    public GameObject _painelOptions;
    int _option = 0;

    public void Options()
    {
        _painelOptions.SetActive(true);
        _gameSessionTime.text = PlayerPrefs.GetFloat("GameSessionTime").ToString();
        _enemySpawnTime.text = PlayerPrefs.GetFloat("EnemySpawnTime").ToString();
        _option = 1;
    }

    public void Play()
    {
        if(_option == 1)
        {
            PlayerPrefs.SetFloat("GameSessionTime", int.Parse(_gameSessionTime.text));
            PlayerPrefs.SetFloat("EnemySpawnTime", int.Parse(_enemySpawnTime.text));
        }
        
        SceneManager.LoadScene("ShipGame");
       
    }

}
