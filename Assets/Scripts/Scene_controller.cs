using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_controller : MonoBehaviour
{
    private static Scene_controller instance = null;
    public static Scene_controller Instance
    {
        get { return instance; }
    }

    public DnD_Abilities Character = new DnD_Abilities();
    public int Race;
    public int Alignment;
    public int Class;
    public bool finished = false;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }

    }
}