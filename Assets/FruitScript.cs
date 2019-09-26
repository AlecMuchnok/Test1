using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FruitScript : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed;

    private MainSceneManager msm;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * fallSpeed;
        msm = FindObjectOfType<MainSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Will not be destroyed if touching other fruit
        if (collision.gameObject.tag == "Wall")
        {
            msm.LoseLife();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            msm.IncrementScore();
            Destroy(gameObject);
        }
    }
}
