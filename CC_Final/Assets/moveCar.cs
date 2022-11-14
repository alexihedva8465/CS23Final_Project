using System;
 using System.Collections.Generic;
 using System.Security.Cryptography;
 using UnityEngine;
 using UnityEngine.UI;

public class moveCar : MonoBehaviour {

    public float speed = 5f;
    static bool isMoving = false;
    static int score = 0;
    public Text scoreText;

    public GameObject student;
    public GameObject car;
    public GameObject crashedCar;
    public GameObject carObject;
    public AudioClip crash; 
    bool startTimer = false;
    static float time = 3;


    void Start() {
        GetComponent<AudioSource> ().clip = crash;
        scoreText.text = "Score: " + score.ToString();
        crashedCar.SetActive(false);
    }

    void Update(){

        if(startTimer == true) {
            Debug.Log(true);
            time -= 1 * Time.deltaTime;
            if(time <= 0) {
                crashedCar.SetActive(false);
                startTimer = false;
                time = 3;
            }
        }

        if(isMoving) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (transform.position.y >= 9) {
                score++;
                scoreText.text = "Score: " + score.ToString();
                transform.position = new Vector3(0, -5, 0);
                isMoving = false;
        }
        if(transform.position.y <= -3) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

    }

    public void setMoveTrue() {
    isMoving = true;
    }

    void OnTriggerStay2D(Collider2D Collider) {
       if (Collider.gameObject.tag == "Student") {
            //decrease score 
            student.SetActive(false);
            score = score - 3;
            scoreText.text = "Score: " + score.ToString();
            car.SetActive(false);
            crashedCar.SetActive(true);
            startTimer = true;
            transform.position = new Vector3(0, -5, 0);
            carObject.SetActive(true);
            car.SetActive(true);
            isMoving = false;
            GetComponent<AudioSource>().Play();
       }
    }
      
}