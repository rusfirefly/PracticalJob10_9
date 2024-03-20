using UnityEngine;

//[RequireComponent(typeof(SpringJoint))]
public class Plunger : MonoBehaviour
{
    [SerializeField] private SpringJoint _spring;
    [SerializeField] private SpringJoint _springMin;
    [SerializeField] private float _forceSpring;

    [SerializeField] private Rigidbody _springRigidbody;
    private bool _isMinSpring;
    [SerializeField] private SpringJoint _tempSpring;
    [SerializeField] private Rigidbody _springRB;
    private float _anchorMin;
    private Vector3 _anchorMax;

    private void Start()
    {
        _springRigidbody = GetComponent<Rigidbody>();
        _tempSpring = _spring;
        _springRB = _tempSpring.connectedBody;
        _anchorMax = _springMin.anchor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "maxTriger")
        {
            //_springRigidbody.isKinematic = true;
            //_spring.spring = 0;
        }
        if(other.tag == "minTriger")
            _isMinSpring = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "minTriger")
            _isMinSpring = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _springMin.connectedBody = null;
            _spring = _tempSpring;
            _spring.connectedBody = _springRigidbody;
            _springMin.anchor = _anchorMax;
        }
    }

    private void FixedUpdate()
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
    }

}
