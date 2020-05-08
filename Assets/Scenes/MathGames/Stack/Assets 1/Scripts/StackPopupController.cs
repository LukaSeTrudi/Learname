using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackPopupController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite spr;
    private float time = 1.0f;
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = spr;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0){
            Destroy(gameObject);
        }
    }
}
