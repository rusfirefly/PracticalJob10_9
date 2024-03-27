using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameHandler _gameHandler;
    [SerializeField] private HudHandler _hudHandler;

    private void Start()
    {
        _hudHandler.Initialized();
        _gameHandler.Initialized();

    }
}
