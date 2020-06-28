using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed;
    public float Damage;
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(Speed,0));
    }
}
