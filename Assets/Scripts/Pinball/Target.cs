using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _dieEffect;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health<0)
        {
            Instantiate(_dieEffect, transform);
            Destroy(gameObject,0.01f);
        }
    }
}
