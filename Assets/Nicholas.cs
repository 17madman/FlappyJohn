using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class Nicholas : MonoBehaviour
{
    public GameObject music;
    public GameObject background;
    public Rigidbody2D myRigidbody;
    public float jumpHeight = 2;
    public static bool alive = false;
    public AudioClip myClip;
    public AudioSource audioSource;
    public Sprite deadSprite;
    public Sprite aliveSprite;
    private int score = 0;
    public Text myText;
    private int highScore = 0;
    public Text highText;
    public GameObject highObj;
    public GameObject deathBlack;
    public GameObject over;
    public GameObject scoreText;
    public GameObject startBut;
    public AudioClip scoreClip;
    public Button startButton;

    public GameObject plusCredit;

    string dataPath;
    string savePath;
    

    


    // Start is called before the first frame update
    void Start()
    {

        //Get the path of the Game data folder
        dataPath = Application.dataPath;
        savePath = dataPath+"/saveData.txt";

        if (File.Exists(savePath)){
            highScore = Int32.Parse(File.ReadAllText(savePath));
        }

        SpriteRenderer mySprite = gameObject.GetComponent<SpriteRenderer>();
        aliveSprite = mySprite.sprite;

        gameOver();
        audioSource.Stop();
        myText.text = score.ToString();
        over.SetActive(false);
        highObj.SetActive(true);
        scoreText.SetActive(true);
        background.SetActive(false);
        deathBlack.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

        mySprite.sprite = aliveSprite;

        score = 0;
        myText.text = score.ToString();




        startButton.onClick.AddListener(startGame);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(((Input.GetKeyDown(KeyCode.N)) || (Input.GetKeyDown(KeyCode.Mouse0))) & (alive == true)){
            myRigidbody.velocity = Vector2.up * jumpHeight;
        }
        if (alive == false){
            gameObject.GetComponent<Rigidbody2D>().IsSleeping();
        }

    }
    void OnCollisionEnter2D(Collision2D collision){
        gameOver();

    }
    void OnTriggerExit2D(Collider2D collision){ //When Scoring
        if (alive == true){
            score ++;
            myText.text = score.ToString();
            audioSource.PlayOneShot(scoreClip);

            plusCredit.transform.position = new Vector3(UnityEngine.Random.Range(-5.5f, 5.5f), UnityEngine.Random.Range(-8f, 11.5f), -6.9f);
    }

    
    }

    void gameOver(){
        alive = false;
        audioSource.PlayOneShot(myClip);
        music.SetActive(false);
        background.SetActive(true);
        plusCredit.SetActive(false);

        SpriteRenderer mySprite = gameObject.GetComponent<SpriteRenderer>();
        mySprite.sprite = deadSprite;
        deathBlack.SetActive(true);
        over.SetActive(true);
        scoreText.SetActive(false);
        highObj.SetActive(true);
        startBut.SetActive(true);

        if (score > highScore){
            highScore = score;
        }
        highText.text = ("High Score: " + highScore);


        File.WriteAllText(savePath, highScore.ToString());
    }

    void startGame(){
        plusCredit.SetActive(true);
        plusCredit.transform.position = new Vector3(0, 0, 20);
        deathBlack.SetActive(false);
        over.SetActive(false);
        scoreText.SetActive(true);
        highObj.SetActive(false);
        startBut.SetActive(false);
        music.SetActive(true);
        background.SetActive(false);

        SpriteRenderer mySprite = gameObject.GetComponent<SpriteRenderer>();
        mySprite.sprite = aliveSprite;

        
        gameObject.transform.position = new Vector3(-3, 3.2192f, -7.5f);
        
        gameObject.GetComponent<Rigidbody2D>().IsAwake();

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(GameObject pipe in pipes)
        GameObject.Destroy(pipe);
        alive = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        score = 0;
        myText.text = score.ToString();
    }


}
