using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingController : MonoBehaviour {

    public GameObject player;
   // public GameObject l_shoulder, r_shoulder, lu_arm, ll_arm, ru_arm, rl_arm, l_hand, r_hand, chest,
   // body, belt, hip, lu_leg, ll_leg, ru_leg, rl_leg, l_foot, r_foot;

    SpriteRenderer l_shoulderSR, r_shoulderSR, lu_armSR, ll_armSR, ru_armSR, rl_armSR, l_handSR, r_handSR, chestSR,
        bodySR, beltSR, hipSR, lu_legSR, ll_legSR, ru_legSR, rl_legSR, l_footSR, r_footSR;

    public Dictionary<string, Sprite> dictSprites = new Dictionary<string, Sprite>();

    void Start ()
    {
        // should find by name "__right foot slot"
        //r_footSR = GameObject.Find("__right foot slot").GetComponent<SpriteRenderer>();
        //l_shoulderSR = l_shoulder.GetComponent<SpriteRenderer>();
        //r_shoulderSR = r_shoulder.GetComponent<SpriteRenderer>();
        //lu_armSR = lu_arm.GetComponent<SpriteRenderer>();
        //ll_armSR = ll_arm.GetComponent<SpriteRenderer>();
        //ru_armSR = ru_arm.GetComponent<SpriteRenderer>();
        //rl_armSR = rl_arm.GetComponent<SpriteRenderer>();
        //l_handSR = l_hand.GetComponent<SpriteRenderer>();
        //r_handSR = r_hand.GetComponent<SpriteRenderer>();
        //chestSR = chest.GetComponent<SpriteRenderer>();
        chestSR = GameObject.Find("__chest slot").GetComponentInChildren<SpriteRenderer>(); 
        //bodySR = body.GetComponent<SpriteRenderer>();
        //beltSR = belt.GetComponent<SpriteRenderer>();
        //hipSR = hip.GetComponent<SpriteRenderer>();
        //lu_legSR = lu_leg.GetComponent<SpriteRenderer>();
        //ll_legSR = ll_leg.GetComponent<SpriteRenderer>();
        //ru_legSR = ru_leg.GetComponent<SpriteRenderer>();
        //rl_legSR = rl_leg.GetComponent<SpriteRenderer>();
        //l_footSR = l_foot.GetComponent<SpriteRenderer>();
       // r_footSR = r_foot.GetComponent<SpriteRenderer>();

        Sprite[] sprites = Resources.LoadAll<Sprite>("Male Character Atlas");

        foreach (Sprite sprite in sprites)
        {
            dictSprites.Add(sprite.name, sprite);
            if (sprite.name.StartsWith("Equipment Down|"))
            {
                //Debug.Log(sprite.name);
            }
         }
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
           // equipmentSpriteRenderer.sprite = dictSprites["Head Objects|Hair|hair_4_down"];

            //l_shoulderSR.sprite = dictSprites[""];
            //r_shoulderSR.sprite = dictSprites[""];
            //lu_armSR.sprite = dictSprites[""];
            //ll_armSR.sprite = dictSprites[""];
            //ru_armSR.sprite = dictSprites[""];
            //rl_armSR.sprite = dictSprites[""];
            //l_handSR.sprite = dictSprites[""];
            //r_handSR.sprite = dictSprites[""];
            chestSR.sprite = dictSprites["Equipment Down|Armours|armour_1_down_chest"];
            //bodySR.sprite = dictSprites[""];
            //beltSR.sprite = dictSprites[""];
            //hipSR.sprite = dictSprites[""];
            //lu_legSR.sprite = dictSprites[""];
            //ll_legSR.sprite = dictSprites[""];
            //ru_legSR.sprite = dictSprites[""];
            //rl_legSR.sprite = dictSprites[""];
            //l_footSR.sprite = dictSprites[""];
            //r_footSR.sprite = dictSprites[""];
        }
          
        
    }
}
