using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour
{
    public AudioSource pickUpSound;
    public AudioSource news;
    int c = 1;
    public AudioSource pickUpSound1;
    public AudioSource pickUpSound2;

    public AudioSource FakeAudio;

    public Text countText;
    private Rigidbody2D rb;
    private int count = 0;
    public float jumpSpeed = 10;
    public int jumpCounter = 0;

    private bool FakeNews = false;

    public static int liecount;

    public GameObject Lose;
    
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        SetScore();
        news = GetComponent<AudioSource>();
        liecount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && jumpCounter == 0)
        {
            jumpCounter++;
            Vector2 jumpMovement = new Vector2 (0.0f, 1.0f);
            rb.velocity = jumpMovement * jumpSpeed;
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3(1.6f,1.5f,1f);
        }
        else{
            transform.localScale = new Vector3(1.6f,2f,1f);
        }
        if(count < 0){
            LoseGame();
        }
        transform.rotation = new Quaternion(0,0,0,0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.transform.tag == "Ground")
        {
            jumpCounter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.transform.tag == "Lie"){
            if(liecount<9){
                liecount++;
            }
            count+=10;
            SetScore();
            Destroy(other.gameObject);
            if(c == 1){
                pickUpSound.Play();
            }
            if(c == 2){
                pickUpSound1.Play();
            }
            if(c == 3){
                pickUpSound2.Play();
            }
            c++;
            if(c == 4){
                c = 1;
            }
            
        }
        if(other.gameObject.transform.tag == "CNN"){
            liecount = 0;
            if(!FakeNews){
                count -= 30;
            }
            if(FakeNews == true){
                FakeNews = false;
            }
            SetScore();
            Destroy(other.gameObject);
            news.Play();
        }
        if(other.gameObject.transform.tag == "FAKENEWS"){
            FakeNews = !FakeNews;
            FakeAudio.Play();
        }
    }

    private void SetScore(){
        countText.text = "Score: " + count.ToString();
    }

    private void LoseGame(){
        Time.timeScale = 0f;
        Lose.SetActive(true);
    }

}
