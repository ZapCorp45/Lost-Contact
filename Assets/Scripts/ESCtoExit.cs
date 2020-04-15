using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCtoExit : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Thanks for playing!");
            Application.Quit();
        }
    }
}
