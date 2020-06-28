using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Player
{
    public float Speed;
    public float JumpForce;
    public float TimeSetTrigger;
    private Vector2 Move;
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v= Input.GetAxis("Vertical");
        if (h == 0)
        {
            Idle();
        }
        else
        {
            if (h > 0)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
        //
        if (v > 0|| Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        transform.Translate(Move * Time.deltaTime * Speed);
    }
    private void MoveLeft()
    {
        Move = new Vector2(-Speed, 0);
        isMoving = true;
        if (isHaveTarget == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        isTurnRight = false;
    }
    private void MoveRight()
    {
        Move = new Vector2(Speed, 0);
        isMoving = true;
        if (isHaveTarget == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        isTurnRight = true;
    }
    private void Idle()
    {
        Move = new Vector2(0, 0);
        isMoving = false;
    }
    private void Jump()
    {
        if (isFlying.Equals(false))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
            isFlying = true;
            StartCoroutine(setTrigger());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isFlying = false;
        }
        
    }
    IEnumerator setTrigger()
    {
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(TimeSetTrigger);
        GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
}
