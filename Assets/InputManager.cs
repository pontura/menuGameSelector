using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            Events.Next();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            Events.Prev();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Events.RunGame();
            
        }
    }
}
