using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDownForce : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float _AddDownForceValue = 100f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(_AddDownForceValue * rigidbody.velocity.magnitude * -transform.up);
    }
}
