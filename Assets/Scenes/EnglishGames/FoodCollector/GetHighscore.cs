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
    }

}
