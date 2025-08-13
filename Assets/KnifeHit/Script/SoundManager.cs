using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource efxSource;
    public AudioClip btnSfx;
    public AudioClip timeSfx;

    private void Awake()
    {
        // Nếu chưa có instance, gán và giữ lại khi load scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Xóa bớt bản trùng
        }
    }

    /// <summary>
    /// Phát 1 âm thanh 1 lần
    /// </summary>
    public void PlaySingle(AudioClip clip, float vol = 1f)
    {
        if (GameManager.Sound && clip != null)
        {
            efxSource.PlayOneShot(clip, vol);
        }
    }


    public void PlayBackgroundMusic(AudioClip music, float vol = 1f)
    {
        if (GameManager.Sound && music != null)
        {
            efxSource.clip = music;
            efxSource.volume = vol;
            efxSource.loop = true;
            efxSource.Play();
        }
    }
    /// <summary>
    /// Phát nhạc timer (loop)
    /// </summary>
    public void PlayTimerSound()
    {
        if (GameManager.Sound && timeSfx != null)
        {
            efxSource.clip = timeSfx;
            efxSource.loop = true;
            efxSource.Play();
        }
    }

    /// <summary>
    /// Dừng nhạc timer
    /// </summary>
    public void StopTimerSound()
    {
        efxSource.Stop();
        efxSource.clip = null;
    }

    public void PlaybtnSfx()
    {
        PlaySingle(btnSfx);
    }

    public void playVibrate()
    {
        if (GameManager.Vibration)
            Handheld.Vibrate();
    }
}
