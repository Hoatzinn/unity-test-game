using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -20;
    public BirdScript birdScript;
    // Start is called before the first frame update
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(birdScript.birdIsDashing);
        if (birdScript.birdIsDashing == false) {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        } else {
            transform.position = transform.position + (Vector3.left * moveSpeed  * birdScript.dashSpeed) * Time.deltaTime;
        }
        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
