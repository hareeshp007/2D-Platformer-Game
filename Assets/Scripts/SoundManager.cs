using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
    public AudioSource SoundLevel;
    [Range(0f, 1f)] public float userVolume;
    public bool IsMute;
    public bool MoveLoop;
    public float Volume=1f;

    public SoundType[] Sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetVolume(userVolume);
        PlayMusic(global::Sounds.music);
    }
    public void Mute(bool status)
    {
        IsMute = status;
    }
    public void SetVolume(float volume)
    {
        Volume = volume;
        SoundEffect.volume = Volume;
        SoundMusic.volume = Volume;
    }
    public void PlayLevel(Sounds sound)
    {
        if (IsMute) return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundLevel.clip = clip;
            SoundLevel.Play();
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public void PlayMusic(Sounds sound)
    {
        if(IsMute)return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public void Play(Sounds sound)
    {
        if (IsMute) return;
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            if (FootstepLoop(sound)) {
                SoundEffect.clip = clip;
                SoundEffect.loop = true;
                SoundEffect.Play(); }
            else {
                SoundEffect.loop = false;
                SoundEffect.PlayOneShot(clip); }
            
            
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public bool FootstepLoop(Sounds sounds)
    {
        if (sounds == global::Sounds.PlayerMove)
        {
            MoveLoop = true;
        }
        else
        {
            MoveLoop = false;
        }
        return MoveLoop;
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType returnsound= Array.Find(Sounds, item => item.soundType == sound);
        if(returnsound != null)
        {
            return returnsound.soundclip;
        }
        return null;
    }

    public void StopEffect()
    {
        SoundEffect.Stop();
    }
}


[Serializable]public class SoundType
{
    public Sounds soundType;
    public AudioClip soundclip;
}
public enum Sounds
{
    ButtonClick,
    PlayerMove,
    PlayerDied,
    EnemyDeath,
    music,
    PlayerHurt,
    LevelFinished,
    LevelStarted,
    collect
}
