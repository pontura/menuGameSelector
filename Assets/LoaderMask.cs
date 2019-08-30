using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderMask : MonoBehaviour
{
    public GameObject panel;
    float timer;
    public states state;
    public enum states
    {
        LOADING,
        DONE        
    }
    public void Init()
    {
        Invoke("ChangeState", 0.05f);
        panel.SetActive(true);
        timer = 0;
        state = states.LOADING;
    }
    void Update()
    {
        if (state == states.DONE)
            return;
        timer += Time.deltaTime;
        if(timer>3)
        {
            state = states.DONE;
            panel.SetActive(false);
        }
    }
}
