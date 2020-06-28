using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Player
{
    public Animator Hand;
    public Animator Head;
    public Animator Foot;
    void Update()
    {
        if (isMoving.Equals(true))
        {
            if (isFlying)
            {
                Foot.SetInteger("a", 2);
                Head.SetBool("idle", false);
            }
            else
            {
                Hand.SetBool("idle", false);
                Head.SetBool("idle", false);
                Foot.SetInteger("a", 1);
            }
        }
        else
        {
            Hand.SetBool("idle", true);
            Head.SetBool("idle", true);
            if (isFlying)
            {
                Foot.SetInteger("a", 2);
            }
            else
            {
                Foot.SetInteger("a", 0);
            }
        }
    }
}
