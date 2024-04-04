using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static event Action GameOverEvent;
    public static event Action NewGameEvent;

    [SerializeField] private Transform _spawnPlayer;
    [SerializeField] private GameObject _ball;


    public void Initialized()
    {
        NewGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameOver();
    }

    private void GameOver()
    {
        GameOverEvent?.Invoke();
    }

    public void NewGame()
    {
        _ball.transform.position = Vector3.zero;
        _ball.transform.eulerAngles = Vector3.zero;
        _ball.transform.position = _spawnPlayer.position;
        
        NewGameEvent?.Invoke();
    }
}
