using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    public float Speed;
    public GameObject Graphic;
    private Vector2 move;
    private void FixedUpdate()
    {
        move = new Vector2(Speed, 0);
        transform.Translate(move*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("enermy_turn"))
        {
            Speed *= -1;
            Graphic.transform.localScale = new Vector3(Graphic.transform.localScale.x*-1, 1, 1);
        }
        
    }
}
