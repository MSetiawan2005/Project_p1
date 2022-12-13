using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource[] SFXs;
    [SerializeField] private AudioSource[] BGMs;
    
    

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SFXs = new AudioSource[Resources.LoadAll("SFX").Length];
        CharachterProperties properties = Resources.Load<CharachterProperties>("CharachterData");
        for (int i = 0; i < SFXs.Length; i++)
        {
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            a.AddComponent<AudioSource>();
            DontDestroyOnLoad(a);
            a.transform.position = new Vector3(100,100,100);
            SFXs[i] =  a.GetComponent<AudioSource>();
            SFXs[i].clip = Resources.LoadAll("SFX")[i] as AudioClip;
            SFXs[i].playOnAwake = false;
            a.name = SFXs[i].clip.name;
            if (properties.audioMaster) SFXs[i].mute = !properties.sfx;
            else SFXs[i].mute = true;
        }

        BGMs = new AudioSource[Resources.LoadAll("BGM").Length];
        for (int i = 0; i < BGMs.Length; i++)
        {
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            a.AddComponent<AudioSource>();
            DontDestroyOnLoad(a);
            a.transform.position = new Vector3(100, 100, 100);
            BGMs[i] = a.GetComponent<AudioSource>();
            BGMs[i].clip = Resources.LoadAll("BGM")[i] as AudioClip;
            BGMs[i].loop = true;
            BGMs[i].playOnAwake = false;
            if(i != 0 && i != BGMs.Length-1)
            {
                BGMs[i].volume = 0.4f;
            }
            a.name = BGMs[i].clip.name;

            if (properties.audioMaster) BGMs[i].mute = !properties.bgm;
            else BGMs[i].mute = true;
        }
    }

    private void Start()
    {
        
    }

    public void PlaySFX(SFX audio)
    {
        foreach (AudioSource source in SFXs)
        {
            if (source.clip.name == audio.ToString())
            {
                if(!source.isPlaying) source.Play();
                return;
            }
        }
    }

    public void PlayBGM(int i)
    {
        for(int j = 0; j < BGMs.Length; j++)
        {
            if (j != i) BGMs[j].Stop();
            else {
                if (!BGMs[j].isPlaying)
                    BGMs[j].Play();
                
            }
        }
    }

    public void SFXMuteOption(bool isMute)
    {
        foreach (AudioSource source in SFXs)
        {
            source.mute = isMute;
        }
    }

    public void BGMMuteOption(bool isMute)
    {
        foreach (AudioSource source in BGMs)
        {
            source.mute = isMute;
        }
    }

    public void MasterMuteOption(bool isMute)
    {
        SFXMuteOption(isMute);
        BGMMuteOption(isMute);
    }
}

public enum BGM
{
    BGM_Menu
}

public enum SFX
{
    Player_Run,
    Player_Fall,
    Player_Jump,
    Player_Death,
    Player_PushBox,
    Player_ShootGun,
    Door_OpenOne,
    Door_OpenTwo,
    Button_Click,
}
