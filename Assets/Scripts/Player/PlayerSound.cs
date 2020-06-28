using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : Player
{
    public AudioClip Shoot;
    public AudioClip Die;
    private AudioSource au;
    private void Start()
    {
        au = GetComponent<AudioSource>();
    }
    public void PlayerDie()
    {
        au.PlayOneShot(Die);
    }
    public void PlayerShoot()
    {
        au.PlayOneShot(Shoot);
    }
}
