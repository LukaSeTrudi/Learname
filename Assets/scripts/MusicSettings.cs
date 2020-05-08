using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public string pref;
    private float sound_value;
    private Slider sl;
    void Start()
    {
        if(!PlayerPrefs.HasKey(pref)){
            PlayerPrefs.SetFloat(pref, 1.0f);
        }
        sound_value = PlayerPrefs.GetFloat(pref);
        sl = gameObject.GetComponent<Slider>();
        sl.value = sound_value;
    }

    public void onChangeVal(){
        float val = GetComponent<Slider>().value;
        PlayerPrefs.SetFloat(pref, val);
    }
}
