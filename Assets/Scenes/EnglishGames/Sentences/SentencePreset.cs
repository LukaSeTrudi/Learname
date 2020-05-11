using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentencePreset : MonoBehaviour
{
    public string value;

    // Start is called before the first frame update
    private GameObject textObject;
    private float horSize;
    private RectTransform rt1;
    private Button myBtn;

    private BegginerSentences game;
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<BegginerSentences>();
        myBtn = gameObject.GetComponent<Button>();
        myBtn.onClick.AddListener(clickOnElement);
        textObject = transform.GetChild(0).gameObject;
        textObject.GetComponent<Text>().text = value;
        horSize = textObject.GetComponent<Text>().preferredWidth;
        rt1 = (RectTransform)gameObject.transform;
        rt1.sizeDelta = new Vector2(horSize+100, rt1.sizeDelta.y);
        gameObject.GetComponent<Image>().color = UnityEngine.Random.ColorHSV();
    }
    void clickOnElement(){
        game.checkValid(textObject.GetComponent<Text>().text, gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
