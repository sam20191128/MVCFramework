using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Sound : Singleton<Sound>
{
    private AudioSource m_Bg;
    private AudioSource m_effect;

    protected override void Awake()
    {
        base.Awake();
        m_Bg = gameObject.AddComponent<AudioSource>();
        m_effect = gameObject.AddComponent<AudioSource>();
        m_Bg.playOnAwake = false;
        m_Bg.loop = true;
    }

    //播放背景音乐
    public async void PlayBG(string audioName)
    {
        string oldName;
        if (m_Bg.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = m_Bg.clip.name;
        }

        if (oldName != audioName)
        {
            //加载
            AudioClip clip = await Addressables.LoadAssetAsync<AudioClip>(audioName).Task;

            //播放
            if (clip != null)
            {
                m_Bg.clip = clip;
                m_Bg.Play();
            }
        }
    }

    //音效
    public async void PlayEffect(string audioName)
    {
        AudioClip clip = await Addressables.LoadAssetAsync<AudioClip>(audioName).Task;
        //播放
        m_effect.PlayOneShot(clip);
    }
}