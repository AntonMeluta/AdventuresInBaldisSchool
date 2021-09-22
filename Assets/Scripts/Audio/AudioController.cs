using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{   
    private Dictionary<SoundEffect, AudioClip> dict;

    public SoundDefinition[] allSounds;
    public AudioSource audioSounds;

    private void Awake()
    {
        dict = new Dictionary<SoundEffect, AudioClip>();

        for (int i = 0; i < allSounds.Length; i++)
            dict.Add(allSounds[i].effect, allSounds[i].clip);
    }

    public void PlaySoundEffect(SoundEffect soundType)
    {
        //AudioClip effect = SoundFX.Find(sfx => sfx.effect == soundEffect).clip;
        AudioClip sound = dict[soundType];
        audioSounds.PlayOneShot(sound);
    }
}
