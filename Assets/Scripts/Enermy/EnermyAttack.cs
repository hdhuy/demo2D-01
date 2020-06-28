using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyAttack : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform Gun;
    public GameObject GunHand;
    public GameObject Head;
    public float RotSpeed = 30f;
    public float TargetDistance;
    public float ShootDelay;
    public GameObject Graphic;
    public float Damage;
    private GameObject Target;
    private bool ReadyToShoot=true;
    private void FixedUpdate()
    {
        if (GameObject.Find("Player") != null)
        {
            Target = GameObject.Find("Player");
            //xoay theo mục tiêu 
            LookAt(Target.transform.position);
            //bắn
            float dist = Vector2.Distance(Target.transform.position, transform.position);
            if (dist <= TargetDistance)
            {
                if (ReadyToShoot)
                {
                    StartCoroutine(StartShoot());
                }
            }
        }
        else
        {
            GetComponent<EnermyAttack>().enabled = false;
        }
        
    }
    IEnumerator StartShoot()
    {
        Shoot();
        ReadyToShoot = false;
        yield return new WaitForSeconds(ShootDelay);
        ReadyToShoot = true;
    }
    private void Shoot()
    {
        GameObject a = Instantiate(Bullet, Gun.position, Gun.rotation);
        a.GetComponent<BulletMove>().Damage = Damage;
        a.GetComponent<BulletMove>().Speed = BulletSpeed;
        a.tag = "enermy_bullet";
        a.transform.parent = GameObject.Find("BULLET CONTAINER").transform;
        Destroy(a, 3);
    }
    private void LookAt(Vector3 Target)
    {
        if (Target.x >= transform.position.x)
        {
            Graphic.transform.localScale = new Vector3(1, 1, 1);
            GunHand.transform.localScale = new Vector3(1, 1, 1);
            Head.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Graphic.transform.localScale = new Vector3(-1, 1, 1);
            GunHand.transform.localScale = new Vector3(-1, -1, 1);
            Head.transform.localScale = new Vector3(-1, -1, 1);
        }
        Vector3 direction = Target - GunHand.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GunHand.transform.rotation = Quaternion.Slerp(GunHand.transform.rotation, rotation, RotSpeed * Time.deltaTime);
        Head.transform.rotation = Quaternion.Slerp(Head.transform.rotation, rotation, RotSpeed * Time.deltaTime);
    }
}
