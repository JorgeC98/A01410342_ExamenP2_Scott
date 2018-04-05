using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private PlayerControl player;



    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<PlayerControl>();

    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player.grounded = true;
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player.grounded = false;
        }
    }
}
        


