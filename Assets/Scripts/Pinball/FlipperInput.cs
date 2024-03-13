using UnityEngine;

public class FlipperInput : MonoBehaviour
{
    [SerializeField] private HingeJoint _rightFlipper;
    [SerializeField] private HingeJoint _leftFlipper;

    private JointSpring _flipperSpring;

    private void Awake()
    {
        _flipperSpring = _rightFlipper.spring;
    }

    private void Update()
    {
        float rightFlipper = Input.GetAxis("RFiliper");
        Debug.Log(rightFlipper);

        if (rightFlipper > 0.5f)
        {
            _flipperSpring.targetPosition = 45f;
        }
        else
        {
            _flipperSpring.targetPosition = 0;
        }

        _rightFlipper.spring = _flipperSpring;
    }
}
