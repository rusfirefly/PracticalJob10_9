using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private HingeJoint _joint;

    public void StartCar()
    {
        _joint.useMotor = true;
    }
}
