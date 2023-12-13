using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClips : MonoBehaviour
{
    public  AudioClip [] audioClips;
    public AudioSource AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GetComponent<AudioSource>();
    }

    public class AudioPLayer
    {
        public AudioClip[] audioClips;
        public AudioSource AudioManager;

        void PlayClip(string AudioType)
        {
            if (AudioType == "Coin")
            {
                AudioManager.PlayOneShot(audioClips[0]);
            }
            else if (AudioType == "DoorOpen")
            {
                AudioManager.PlayOneShot(audioClips[1]);
            }
            else if (AudioType == "KeyPickup")
            {
                AudioManager.PlayOneShot(audioClips[2]);
            }
            else if (AudioType == "LevelDone")
            {
                AudioManager.PlayOneShot(audioClips[1]);
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
