using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BegginerSentences : MonoBehaviour
{
    public Text finalText;
    public GameObject textPrefab;
    public Camera cam;
    public float cas = 20.0f;

    public GameObject music;

    public AudioSource effect;
    public AudioClip good;
    public AudioClip bad;

    private float timeLeft = 20.0f;
    private int currentIndex = 0;
    public List<string> sentences = new List<string>() {
        "Please speak more slowly.",
        "He really makes me angry.",
        "It's not just a game.",
        "What do you do on Sunday?",
        "Its not just a game.",
        "I don't think i want to know.",
        "Let me introduce myself.",
        "Will it rain tomorrow?",
        "We never actually met.",
        "Tom isn't skinny.",
        "She lost money.",
        "I'm not dishonest.",
        "Pleasure to meet you, Doctor.",
        "Tom's car hit a tree.",
        "You're a good person.",
        "Did you all hear that?",
        "Tom left the party early.",
        "Sit near here.",
        "It looks like I messed up.",
        "So what do I do?",
    };

    private int currentLevel = 0;
    private GameObject timeObject;
    private RectTransform rectTime;
    private float maxWidth;
    private string [] word;
    
    public void checkValid(string str, GameObject obj){
        if(str == sentences[currentLevel].Split(' ')[currentIndex]){
            effect.PlayOneShot(good);
            currentIndex++;
            finalText.text += str + "    ";
            Destroy(obj);
            if(currentIndex == sentences[currentLevel].Split(' ').Length){
                PlayerPrefs.SetInt("BegginerLevel", currentLevel+1);
                if(currentLevel+1 < sentences.Count){        
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                } else SceneManager.LoadScene("SentencesMenu");
            }
        } else {
            effect.PlayOneShot(bad);
            timeLeft -= 3.0f;
            cam.GetComponent<CameraShake>().TriggerShake();
        }
    }
    public void Start() {
        if(GameObject.FindGameObjectsWithTag("music").Length == 1){
            DontDestroyOnLoad(music);
        } else {
            Destroy(music);
        }
        timeLeft = cas;
        
        timeObject = GameObject.Find("Game/Time");
        rectTime = (RectTransform)timeObject.transform;
        maxWidth = rectTime.rect.width;
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
            } else if(i < 6){
                go.transform.parent = GameObject.Find("Sentences/2_Row").transform;    
            } else {
                go.transform.parent = GameObject.Find("Sentences/3_Row").transform;        
            }
            i++;
        }
    }
    public void Update() {
        timeLeft -= Time.deltaTime;
        rectTime.sizeDelta = new Vector2(map(timeLeft,0,cas, 0, maxWidth), rectTime.sizeDelta.y);
        if(rectTime.sizeDelta.x < 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
