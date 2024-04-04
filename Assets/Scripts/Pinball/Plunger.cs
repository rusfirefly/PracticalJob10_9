using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] private SpringJoint _spring;
    [SerializeField] private SpringJoint _springMin;
    [SerializeField] private float _forceSpring;

    [SerializeField] private Rigidbody _springRigidbody;
    [SerializeField] private SpringJoint _tempSpring;
    private Vector3 _anchorMax;

    private void Start()
    {
        _springRigidbody = GetComponent<Rigidbody>();
        _tempSpring = _spring;
        _anchorMax = _springMin.anchor;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _spring.connectedBody = null;
            _springMin.connectedBody = _springRigidbody;
            _spring = _springMin;
            Vector3 anchor = _spring.anchor;
            anchor.z += 15f * Time.deltaTime;
            _spring.anchor = anchor;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _springMin.connectedBody = null;
                _spring = _tempSpring;
                _spring.connectedBody = _springRigidbody;
                _springMin.anchor = _anchorMax;
            }
        }
    }

}
