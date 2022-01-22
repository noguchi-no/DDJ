using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed;
    public Vector2 jumpPower = new Vector2();
    public SoundManager sm;
    public static bool isGameStart;
    private int jumpCount;
    public int maxJumpCount;
    bool isJumped;
    bool isJumping;
    bool isHoldJump;
    static float duration;
    float timeForHoldJump;
    public float timeLimitToHoldJump;
    float x;
    public Vector2 airGravity = new Vector2();
    public float jumpPowerY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        duration = 0;
        isGameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStart){
            duration += Time.deltaTime;
        }

        GameStart();
        
        Jump();

        HoldJump();

        if(isJumping){
            timeForHoldJump += Time.deltaTime;
        }
    }

    void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            
            //Debug.Log("a");

            if(isGameStart){
                isJumping = true;
            }

            if(!isGameStart){
                
                sm.BPM60();
                isGameStart = true;
            }
            else if(isGameStart && !isJumped){

                //Debug.Log("b");
                Debug.Log(rb.velocity.y);

                if(jumpCount < maxJumpCount){
                    Debug.Log("jump");
                    //isGame = false;
                    //rb.velocity = jumpPower;
                    rb.velocity = Vector2.zero;
                    rb.AddForce(jumpPower, ForceMode2D.Impulse);
                    //transform.position += Vector3.up * jumpPowerY;
                    sm.JumpSE();
                    Debug.Log(rb.velocity.y);
                    //Debug.Log(this.transform.position.x);
                    jumpCount++;
                    //isGame = true;
                    //Debug.Log ("速度: " + rb.velocity.magnitude);

                }else{
                    isJumped = true;
                }
                
            }

        }

        if(isJumping && Input.GetKeyUp(KeyCode.Space)){
            isHoldJump = true;
        }
    }

    void HoldJump()
    {
        
        if(isHoldJump && Input.GetKey(KeyCode.Space)){
            
            Debug.Log(rb.velocity.y);
            //x = rb.velocity.y;
            //Debug.Log(x);
            rb.velocity = new Vector2(playerSpeed, 0f);
            //rb.AddForce(airGravity);

        }else{
            
            //rb.velocity = new Vector2(playerSpeed, x);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isHoldJump = false;
            timeForHoldJump = 0;
            isJumping = false;
            isJumped = false;
            jumpCount = 0;
            
        }else{
            Debug.Log("GameOver");
            SceneManager.LoadScene("Game");
        }
    }

    void GameStart()
    {
        if(isGameStart){

            //rb.AddForce(playerSpeed*0.01f, ForceMode2D.Impulse);
            rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
            
        }

    }
}
