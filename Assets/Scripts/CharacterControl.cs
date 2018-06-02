using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterControl : MonoBehaviour
{
    public GameObject downDir, upDir, leftDir, rightDir;
    public GameObject currentDir;
    public float speed = 4;
    public bool isWalking;
    public bool isAttacking;
    private float horizontal, vertical;
    private TilemapInfo ti;
    public Tilemap tilemap;
    public int currentHitPoints;
    public float damageFallBack = .25f;

    // Use this for initialization
    void Start()
    {        
        ti = tilemap.GetComponent<TilemapInfo>();

        // find the current active direction
        currentDir = GetActiveSelf();

        // determine if the GameManager has a currentDirection set
        if (GameManager.instance.CurrentDirection != null)
            currentDir = GameManager.instance.CurrentDirection;

        GameManager.instance.HitPoints = GameManager.instance.MaxHitPoints;

        // make only the currentDir Active
        SetActive(currentDir);
    }

    /// <summary>
    /// Finds which GameObject is currently active.
    /// </summary>
    public GameObject GetActiveSelf()
    {
        if (downDir.activeSelf)
            return downDir;
        else if (upDir.activeSelf)
            return upDir;
        else if (rightDir.activeSelf)
            return rightDir;
        else if (leftDir.activeSelf)
            return leftDir;
        else
            return null;
    }
    /// <summary>
    /// Makes sure that only the input object is active.
    /// </summary>
    /// <param name="activate">GameObject that you want activated with all others deactivated</param>
    private void SetActive(GameObject activate)
    {
        
        downDir.SetActive(false);
        upDir.SetActive(false);
        rightDir.SetActive(false);
        leftDir.SetActive(false);

        activate.SetActive(true);
    }

    // FixedUpdate is called consistently, but may be more or less than every frame
    void FixedUpdate()
    {
        Vector2 moveDirection = Vector2.zero;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        isWalking = false;
        moveDirection.x = horizontal;
        moveDirection.y = vertical;

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            currentDir.GetComponent<Animator>().SetBool("Idle", false);
            speed = 4f;
        }      
        else
        {
            currentDir.GetComponent<Animator>().SetBool("Idle", true);
            speed = 0;
        }
           

        if (horizontal < 0)
        {

            if ((!currentDir.Equals(leftDir) && Mathf.Abs(vertical) == 0) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                SetDirection(ref currentDir, leftDir);
            }
        }

        if (horizontal > 0)
        {
            if ((!currentDir.Equals(rightDir) && Mathf.Abs(vertical) == 0) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                SetDirection(ref currentDir, rightDir);
            }
        }

        if (vertical < 0)
        {
            if ((!currentDir.Equals(downDir) && Mathf.Abs(horizontal) == 0) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                SetDirection(ref currentDir, downDir);
            }
        }

        if (vertical > 0)
        {
            if ((!currentDir.Equals(upDir) && Mathf.Abs(horizontal) == 0)  || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                SetDirection(ref currentDir, upDir);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.instance.UpdateHitPoints(5);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentDir.GetComponent<Animator>().SetTrigger("Thrust");
            //currentDir.GetComponent<Animator>().SetBool("Attacking", true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //currentDir.GetComponent<Animator>().SetTrigger("Swing");
            //isAttacking = true;
            Debug.Log("currnt dir name " + currentDir.name);
			currentDir.GetComponent<Animator>().SetTrigger("Swing");
            //currentDir.GetComponent<Animator>().SetBool("Attacking", true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            currentDir.GetComponent<Animator>().SetTrigger("Bow");
            //isAttacking = true;
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);

    }

    // happens after update
    void LateUpdate()
    {
        // clamps the player movement between tilemap (xMinimum + camerawidth / 2) etc
        // using the tilemapInfo.cs script to be reusable by every scene that has different sizes.
        transform.position = new Vector3(Mathf.Clamp(ti.target.position.x, ti.playerXmin, ti.playerXmax),
                                         Mathf.Clamp(ti.target.position.y, ti.playerYmin, ti.playerYmax),0);


    }

    /// <summary>
    /// Disable the current direction and enable the new direction, then restart the animation
    /// </summary>
    /// <param name="currentDir">Direction the character is currently facing.</param>
    /// <param name="newDir">The new Direction the character will face</param>
    private void SetDirection(ref GameObject currentDir, GameObject newDir)
    {
        currentDir.SetActive(false);
        currentDir = newDir;
        currentDir.SetActive(true);
        currentDir.GetComponent<Animator>().Play(0);
        currentDir.GetComponent<Animator>().SetBool("Idle", false);
    }

    public void TakeDamage()
    {
        // taking damage
        currentDir.GetComponent<Animator>().SetTrigger("Hurt");

        if (currentDir.Equals(downDir))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + damageFallBack, 0);
        }
        else if (currentDir.Equals(upDir))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - damageFallBack, 0);
        }
        else if (currentDir.Equals(rightDir))
        {
            transform.position = new Vector3(transform.position.x - damageFallBack, transform.position.y, 0);
        }
        else if (currentDir.Equals(leftDir))
        {
            transform.position = new Vector3(transform.position.x + damageFallBack, transform.position.y, 0);
        }

        // update the UI
        GameManager.instance.UpdateHitPoints(-1);
        Debug.Log("Damage " + GameManager.instance.HitPoints);

        if (GameManager.instance.HitPoints <= 0)
        {
            currentDir.GetComponent<Animator>().SetTrigger("Death");
        }
    }

}



//if (currentDir.GetComponent<Animator>()
//    Debug.Log("playing");
//else
//    Debug.Log("Not Playing");

//if (!isWalking && currentDir != null)
//{
//    currentDir.GetComponent<Animator>().SetBool("Idle", true);
//}   
// need to pause, or stop moving while attacking. 
// wait until the animation is finished.
//else if (!isAttacking) 
//{
//if (!FaderInit.StillFading())