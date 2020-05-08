using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitGenerator : MonoBehaviour
{
    public List<Sprite> foods = new List<Sprite>();
    public GameObject foodPrefab;
    // Start is called before the first frame update
    public float InitWaitTime = 2.0f;
    private float waitTime;
    private int nextCorr;
    private Sprite corrSprite;
    private int currN;
    private int nextRandom;
    void Start()
    {
        waitTime = InitWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerFood.paused) return;
        if(waitTime < 0.0f){
            currN++;
            GameObject go = Instantiate(foodPrefab, new Vector3(Random.Range(transform.position.x-3,transform.position.x+3), transform.position.y, 0), Quaternion.identity);
            go.transform.SetParent(transform);
            var randomFood = foods[Random.Range(0, foods.Count)];
            if(currN == nextCorr){
                randomFood = corrSprite;
                currN = 0;
                nextCorr = Random.Range(2,4);
            } else {
                randomFood = foods[Random.Range(0, foods.Count)];
            }
            go.GetComponent<SpriteRenderer>().sprite = randomFood;
            waitTime = InitWaitTime;
        }
        waitTime -= Time.deltaTime;
    }
    public string getRandFood(){
        nextCorr = Random.Range(2,4);
        var ran = foods[Random.Range(0, foods.Count)];
        corrSprite = ran;
        return ran.name;
    }
}
