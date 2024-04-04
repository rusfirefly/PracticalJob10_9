using UnityEngine;

public class Pult : Interactable
{
    [SerializeField] private Car _car;

    public override void OnInteract()
    {
        base.OnInteract();
        _car.StartCar();
    }
}
