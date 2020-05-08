using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
     private AudioSource _audioSource;
     public string _pref;
     private void Awake()
     {
        int numMusicPlayers = GameObject.FindGameObjectsWithTag(_pref).Length;
        if (numMusicPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
         _audioSource = GetComponent<AudioSource>();
     }
    public void updateMusic(){
        AudioSource _mus = GameObject.Find("bgMusic").GetComponent<AudioSource>();
        AudioSource _eff = GameObject.Find("bgEffect").GetComponent<AudioSource>();
    
        _mus.volume = PlayerPrefs.GetFloat("music")/2;
        _eff.volume = PlayerPrefs.GetFloat("effect");
    }
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
}
