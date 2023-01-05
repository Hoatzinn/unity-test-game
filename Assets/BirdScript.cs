using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    // Start is called before the first frame update
    public bool birdIsAlive = true;
    public PlayerControls playerControls;
    public PipeMoveScript pipeMove;

    // Dash variabels
    public float dashTime = 50;
    public float dashCooldown = 1;
    public float dashSpeed = 2;
    public bool birdIsDashing = false;
    public float dashTimer = 0;
    
    private void Awake() {
        playerControls = new PlayerControls();
    }
    private void OnEnable() {
        playerControls.Enable();
    }
    private void OnDisable() {
        playerControls.Disable();
    }
    void Start()
    {
           logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
           // pipeMove = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTimer > 0) {
            dashTimer -= Time.deltaTime;
            // Debug.Log(dashTimer);
        }
        else {
            dashTimer = 0;
            birdIsDashing = false;
        }
        if (playerControls.Main.Move.WasReleasedThisFrame() == true && birdIsAlive == true) {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        if (birdIsAlive == false && playerControls.GameOver.Reset.IsPressed() == true) {
            logic.restartGame();
        }
        if (playerControls.Main.Dash.IsPressed()) {
            birdIsDashing = true;
            dashTimer = dashCooldown;
        }
               
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        birdIsAlive = false;
    }
}
