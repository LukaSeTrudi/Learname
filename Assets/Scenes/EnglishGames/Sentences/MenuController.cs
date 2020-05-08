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
    
    private int lvl;
    void Start()
    {
        lvl = PlayerPrefs.GetInt(pref);
        level.text = lvl + " / " + maxSentences;
        smth_image.fillAmount = (float)lvl/maxSentences;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
