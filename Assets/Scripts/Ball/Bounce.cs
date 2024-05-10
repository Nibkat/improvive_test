using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    
    [Serializable]
    public struct SFX {
        public PhysicMaterial physicMaterial;
        public AudioClip audioClip;
    }
    [SerializeField] private SFX[] sfxs;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < sfxs.Length; i++)
        {
            // compare if the hit collider matches a specified physic material and play the associated clip if a match is found
            if (other.collider.sharedMaterial == sfxs[i].physicMaterial)
            {
                _audioSource.PlayOneShot(sfxs[i].audioClip);
            }
        }
    }
}