using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Choosing : MonoBehaviour
{
    public void StartShootingScene()
    {
        SceneManager.LoadScene("Second");
    }

    public void StartDemoScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void StartMoveScene()
    {
        SceneManager.LoadScene("Mooooove");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Weapon");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExitToMenu();
        }
    }

}
