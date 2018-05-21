using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerSetup controls the player state at the beginning of each scene,
/// Awake() is used so that it starts before the Start() function of CharacterControl script.
/// For Scenes with many entrances, the entrance name, location and facing direction can be set in the inspector.
/// This is generic so that any scene with mulitple entrances can be set up by adding more entrance#string/vectors
/// </summary>
public class PlayerSetup : MonoBehaviour {

    public GameObject downDir, upDir, leftDir, rightDir;

    // the # of entrance locations will expand depending on the worst case scneario of the # of scene entrances
    // values can be null, as the comparison will return false and not error out with null == 0
    public string entrance1string;
    public Vector3 entrance1vector;
    public GameObject entrance1direction;

    public string entrance2string;
    public Vector3 entrance2vector;
    public GameObject entrance2direction;

    void Awake ()
    {
        string cur = GameManager.instance.CurrentScene;
        string prev = GameManager.instance.PreviousScene;

        if (cur != null && prev != null)
        {
            if (prev.ToLower().CompareTo(entrance1string) == 0)
            {
                SetActive(entrance1vector, entrance1direction);
            }
            else if (prev.ToLower().CompareTo(entrance2string) == 0)
            {
                SetActive(entrance2vector, entrance2direction);
            }
        }        
    }

    /// <summary>
    /// Sets the position of the player depending on the entrance the player is coming from.
    /// </summary>
    /// <param name="location">Vector3 data for where the player should start from an entrance.</param>
    /// <param name="entranceDirection">Direction that the player should be facing.</param>
    private void SetActive(Vector3 location, GameObject entranceDirection)
    {
        transform.position = location;
        GameManager.instance.CurrentDirection = entranceDirection;     
    }

}
