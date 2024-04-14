using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    public static float _Volume;
    public static bool _Changed = false;
    public void SetVolume (float volume)
    {
        _Volume = volume;
        _Changed = true;
    }

}
