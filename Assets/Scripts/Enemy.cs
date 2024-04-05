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

        DetectPlayer();

        if (!_isDetectPlayer)
        {
            if (_typeEnemy == Type.Mobile)
            {
                float distance = Vector3.Distance(transform.position, _randomPosition);
                if (distance <= 1f)
                {
                    _randomPosition = NextRandomPoint();
                }

                MoveToTarget(_randomPosition);
            }
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

    private void DetectPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _aggressionRadius, _targetMask);
        foreach (Collider collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if (player)
            {
                _isDetectPlayer = true;
                MoveToTarget(collider.transform.position);
            }
            else
            {
                _isDetectPlayer = false;
            }
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        if (!_isDetectPlayer)
            if (_typeEnemy == Type.Passive) return;

        if(_isDetectPlayer)
        {
            float distance = Vector3.Distance(transform.position, target);
            if (distance <= 1f) return;
        }

        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

    }

    private void RotateToTarget(Vector3 targetDirection)
    {
        float singleStep = _speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 1.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private Vector3 NextRandomPoint() => new Vector3(_random.Next((int)transform.position.x - 2, (int)transform.position.x + 2),
                                                    (int)transform.position.y + 0.55f, 
                                                    _random.Next((int)transform.position.z-2,(int)transform.position.z + 2));
}
