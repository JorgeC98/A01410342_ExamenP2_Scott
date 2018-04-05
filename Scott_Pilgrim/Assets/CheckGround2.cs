using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround2 : MonoBehaviour
{


    private PlayerControl player2;



    // Use this for initialization
    void Start()
    {
        player2 = GetComponentInParent<PlayerControl>();

    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player2.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player2.grounded = false;
        }
    }
}
