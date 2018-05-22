using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public string PreviousScene { get; set; }
    public string CurrentScene { get; set; }
    public GameObject CurrentDirection { get; set; }
    public int hitPoints { get; set; }
    public int maxHitPoints { get; set; }
    public Text hitPointsText;

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

        maxHitPoints = 5;
        UpdateHitPoints(maxHitPoints);
        hitPoints = maxHitPoints;

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    public void UpdateHitPoints(int delta)
    {
        Debug.Log(hitPoints + " " + delta);
        hitPoints +=delta;
        hitPointsText.text = hitPoints.ToString();
        Debug.Log(hitPoints + " " + delta);
    }
}
