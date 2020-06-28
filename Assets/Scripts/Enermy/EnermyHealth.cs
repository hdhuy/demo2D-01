using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyHealth : MonoBehaviour
{
    public GameObject BloodBar;
    public float Blood;
    public ParticleSystem BloodEff;
    public ParticleSystem DestroyEff;
    public GameObject Coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("player_bullet"))
        {
            beShoot(collision);
        }
    }
    private void beShoot(Collider2D collision)
    {
        //music
        if (GetComponent<EnermySound>() != null)
        {
            GetComponent<EnermySound>().eHurt();
        }
        //cây máu
        Blood -= collision.GetComponent<BulletMove>().Damage;
        Destroy(collision.gameObject);
        float size = Blood / 100;
        BloodBar.transform.localScale = new Vector3(size, 1, 1);
        //hiệu ứng máu
        GameObject a = Instantiate(BloodEff.gameObject, transform.position,Quaternion.identity);
        a.GetComponent<ParticleSystem>().Play();
        if (Blood <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        GameObject a = Instantiate(DestroyEff.gameObject, transform.position, Quaternion.identity);
        a.GetComponent<ParticleSystem>().Play();
        GameObject coin = Instantiate(Coin, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
