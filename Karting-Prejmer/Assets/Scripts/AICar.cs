using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AICar : MonoBehaviour
{
    [SerializeField] WheelCollider _FrontRight;
    [SerializeField] WheelCollider _FrontLeft;

    [SerializeField] GameObject[] _Points;
    private int target;
    private float _currentAcceleration;
    private float _acceleration = 80f;
    private float _brakingForce = 3000f;
    private float _turnAngle;
    private bool _finished = false;



    // Start is called before the first frame update
    void Start()
    {
        target = 0;
        _currentAcceleration = _acceleration * -1;
        _FrontRight.motorTorque = _currentAcceleration;
        _FrontLeft.motorTorque = _currentAcceleration;

        CalculateTurnAngle(transform.position, _Points[target].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_finished && _Points[target].transform.position.x < transform.position.x)
        {
            if (target + 1 < _Points.Length)
            {
                target++;
                CalculateTurnAngle(transform.position, _Points[target].transform.position);

            }
            else if (target + 1 >= _Points.Length)
            {
                _finished = true;
                _FrontRight.motorTorque = 0;
                _FrontLeft.motorTorque = 0;
                _FrontRight.brakeTorque = _brakingForce;
                _FrontLeft.brakeTorque = _brakingForce;
            }
        }
        
    }

    private void CalculateTurnAngle(Vector3 fromPosition, Vector3 toPosition)
    {
        _turnAngle = Mathf.Atan(Mathf.Abs(toPosition.x - fromPosition.x) / Mathf.Abs(toPosition.z - fromPosition.z)) / 2;
        
        if (toPosition.z > fromPosition.z)
        {
            _turnAngle *= -1;
        }

        _FrontLeft.steerAngle = _turnAngle;
        _FrontRight.steerAngle = _turnAngle;
    }

  /*  private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Fence"))
        {
            *//*_FrontRight.motorTorque = 0;
            _FrontLeft.motorTorque = 0;
            _FrontRight.brakeTorque = _brakingForce;
            _FrontLeft.brakeTorque = _brakingForce;*//*

            transform.LookAt(_Points[target + 1].transform.position);
            transform.position = new Vector3(transform.position.x, transform.position.y, _Points[target].transform.position.z);

            CalculateTurnAngle(transform.position, _Points[target].transform.position);

            *//*_FrontRight.motorTorque = _currentAcceleration;
            _FrontLeft.motorTorque = _currentAcceleration;
            _FrontRight.brakeTorque = 0;
            _FrontLeft.brakeTorque = 0;*//*
        }
        

    }*/
}
