using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager 
{
    #region Fields

    private static bool  initialized = false;
    private static AudioSource audioSource;
    private static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    #endregion

    #region properties

    public static bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    #region Public Methods

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        
        audioClips.Add(AudioClipName.PickScredriver,
            Resources.Load<AudioClip>("التقط المفك"));
        audioClips.Add(AudioClipName.BakraDecomposition,
            Resources.Load<AudioClip>("فك البكرة"));
        audioClips.Add(AudioClipName.PickBensa,
            Resources.Load<AudioClip>("التقط البنسة"));
        audioClips.Add(AudioClipName.NutDecomposition,
            Resources.Load<AudioClip>("فك الصامولة"));
        audioClips.Add(AudioClipName.NutComposition,
            Resources.Load<AudioClip>("ركب الصامولة"));
        audioClips.Add(AudioClipName.BakraComposition,
            Resources.Load<AudioClip>("ركب البكرة"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    #endregion
}
