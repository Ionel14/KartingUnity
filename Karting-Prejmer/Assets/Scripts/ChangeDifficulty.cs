using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDifficulty : MonoBehaviour
{
    public static int difficulty = 0;

    public void HandleInputData(int val)
    {
        difficulty = val;
    }
   
}
