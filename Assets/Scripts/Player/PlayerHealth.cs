using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Player
{
    public float Blood;
    public ParticleSystem BloodEff;
    public ParticleSystem DestroyEff;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("enermy_bullet"))
        {
            beShoot(collision.GetComponent<BulletMove>().Damage);
            Destroy(collision.gameObject);
        }
        if (collision.tag.Equals("buff"))
        {
            Blood += collision.GetComponent<HearthItem>().Buff;
            if (Blood > 100)
            {
                Blood = 100;
            }
            UI.changeBloodBar(Blood);
            Destroy(collision.gameObject);
        }
        if (collision.tag.Equals("Dead"))
        {
            beShoot(100);
        }
    }
    public void beShoot(float damage)
    {
        //hiệu ứng máu
        GameObject a = Instantiate(BloodEff.gameObject, transform.position, Quaternion.identity);
        a.GetComponent<ParticleSystem>().Play();
        //cây máu
        Blood -= damage;
        if (Blood <= 0)
        {
            Blood = 0;
            Dead();
        }
        UI.changeBloodBar(Blood);
    }
    private void Dead()
    {
        if (isEndGame==false)
        {
            isEndGame = true;
            //music
            if (GetComponent<PlayerSound>() != null)
            {
                GetComponent<PlayerSound>().PlayerDie();
            }
            //eff
            GameObject a = Instantiate(DestroyEff.gameObject, transform.position, Quaternion.identity);
            a.GetComponent<ParticleSystem>().Play();
            //UI
            UI.PlayerDead();
            if (GetComponent<PlayerAttack>() != null)
            {
                GetComponent<PlayerAttack>().enabled = false;
            }
            Destroy(gameObject,1);
        }
    }
}
