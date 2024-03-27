using UnityEngine;
using UnityEngine.UI;

public class HudHandler : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Button _newGameButton;
    private int _score;

    public void Initialized()
    {
        _score = 0;
        SetVisibleHUDEllemets(false);
    }

    private void OnValidate()
    {
        Point.UsePoint += OnUsePoint;
        GameHandler.GameOverEvent += OnGameOver;
        GameHandler.NewGameEvent += OnNewGame;
    }

    private void OnDestroy()
    {
        Point.UsePoint -= OnUsePoint;
        GameHandler.GameOverEvent -= OnGameOver;
        GameHandler.NewGameEvent -= OnNewGame;
    }

    private void OnGameOver()
    {
        SetVisibleHUDEllemets(true);
    }

    private void OnNewGame()
    {
        _score = 0;
        if (_scoreText)
            _scoreText.text = $"SCORE: {_score}";

        SetVisibleHUDEllemets(false);
    }

    private void SetVisibleHUDEllemets(bool visible)
    {
        if(_gameOverText)
            _gameOverText.gameObject.SetActive(visible);
        if(_newGameButton)
        _newGameButton.gameObject.SetActive(visible);
    }

    private void OnUsePoint(int point)
    {
        _score += point;
        if(_scoreText)        
            _scoreText.text = $"SCORE: {_score}";
    }
}
