using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
public class MathStackScene : MonoBehaviour
{
    // Start is called before the first frame update

    public string operations = "*/-+";
    public GameObject btn;
    public Sprite success;
    public Sprite fail;
    public GameObject end;

    private RectTransform rt;
    private int _i = Screen.width;
    private int firstnum, secondNum;
    private char operation;
    private Text equationText;
    private double rez;
    private GameObject btns;
    void Start()
    {
        btns = GameObject.Find("grid");
        equationText = GameObject.Find("EquationText").GetComponent<Text>();
        rt = (RectTransform)gameObject.transform;
        operations = "*/-+";
        operation = operations[UnityEngine.Random.Range(0, operations.Length-1)];
        firstnum = UnityEngine.Random.Range(0, 10);
        secondNum = UnityEngine.Random.Range(1, 10);
        equationText.text = firstnum + " " + operation + " " + secondNum;
        string op = Convert.ToString(firstnum)+operation+secondNum;
        rez = Math.Round(Convert.ToDouble(new DataTable().Compute(op, null)),1);
        loadBtns();
    }

    void loadBtns(){
        int correct = UnityEngine.Random.Range(0, 4);
        for(int i = 0; i< 4; i++){
            GameObject go = Instantiate(btn, btns.transform);
            go.GetComponent<MathBtn>()._parent = gameObject;
            if(correct == i){
                go.GetComponent<MathBtn>().value = rez;
            } else {
                if(rez % 1 == 0){
                    go.GetComponent<MathBtn>().value = UnityEngine.Random.Range((int)rez-5, (int)rez+10);
                } else {
                    go.GetComponent<MathBtn>().value = Math.Round(UnityEngine.Random.Range((float)rez-5.0f, (float)rez+10.0f), 1);    
                }
            }
        }
    }

    public void checkValid(double val){
        GameObject go = Instantiate(end, GameObject.Find("Canvas").transform);
        Stack st = GameObject.Find("Stack").GetComponent<Stack>();
        if(rez == val){
            go.GetComponent<StackPopupController>().spr = success;
            st.increaseTile(gameObject);
        } else {
            go.GetComponent<StackPopupController>().spr = fail;
            st.disableMath();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(_i > 0){
            rt.offsetMax = new Vector3(0,_i);
            _i-= 20;
        }
    }
}
