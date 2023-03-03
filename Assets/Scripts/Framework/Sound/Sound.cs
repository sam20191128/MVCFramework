using UnityEngine;

public class Sound : Singleton<Sound>
{
    private AudioSource m_Bgm;
    private AudioSource m_Effect;
    public string ResourcesDir = "";

    protected override void Awake()
    {
        base.Awake();
        m_Bgm = gameObject.AddComponent<AudioSource>();
        m_Effect = gameObject.AddComponent<AudioSource>();
        m_Bgm.playOnAwake = false;
        m_Bgm.loop = true;
    }

    //播放背景音乐
    public void PlayBGM(string audioName)
    {
        string oldName;

        if (m_Bgm.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = m_Bgm.clip.name;
        }

        if (oldName != audioName)
        {
            //加载
            string path = ResourcesDir + "/" + audioName;
            AudioClip audioClip = Resources.Load<AudioClip>(path);

            //播放
            if (audioClip != null)
            {
                m_Bgm.clip = audioClip;
                m_Bgm.Play();
            }
        }
    }

    //音效
    public void PlayEffect(string audioName)
    {
        string path = ResourcesDir + "/" + audioName;

        AudioClip audioClip = Resources.Load<AudioClip>(path);

        //播放
        m_Effect.PlayOneShot(audioClip);
    }
}