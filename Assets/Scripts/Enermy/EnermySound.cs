using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySound : MonoBehaviour
{
    public AudioClip Hurt;
    private AudioSource au;
    private void Start()
    {
        au = GetComponent<AudioSource>();
    }
    public void eHurt()
    {
        au.PlayOneShot(Hurt);
    }
}
