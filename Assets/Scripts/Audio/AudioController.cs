using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{   
    private Dictionary<SoundEffect, AudioClip> dict;

    public SoundDefinition[] allSounds;
    public AudioSource musicScene;
    public AudioSource audioSounds;

    private void Start()
    {
        dict = new Dictionary<SoundEffect, AudioClip>();

        for (int i = 0; i < allSounds.Length; i++)
            dict.Add(allSounds[i].effect, allSounds[i].clip);

        EventsBroker.EventRestartGame += RestartGame;
    }
    private void RestartGame()
    {
        PlayMusic(SoundEffect.MainTheme);
    }

    public void PlaySoundEffect(SoundEffect soundType)
    {
        //AudioClip effect = SoundFX.Find(sfx => sfx.effect == soundEffect).clip;
        AudioClip sound = dict[soundType];
        audioSounds.PlayOneShot(sound);
    }

    public void StopMusicGame()
    {
        musicScene.Stop();
    }

    public void PlayMusic(SoundEffect soundType)
    {
        //AudioClip effect = SoundFX.Find(sfx => sfx.effect == soundEffect).clip;
        AudioClip clip = dict[soundType];
        musicScene.clip = clip;
        musicScene.Play();
    }
}
