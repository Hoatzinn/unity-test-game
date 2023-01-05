using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTriggerScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript birdScript;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 3 && birdScript.birdIsAlive == true){
        logic.addScore(1);
        }
    }
}
