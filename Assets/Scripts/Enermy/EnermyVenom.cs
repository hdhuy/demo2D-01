using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyVenom : MonoBehaviour
{
    public float Damage;
    public float TimeToAttack;
    public ParticleSystem VenomEff;
    IEnumerator Attack(PlayerHealth c)
    {
        c.beShoot(Damage);
        GameObject a = Instantiate(VenomEff.gameObject, transform.position, Quaternion.identity);
        a.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(TimeToAttack);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(Attack(collision.gameObject.GetComponent<PlayerHealth>()));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            StartCoroutine(Attack(collision.gameObject.GetComponent<PlayerHealth>()));
        }
    }
}
