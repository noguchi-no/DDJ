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
    
    bool isJumping;
    static float duration;

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
        
        if(Input.GetKeyDown(KeyCode.Space)){

            if(!isGameStart){
                
                sm.BPM60();
                isGameStart = true;
            }
            else if(isGameStart && !isJumping){
                
                //isGame = false;
                //rb.velocity = jumpPower;
                rb.AddForce(jumpPower, ForceMode2D.Impulse);
                sm.JumpSE();
                Debug.Log(this.transform.position.x);
                isJumping = true;
                //isGame = true;
                //Debug.Log ("速度: " + rb.velocity.magnitude);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            Debug.Log("jump");
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
