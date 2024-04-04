
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _radusBoom;
    [SerializeField] private float _forceBoom;
    [SerializeField] private GameObject _exploseEffect;
    [SerializeField] private LayerMask _layerExplosion;
    private bool _isExplosion;


    public void TakeDamage(float damage)
    {
        if (_isExplosion) return;
        _health -= damage;
        Invoke("Explode", 0.2f);
    }

    private void Explode()
    {
        if (_health < 0)
        {
            _isExplosion = true;
            Instantiate(_exploseEffect, transform.position, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(transform.position, _radusBoom, _layerExplosion);
            foreach (Collider collider in colliders)
            {
                Explosion explosion = collider.GetComponent<Explosion>();
                if (explosion)
                {
                    explosion.TakeDamage(1000);
                }

                if (collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(1000);
                }

                Rigidbody rigidbody = collider.attachedRigidbody;
                if (rigidbody)
                {

                    float distance = Vector3.Distance(transform.position, rigidbody.transform.position);
                    if (distance <= _radusBoom)
                    {
                        float force = _forceBoom * (_radusBoom - distance);
                        rigidbody.AddExplosionForce(force, transform.position, _radusBoom, 1f);
                    }
                }
            }

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radusBoom);
    }

}
