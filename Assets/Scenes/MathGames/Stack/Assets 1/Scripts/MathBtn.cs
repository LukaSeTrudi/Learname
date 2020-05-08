using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public double value;
    public GameObject _parent;

    private Text txtObject;
    private Button myBtn;

    void Start()
    {
        txtObject = transform.GetChild(0).GetComponent<Text>();
        txtObject.text = value+"";
        myBtn = gameObject.GetComponent<Button>();
        myBtn.onClick.AddListener(btnClick);
    }

    void btnClick(){
        _parent.GetComponent<MathStackScene>().checkValid(value);
    }
}
