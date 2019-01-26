using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManySongs : MonoBehaviour
{
    public AudioClip audioC;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        source.PlayOneShot(audioC, 1f);
    }
}
