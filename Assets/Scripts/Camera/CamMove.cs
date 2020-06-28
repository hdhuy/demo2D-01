using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Target;
    private void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 v= Target.transform.position;
            transform.position = new Vector3(v.x,0,-10);
        }
    }
}
