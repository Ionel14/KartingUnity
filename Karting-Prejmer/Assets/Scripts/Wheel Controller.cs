using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider _FrontRight;
    [SerializeField] WheelCollider _FrontLeft;
    [SerializeField] WheelCollider _BackRight;
    [SerializeField] WheelCollider _BackLeft;

    [SerializeField] Transform _FrontRightTransform;
    [SerializeField] Transform _FrontLeftTransform;
    [SerializeField] Transform _BackRightTransform;
    [SerializeField] Transform _BackLeftTransform;

    private float _acceleration = 300f;
    private float _brakingForce = 300f;
    private float _maxTurnAngle = 40f;

    private float _currentAcceleration = 0f;
    private float _currentBrakeForce = 0f;
    private float _currentTurnAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        _currentAcceleration = _acceleration * -1 * Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Space))
        {
            _currentBrakeForce = _brakingForce;
        }
        else
        {
            _currentBrakeForce = 0f;
        }

        _FrontLeft.motorTorque = _currentAcceleration;
        _FrontRight.motorTorque = _currentAcceleration;

        _FrontRight.brakeTorque = _currentBrakeForce;
        _FrontLeft.brakeTorque = _currentBrakeForce;
        _BackRight.brakeTorque = _currentBrakeForce;
        _BackLeft.brakeTorque = _currentBrakeForce;

        _currentTurnAngle = _maxTurnAngle * Input.GetAxis("Horizontal");
        _FrontLeft.steerAngle = _currentTurnAngle;
        _FrontRight.steerAngle = _currentTurnAngle;

        UpdateWheel(_FrontLeft, _FrontLeftTransform);
        UpdateWheel(_FrontRight, _FrontRightTransform);
        UpdateWheel(_BackLeft, _BackLeftTransform);
        UpdateWheel(_BackRight, _BackRightTransform);
    }

    private void UpdateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }
}
