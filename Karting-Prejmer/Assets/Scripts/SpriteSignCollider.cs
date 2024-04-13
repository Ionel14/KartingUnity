using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSignCollider : MonoBehaviour
{
    public bool _CheckByPlayer = false;
    public bool _CheckByEnemy = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _CheckByEnemy = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _CheckByPlayer = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            _CheckByEnemy = true;
        }
    }
}
