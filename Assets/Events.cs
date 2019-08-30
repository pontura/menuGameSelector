using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

    public static System.Action Next = delegate { };
    public static System.Action Prev = delegate { };
    public static System.Action RunGame = delegate { };

    public static System.Action<string> OnMusic = delegate { };
	public static System.Action<string> OnSoundFX = delegate { };
	
	
}
