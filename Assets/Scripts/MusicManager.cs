using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> musicLevel = new List<AudioSource>();
    [SerializeField] AudioSource musicDead;
    [SerializeField] GameObject SoundButtonOn;
    [SerializeField] GameObject SoundButtonOff;
    public int musicStepLevel;
    public int musicIndex = 0;
    private bool isSoundOn = true;

    void Start()
    {
        musicLevel[musicIndex].Play();
    }
    public void ActivateLevelMusic(int score)
    {
        for (int i = 0; i < musicLevel.Count; i++)
        {
            if (score == i* musicStepLevel)
            {
                playNextLevelMusic();
                break;
            }        
        } 
    }
    public void playNextLevelMusic()
    {
        musicIndex++;
        musicLevel[musicIndex-1].Stop();
        musicLevel[musicIndex].Play();
    }
    public void playDeadMusic()
    {
        if(!musicDead.isPlaying)
        {
            musicLevel[musicIndex].Stop();
            musicDead.Play();
        }
    }

    public void TurnTheSoundOffOrOn()
    {
        if(isSoundOn)
        {
            AudioListener.volume = 0;
            isSoundOn = false;
            SoundButtonOn.SetActive(false);
            SoundButtonOff.SetActive(true);

        }
        else
        {
            AudioListener.volume = 1f;
            isSoundOn = true;
            SoundButtonOn.SetActive(true);
            SoundButtonOff.SetActive(false);
        }
            
    }

}
