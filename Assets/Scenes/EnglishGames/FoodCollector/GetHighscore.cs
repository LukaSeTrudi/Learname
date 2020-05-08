using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    public string pref;

    void Start()
    {
        gameObject.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt(pref);
        gameObject.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetFloat(pref);       
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetFloat(pref).ToString();
        
    }
}
