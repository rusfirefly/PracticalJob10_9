using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private HingeJoint[] _wheels;
    [SerializeField] private HingeJoint _cabin;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedTurn;
    [SerializeField] private Mover _move;

    private void Start()
    {
            
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float turn = Input.GetAxis("Turn");

        

        if (turn > 0.1f)
        {
            CabinTurnLeft();
        }
        if (turn < 0)
        {
            CabinTurnRight();
        }

        if(turn == 0f)
        {
            Debug.Log("stop");
            TurnStop();
        }
    }

    private void CabinTurnLeft()
    {
        _cabin.axis = new Vector3(0,-1,0);
        Turn();
    }

    private void CabinTurnRight()
    {
        _cabin.axis = new Vector3(0, 1, 0);
        Turn();
    }

    private void TurnStop()
    {
        _cabin.useMotor = false;
        JointMotor motor = _cabin.motor;
        motor.force = 0f;
        _cabin.motor = motor;
    }


    private void Turn()
    {
        _cabin.useMotor = true;
        JointMotor motor = _cabin.motor;
        motor.force = _speedTurn;
        _cabin.motor = motor;
    }
}
