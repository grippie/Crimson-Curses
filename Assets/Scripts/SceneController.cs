using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject player;

    // if the player collides with a scene trigger,
    // load the scene with the same name as the gameobject
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.PreviousScene = SceneManager.GetActiveScene().name;
            GameManager.instance.CurrentScene = transform.name;

            FaderInit.Fade(transform.name, Color.black, 1f);
        }
    }

}
