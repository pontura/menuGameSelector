using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechasManager : MonoBehaviour
{
    public Animation leftAnim;
    public Animation rightAnim;
    void Start()
    {
        Events.Next += Next;
        Events.Prev += Prev;
    }    
    void Next()
    {
        leftAnim.Play();
    }
    void Prev()
    {
        rightAnim.Play();
    }
}
