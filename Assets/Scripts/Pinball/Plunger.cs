using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class Plunger : MonoBehaviour
{
    [SerializeField] private SpringJoint _spring;
    [SerializeField] private float _forceSpring;

    private Rigidbody _springRigidbody;
    private const float _maxPositionPluger = 85f;
    private const float _minPositionPluger = 103f;

    private void Start()
    {
        _springRigidbody = GetComponent<Rigidbody>();
    }

    private void OnValidate()
    {
        _spring ??= GetComponent<SpringJoint>();
    }

    private void Update()
    {
            
    }

}
