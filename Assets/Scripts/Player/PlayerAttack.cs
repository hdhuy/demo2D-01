using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform Gun;
    public GameObject GunHand;
    public GameObject Head;
    public float RotSpeed = 50f;
    public float TargetDistance;
    public float ShootDelay;
    public float Damage;
    private Vector3 Target;
    private bool ReadyToShoot = true;
    private void FixedUpdate()
    {
        FindTarget();
        //xoay theo mục tiêu 
        if (isHaveTarget)
        {
            LookAt(Target);
        }
        //bắn
        if (Input.GetMouseButtonDown(0))
        {
            if (isEndGame == false)
            {
                if (ReadyToShoot)
                {
                    StartCoroutine(StartShoot());
                }
            }
        }
        //win
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enermy");
        if (list.Length == 0)
        {
            StartCoroutine(WinGame());
        }
    }
    IEnumerator WinGame()
    {
        isEndGame = true;
        yield return new WaitForSeconds(2);
        if (GetComponent<PlayerMove>() != null)
        {
            GetComponent<PlayerMove>().enabled=false;
        }
        UI.PlayerWin();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("pow"))
        {
            StartCoroutine(Pow(collision.GetComponent<PowerItem>()));
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Pow(PowerItem p)
    {
        GameObject cBullet = Bullet;
        float cDamage = Damage;
        //
        Bullet = p.Bullet;
        Damage = p.Damage;
        yield return new WaitForSeconds(p.Time);
        Bullet = cBullet;
        Damage = cDamage;
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
        //music
        if (GetComponent<PlayerSound>() != null)
        {
            GetComponent<PlayerSound>().PlayerShoot();
        }
        //eff
        GameObject a = Instantiate(Bullet, Gun.position, Gun.rotation);
        a.tag = "player_bullet";
        a.GetComponent<BulletMove>().Damage = Damage;
        if (isHaveTarget)
        {
            a.GetComponent<BulletMove>().Speed = BulletSpeed;
        }
        else
        {
            if (isTurnRight)
            {
                a.GetComponent<BulletMove>().Speed = BulletSpeed;
            }
            else
            {
                a.GetComponent<BulletMove>().Speed = -BulletSpeed;
            }
        }
        a.transform.parent = GameObject.Find("BULLET CONTAINER").transform;
        Destroy(a, 3);
    }
    private void LookAt(Vector3 Target)
    {
        if (Target.x >= transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            GunHand.transform.localScale = new Vector3(1, 1, 1);
            Head.transform.localScale = new Vector3(1, 1, 1);
            isTurnRight = true;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GunHand.transform.localScale = new Vector3(-1, -1, 1);
            Head.transform.localScale = new Vector3(-1, -1, 1);
            isTurnRight = false;
        }
        Vector3 direction = Target - GunHand.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GunHand.transform.rotation = Quaternion.Slerp(GunHand.transform.rotation, rotation, RotSpeed * Time.deltaTime);
        Head.transform.rotation = Quaternion.Slerp(Head.transform.rotation, rotation, RotSpeed * Time.deltaTime);
    }
    private void FindTarget()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enermy");
        Transform tMin = null;
        if (list.Length > 0)
        {
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            //float distance = Vector2.Distance(transform.position, list[0].transform.position);
            foreach (GameObject t in list)
            {
                float dist = Vector2.Distance(t.transform.position, currentPos);
                if (dist < minDist && dist < TargetDistance)
                {
                    tMin = t.transform;
                    minDist = dist;
                }
            }
            if (tMin != null)
            {
                Target = tMin.position;
                isHaveTarget = true;
            }
        }
        //nếu không có target
        if (tMin == null)
        {
            GunHand.transform.eulerAngles = new Vector3(0, 0, 0);
            Head.transform.eulerAngles = new Vector3(0, 0, 0);

            GunHand.transform.localScale = new Vector3(1, 1, 1);
            Head.transform.localScale = new Vector3(1, 1, 1);

            isHaveTarget = false;
        }
    }
}
