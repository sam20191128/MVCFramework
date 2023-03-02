using UnityEngine;
using UnityEngine.AddressableAssets;

public class Sound : Singleton<Sound>
{
    private AudioSource bgmSource;
    private AudioSource effectAudioSource;

    protected override void Awake()
    {
        base.Awake();
        bgmSource = gameObject.AddComponent<AudioSource>();
        effectAudioSource = gameObject.AddComponent<AudioSource>();
        bgmSource.playOnAwake = false;
        bgmSource.loop = true;
    }

    //播放背景音乐
    public async void PlayBGMAudio(string audioName)
    {
        string oldName;

        if (bgmSource.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = bgmSource.clip.name;
        }

        if (oldName != audioName)
        {
            //加载
            AudioClip audioClip = await Addressables.LoadAssetAsync<AudioClip>(audioName).Task;

            //播放
            if (audioClip != null)
            {
                bgmSource.clip = audioClip;
                bgmSource.Play();
            }

            Debug.Log(audioClip.name);
        }
    }

    //音效
    public async void PlayEffectAudio(string audioName)
    {
        AudioClip audioClip = await Addressables.LoadAssetAsync<AudioClip>(audioName).Task;
        
        //播放
        effectAudioSource.PlayOneShot(audioClip);
    }
}