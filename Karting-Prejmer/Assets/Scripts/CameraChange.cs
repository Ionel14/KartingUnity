using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject _ThirdCamera;
    public GameObject _FirstCamera;
    public int _CamMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if(_CamMode == 1) {
                _CamMode = 0;
            }
            else
            {
                _CamMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(_CamMode == 0)
        {
            _ThirdCamera.SetActive(true);
            _FirstCamera.SetActive(false);
        }
        if (_CamMode == 1)
        {
            _FirstCamera.SetActive(true);
            _ThirdCamera.SetActive(false);
        }
        _ThirdCamera.GetComponent<AudioListener>().enabled = !_ThirdCamera.GetComponent<AudioListener>().enabled;
        _FirstCamera.GetComponent<AudioListener>().enabled = !_FirstCamera.GetComponent<AudioListener>().enabled;

    }
}
