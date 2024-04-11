using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource _BackgroundSound;
    // Start is called before the first frame update
    void Start()
    {
        _BackgroundSound.volume = 0.8f;
        _BackgroundSound.loop = true;
        _BackgroundSound.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
