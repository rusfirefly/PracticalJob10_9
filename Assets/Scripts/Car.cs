using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private HingeJoint[] _wheels;
    [SerializeField] private HingeJoint _cabin;
    [SerializeField] private float _speedTurn;
   
    private Vector3 _axis;

    private void Start()
    {

    }

    private void Update()
    {
        /* float x = Input.GetAxis("Horizontal");
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

         if (turn == 0f)
         {
             TurnStop();
         }*/
    }

    private void CabinTurnLeft()
    {
        _axis = _cabin.axis;
        
        if (_axis.y > 0)
        {
            _axis.y = -1;
            _cabin.axis = _axis;
            Turn();
        }
       
    }

    private void CabinTurnRight()
    {
        _axis = _cabin.axis;
        if (_axis.y < 0 || _axis.y == 1)
        {
            _axis.y = 1;
            _cabin.axis = _axis;
            Turn();
        }
        
    }

    private void TurnStop()
    {
        JointMotor motor = _cabin.motor;
        motor.force = 0f;
        _cabin.motor = motor;
        _cabin.useMotor = false;
    }


    private void Turn()
    {
        _cabin.useMotor = true;
        JointMotor motor = _cabin.motor;
        motor.force = _speedTurn;
        _cabin.motor = motor;
    }
}
