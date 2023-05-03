using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {

    public enum Sound {
        RigtigFodring,
        ForkertFodring,
        StartFodring

        // to play a sound: SoundManager.PlaySound(SoundManager.Sound.StartFodring);
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Initialize() {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.StartFodring] = 0f;

    }

    public static void PlaySound(Sound sound) {
        if (CanPlaySound(sound)) {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource AudioSource = soundGameObject.AddComponent<AudioSource>();
        AudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    private static bool CanPlaySound(Sound sound) {
        switch (sound) {
        default:
            return true;
        case Sound.StartFodring:
            if (soundTimerDictionary.ContainsKey(sound)) {
                float lastTimePlayed = soundTimerDictionary[sound];
                float StartFodringTimerMax = 0.5f; // how often at most should this sound be played?
                if (lastTimePlayed + StartFodringTimerMax < Time.time) {
                    soundTimerDictionary[sound] = Time.time;
                    return true; 
                } else {
                    return false;
                }
            } else {
                return true;
            }
            //break;
        }
    }


    private static AudioClip GetAudioClip(Sound sound) {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray) {
            if (soundAudioClip.sound == sound) {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + "not found!");
        return null;

    }
}
