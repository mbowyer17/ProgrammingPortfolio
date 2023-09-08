using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip npcHit;
    [SerializeField] AudioClip npcShoot;
    [SerializeField] AudioClip pickupSound;
    [SerializeField] AudioClip clickSound;
    AudioSource audioSource;
    float defaultlevel = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   
    public void AudioNpcHit()
    {
        audioSource.PlayOneShot(npcHit, defaultlevel);
    }

    public void AudioNpcShoot()
    {
        audioSource.PlayOneShot(npcShoot, defaultlevel);

    }

    public void AudioClickSound()
    {
        audioSource.PlayOneShot(clickSound, defaultlevel);

    }

    public void AudioPickupSound()
    {
        audioSource.PlayOneShot(pickupSound, defaultlevel);

    }
}
