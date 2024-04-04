using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health<0)
        {
            Debug.Log("Game Over");
            _health = 100;
        }
    }


}
