using UnityEngine;

public class FlipperInput : MonoBehaviour
{
    [SerializeField] private HingeJoint _rightFlipper;
    [SerializeField] private HingeJoint _leftFlipper;

    private JointSpring _rightFlipperSpring;
    private JointSpring _leftFlipperSpring;
    private float _angle = 60f;

    private void Awake()
    {
        _rightFlipperSpring = _rightFlipper.spring;
        _leftFlipperSpring = _leftFlipper.spring;
    }

    private void Update()
    {
        FlipInput(ref _rightFlipper, ref _rightFlipperSpring, _angle, KeyCode.E);
        FlipInput(ref _leftFlipper, ref _leftFlipperSpring, _angle * -1, KeyCode.Q);
    }

    private void FlipInput(ref HingeJoint joint, ref JointSpring springJoint, float angle, KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            springJoint.targetPosition = angle;
        }
        else
        {
            if (Input.GetKeyUp(key))
            {
                springJoint.targetPosition = 0;
            }
        }

        joint.spring = springJoint;
    }
}
