using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public AudioClip button_click;

    public void ButtonEffect(){
        if(GameObject.Find("bgEffect") != null){
            GameObject.Find("bgEffect").GetComponent<AudioSource>().PlayOneShot(button_click);
        }
    }
}
