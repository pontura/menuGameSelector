using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Data : MonoBehaviour
{
    const string PREFAB_PATH = "Data";    
    static Data mInstance = null;
    public Settings settings;
    public MainScreen mainScreen;
    public LoaderMask loaderMask;

    public static Data Instance
	{
		get
		{
			if (mInstance == null)
			{
				mInstance = FindObjectOfType<Data>();

				if (mInstance == null)
				{
					GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
					mInstance = go.GetComponent<Data>();
				}
			}
			return mInstance;
		}
	}
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
        Screen.fullScreen = true;
    }

}
