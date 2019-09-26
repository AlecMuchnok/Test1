using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField]
    private FruitScript fruitPrototype;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private float minTimeBetweenFruit;

    [SerializeField]
    private float maxTimeBetweenFruit;

    private int lives;
    private int score;

    private float fruitTimer;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        fruitTimer = -1f; //Spawn fruit on first update
    }

    // Update is called once per frame
    void Update()
    {
        if(lives > 0)
        {
            fruitTimer -= Time.deltaTime;

            if(fruitTimer < 0)
            {
                //Spawn fruit
                FruitScript fruit = Instantiate(fruitPrototype, new Vector3(Random.Range(-4f, 4f), 6), Quaternion.identity);
                SpriteRenderer fruitRenderer = fruit.GetComponent<SpriteRenderer>();

                switch(lives)
                {
                    case 3:
                        fruitRenderer.color = Color.green;
                        break;
                    case 2:
                        fruitRenderer.color = Color.yellow;
                        break;
                    case 1:
                        fruitRenderer.color = Color.red;
                        break;
                }

                //Set timer again
                fruitTimer = Random.Range(minTimeBetweenFruit, maxTimeBetweenFruit); //Spawn fruit every 1-5 seconds
            }
        }
    }

    public void LoseLife()
    {
        lives--;

        if(lives <= 0)
        {
            FindObjectOfType<PlayerScript>().canMove = false;
        }
    }

    public void IncrementScore()
    {
        if(lives > 0) //Don't let fruit that was already falling when game is over to count toward score
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        
    }
}
