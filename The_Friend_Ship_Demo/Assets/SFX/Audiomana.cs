using System;

using UnityEngine;
using UnityEngine.Audio;
public class Audiomana : MonoBehaviour
{


    #region Singelton
    public static Audiomana Audioinstance;

    private void Awake() {
        Audioinstance = this;
    }
    #endregion

    public Sound[] Sounds;
        
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var clip in Sounds) {
            clip.source = gameObject.AddComponent<AudioSource>();
            clip.source.clip = clip.Clip;
            clip.source.volume = clip.Volume;
            clip.source.pitch = clip.Pitch;
            clip.source.loop = clip.loop;
        }
    }

   public void Play(string AudClip) 
   {
       
      Sound S =  Array.Find(Sounds, sound => sound.Name == AudClip);
        
        if (S == null) {
            return;
        }
        if (S.RandomSelction) {
            int Soundtoplay = UnityEngine.Random.Range(0, S.Clips.Length-1);
            S.source.clip = S.Clips[Soundtoplay];
            S.source.Play();

        } else {
            S.source.Play();
        }
    }
    public void Stop(string AudClip) {
        Sound S = Array.Find(Sounds, sound => sound.Name == AudClip);
        if (S == null) {
            return;
        }
        S.source.Stop();
    }

    
    
}
