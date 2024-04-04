using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    public enum Type { Passive, Mobile }
    [SerializeField] private float _health;
    [SerializeField] private GameObject _dieEffect;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private float _aggressionRadius;
    [SerializeField] private float _speed;
    [SerializeField] private Type _typeEnemy;
    private bool _isDetectPlayer;
    private Random _random;
    private Vector3 _randomPosition;


    private void Start()
    {
        _random = new Random();
        _isDetectPlayer = false;
        _randomPosition = NextRandomPoint();
        transform.LookAt(_randomPosition);
        MoveToTarget(_randomPosition);
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _aggressionRadius, _targetMask);

        if (colliders.Length>0)
            _isDetectPlayer = true;
        else
            _isDetectPlayer = false;

        foreach (Collider collider in colliders)
        {
        
            MoveToTarget(collider.transform.position);
        }

        if (!_isDetectPlayer)
        {
            float distance = Vector3.Distance(transform.position, _randomPosition);
            if(distance <= 1f)
            {
                _randomPosition = NextRandomPoint();
            }

            MoveToTarget(_randomPosition);
        }
    }


    private void OnDrawGizmos()
    {
        if (_typeEnemy == Type.Passive) return;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_randomPosition, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _aggressionRadius);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health<=0)
        {
            Instantiate(_dieEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        if (!_isDetectPlayer)
            if (_typeEnemy == Type.Passive) return;

        RotateToTarget(target);
        //transform.LookAt(target);
        Vector3 direction = target - transform.position;
        if(_isDetectPlayer)
        {
            float distance = Vector3.Distance(transform.position, target);
            if (distance <= 1f) return;
        }

        transform.Translate(direction.normalized * _speed * Time.deltaTime);
    }

    private void RotateToTarget(Vector3 targetDirection)
    {
        float singleStep = _speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 1.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private Vector3 NextRandomPoint() => new Vector3(_random.Next((int)transform.position.x - 2, (int)transform.position.x + 2),
                                                    transform.position.y - 0.4f, 
                                                    _random.Next((int)transform.position.z-2,(int)transform.position.z + 2));
}
