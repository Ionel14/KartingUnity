using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelRotation : MonoBehaviour
{
    [SerializeField] Transform _SteeringWheelTransform;

    private float _rotationSpeed = 400f;
    private float _returnSpeed = 20f;

    private Quaternion _initialRotation;

    private float _initialRotationZValue = -90;
    private float _rotationValue = 60f;

    private float _maxRotation;
    private float _minRotation;

    void Start()
    {
        _initialRotation = _SteeringWheelTransform.localRotation;
        _maxRotation = _initialRotationZValue + _rotationValue;
        _minRotation = _initialRotationZValue - _rotationValue;
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        input *= -1f;

        float rotationAmount = input * _rotationSpeed * Time.deltaTime;

        float currentRotationZ = Mathf.Repeat(_SteeringWheelTransform.rotation.eulerAngles.z + 180f, 360f) - 180f;

        if (currentRotationZ <= _maxRotation && currentRotationZ >= _minRotation)
        {
            _SteeringWheelTransform.Rotate(Vector3.forward, rotationAmount);
        }


        if (input == 0 && !Quaternion.Equals(_SteeringWheelTransform.localRotation, _initialRotation))
        {
            StartCoroutine(ReturnToInitialRotation());
        }
    }

    IEnumerator ReturnToInitialRotation()
    {
        while (!Quaternion.Equals(_SteeringWheelTransform.localRotation, _initialRotation))
        {
            float step = _returnSpeed * Time.deltaTime;
            _SteeringWheelTransform.localRotation = Quaternion.RotateTowards(_SteeringWheelTransform.localRotation, _initialRotation, step);
            yield return null;
        }
    }
}
