using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
     private AudioSource _music;
     private AudioSource _effect;

    public GameObject bgMusic;
    public GameObject bgEffect;

     private void Awake()
     {
        if(GameObject.Find("sentenceMusic") != null){
            Destroy(GameObject.Find("sentenceMusic"));
        }
        if (GameObject.Find("bgMusic(Clone)") == null)
        {
            Instantiate(bgMusic);
        }
        DontDestroyOnLoad(GameObject.Find("bgMusic(Clone)"));
        if (GameObject.Find("bgEffect") == null)
        {
            Instantiate(bgEffect);
        }
        DontDestroyOnLoad(GameObject.Find("bgEffect(Clone)"));
        updateMusic();
     }
    public void updateMusic(){
        _music = GameObject.Find("bgMusic(Clone)").GetComponent<AudioSource>();
        _effect = GameObject.Find("bgEffect(Clone)").GetComponent<AudioSource>();
    
        _music.volume = PlayerPrefs.GetFloat("music");
        _effect.volume = PlayerPrefs.GetFloat("effect");
    }
     public void PlayMusic()
     {
         if (_music.isPlaying) return;
         _music.Play();
     }
 
     public void StopMusic()
     {
         _music.Stop();
     }
}
