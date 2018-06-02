using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public GameObject hud;
    public string PreviousScene { get; set; }
    public string CurrentScene { get; set; }
    public GameObject CurrentDirection { get; set; }
    public int HitPoints { get; set; }
    public int MaxHitPoints { get; set; }
    private Text hitPointsText;

    // things to store here that persist scene to scene
    // player health
    // player experience

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        hitPointsText = GameObject.Find("HitPointsText").GetComponent<Text>();

        MaxHitPoints = 5;
        UpdateHitPoints(MaxHitPoints);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    public void UpdateHitPoints(int delta)
    {
        Debug.Log("Start " + HitPoints + " change:" + delta);
        HitPoints +=delta;
        hitPointsText.text = HitPoints.ToString();
        Debug.Log("Result " + HitPoints);
    }
}
