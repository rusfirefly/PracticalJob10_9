using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static event Action GameOverEvent;
    public static event Action NewGameEvent;

    [SerializeField] private Transform _spawnPlayer;
    [SerializeField] private GameObject _ball;
    private Vector3 _rotationDefault;

    public void Initialized()
    {
        _rotationDefault = _ball.transform.eulerAngles;
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
        _ball.transform.position = _spawnPlayer.position;
        _ball.transform.eulerAngles = _rotationDefault;
        
        NewGameEvent?.Invoke();
    }
}
