using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image smth_image;
    public Text level;
    public string pref;
    public int maxSentences;
    public Button btn;

    private int lvl;
    void Start()
    {
        lvl = PlayerPrefs.GetInt(pref);
        level.text = lvl + " / " + maxSentences;
        smth_image.fillAmount = (float)lvl/maxSentences;
        if(lvl >= maxSentences){
            btn.interactable = false;
        } else btn.interactable = true;
    }
    public void resetPlayerPref(){
        PlayerPrefs.DeleteKey(pref);
        lvl = PlayerPrefs.GetInt(pref);
        level.text = lvl + " / " + maxSentences;
        smth_image.fillAmount = (float)lvl/maxSentences;
        if(lvl >= maxSentences){
            btn.interactable = false;
        } else {
            btn.interactable = true;
        }
    }
}
