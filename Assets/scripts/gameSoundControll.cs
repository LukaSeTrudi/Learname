using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSoundControll : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource aus;
    public string pref;
    void Start()
    {
        aus = GetComponent<AudioSource>();
        aus.volume = PlayerPrefs.GetFloat(pref);
        if(GameObject.Find("bgMusic(Clone)")){
            Destroy(GameObject.Find("bgMusic(Clone)"));
            Destroy(GameObject.Find("bgEffect(Clone)"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
