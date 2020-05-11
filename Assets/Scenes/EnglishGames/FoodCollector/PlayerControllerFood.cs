using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerFood : MonoBehaviour
{
    public Text fruit_text;
    public Text result;
    public GameObject generator;
    public Camera cam;
    public static bool paused;

    public AudioSource effect;
    public AudioClip good;
    public AudioClip bad;

    public GameObject endGame;

    public string current_correct;
    private int lifes;
    private int score;
    private Rigidbody2D rb;
    private float moveSpeed = 5.0f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        score = 0;
        paused = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        genNewFood();
    }
    void genNewFood(){
        current_correct = generator.GetComponent<FruitGenerator>().getRandFood();
        fruit_text.text = current_correct;    
    }
    // Update is called once per frame
    void Update()
    {
        float x = SimpleInput.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x,0.0f,0.0f);
        rb.velocity = movement * moveSpeed;
        anim.SetFloat("speed", Mathf.Abs(x));
        if(x > 0){
            gameObject.transform.localScale = new Vector3(-1,1,1);
        } else if(x < 0){
            gameObject.transform.localScale = new Vector3(1,1,1);    
        }
        
    }
    public void setPaused(bool val){
        paused = val;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Food"){
            GameObject go = other.gameObject;
            if(go.GetComponent<FoodPrefab>().name == current_correct){
                effect.PlayOneShot(good);
                score++;
                result.text=score.ToString();
                genNewFood();
            } else{
                effect.PlayOneShot(bad);
                lifes--;
                Destroy(GameObject.Find("Life"));
                cam.GetComponent<CameraShake>().TriggerShake();
                if(lifes == 0){
                    //end game
                    int hs =PlayerPrefs.GetInt("FoodCollectorHighscore");
                    if(score > hs){
                        PlayerPrefs.SetInt("FoodCollectorHighscore", score);
                    }
                    paused = true;
                    endGame.GetComponent<GameOverManagaer>().SetScore(score, hs);
                    endGame.SetActive(true);
                }
            }


            Destroy(go);
        }    
    }
}
