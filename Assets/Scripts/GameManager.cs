using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float _gameSessionTime;
    public float _enemySpawnTime;
    public TextMeshProUGUI _firstMinute;
    public TextMeshProUGUI _secondMinute;
    public TextMeshProUGUI _firstSecond;
    public TextMeshProUGUI _secondSecond;
    public GameObject _enemyShooter;
    public GameObject _enemyChaser;
    private void Start()
    {
        _gameSessionTime = PlayerPrefs.GetFloat("GameSessionTime") * 60;
        _enemySpawnTime = PlayerPrefs.GetFloat("EnemySpawnTime");
        StartCoroutine(SpawEnemy(_enemySpawnTime));
    }

    void Update()
    {
        _gameSessionTime -= Time.deltaTime;

        UpdateTimer(_gameSessionTime);

        if (_gameSessionTime < 0)
        {
            StopAllCoroutines();
        }
    }

    void UpdateTimer(float timer)
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        _firstMinute.text = currentTime[0].ToString();
        _secondMinute.text = currentTime[1].ToString();
        _firstSecond.text = currentTime[2].ToString();
        _secondSecond.text = currentTime[3].ToString();
    }

    IEnumerator SpawEnemy(float waitTime)
    {
        int enemy = Random.Range(0, 4);
        switch(enemy)
        {
            case 0:
                Instantiate(_enemyShooter, new Vector3(-11, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(_enemyChaser, new Vector3(-11, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(_enemyShooter, new Vector3(11, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(_enemyChaser, new Vector3(11, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                break;
        }
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SpawEnemy(_enemySpawnTime));
    }
}
