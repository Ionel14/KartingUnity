using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDifficulty : MonoBehaviour
{
    public static int _Difficulty = 0;

    public void HandleInputData(int val)
    {
        _Difficulty = val;
    }
   
}
