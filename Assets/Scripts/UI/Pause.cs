using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool IsPaused = true;

    public void PauseManager()
    {
        if (IsPaused)
        {
            Time.timeScale = 0;
            IsPaused = false;
        }
        else
        {
            Time.timeScale = 1;
            IsPaused = true;
        }
    }
}
