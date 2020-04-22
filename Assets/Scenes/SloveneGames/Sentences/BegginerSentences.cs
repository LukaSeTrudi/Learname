using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegginerSentences : MonoBehaviour
{
    public GameObject textPrefab;
    public float cas = 20.0f;
    private float timeLeft = 20.0f;
    private int currentIndex = 0;
    private List<string> sentences = new List<string>() {
        "Moje ime je Luka",
        "Glavno mesto Slovenije je Ljubljana",
        "Moj najboljši hobi je pleskanje",
        "Všeč so mi vojaški filmi",
        "Kdaj je njej rojstni dan ?",
        "Kateri dan je danes ?",
        "Na poti domu sem padel",
    };

    private int currentLevel = 0;
    private GameObject timeObject;
    private RectTransform rectTime;
    private string [] word;
    
    public void checkValid(string str, GameObject obj){
        if(str == sentences[currentLevel].Split(' ')[currentIndex]){
            currentIndex++;
            obj.transform.parent = GameObject.Find("Final/1_Row").transform;
        } else {
            timeLeft -= 1.0f;
        }
        Debug.Log(obj);
    }
    public void Start() {
        timeLeft = cas;
        timeObject = GameObject.Find("Game/Time");
        rectTime = (RectTransform)timeObject.transform;
        if(PlayerPrefs.HasKey("BegginerLevel")){
            currentLevel = PlayerPrefs.GetInt("BegginerLevel");
        } else {
            PlayerPrefs.SetInt("BegginerLevel", 0);
        }

        word = sentences[currentLevel].Split(' ');
        Randomize(word);
        int i = 0;
        foreach(string el in word){
            var go = Instantiate(textPrefab, transform.position, transform.rotation);
            go.GetComponent<SentencePreset>().value = el;
            if(i < 3){
                go.transform.parent = GameObject.Find("Sentences/1_Row").transform;
            } else{
                go.transform.parent = GameObject.Find("Sentences/2_Row").transform;    
            }
            i++;
        }
    }
    public void Update() {
        timeLeft -= Time.deltaTime;
        rectTime.sizeDelta = new Vector2(map(timeLeft,0, cas, 0, Screen.width), 20);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
    return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    public void Randomize<T>(T[] items)
    {
        System.Random rand = new System.Random();

        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = rand.Next(i, items.Length);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
