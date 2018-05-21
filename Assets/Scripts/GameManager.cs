using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public string PreviousScene { get; set; }
    public string CurrentScene { get; set; }
    public GameObject CurrentDirection { get; set; }
    public int hitPoints { get; set; }
    public int maxHitPoints { get; set; }

    // things to store here that persist scene to scene
    // player health
    // player experience

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        maxHitPoints = 5;

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
}
