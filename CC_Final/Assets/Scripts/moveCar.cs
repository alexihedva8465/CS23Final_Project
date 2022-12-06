using System;
 using System.Collections.Generic;
 using System.Security.Cryptography;
 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.SceneManagement;


public class moveCar : MonoBehaviour {

    public float speed = 5f;
    bool isMoving = false;
    static int score = 0;
    public Text scoreText;
    public float elapsedTime = 0;

    public bool UpCar;

    // To help with ending the game:
    static int numKills = 0;
    // End game screen:
    int endGamesceneID = 2;

    public GameObject student;
    public GameObject car;
    public GameObject crashedCar;
    public GameObject carObject;
    public AudioClip crash; 
    bool startTimer = false;
    static float time = 3;


    void Start() {
        resetScore();
        GetComponent<AudioSource> ().clip = crash;
        scoreText.text = "Score: " + score.ToString();
        crashedCar.SetActive(false);
    }

    void Update()
    {
        elapsedTime += 1 * Time.deltaTime;
        if(startTimer == true) {
            time -= 1 * Time.deltaTime;
            if(time <= 0) {
                crashedCar.SetActive(false);
                startTimer = false;
                time = 3;
            }
        }
        
        if(isMoving) {
            if (UpCar) {
                this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else {
                this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            }
        }

        if (this.car.transform.position.y >= 9 && UpCar) {
                score++;
                scoreText.text = "Score: " + score.ToString();

                // Update the number of kills:
                

                this.car.transform.position = new Vector3(3, -9, 0);
                isMoving = false;
        } else if (this.car.transform.position.y <= -9 && !UpCar) {
            score++;
            scoreText.text = "Score: " + score.ToString();

            // Update the number of kills:

            this.car.transform.position = new Vector3(-3, 9, 0);
            isMoving = false;
        }
        if(this.car.transform.position.y <= -4 && UpCar) {
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
        } else if (this.car.transform.position.y >= 4 && !UpCar) {
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
        }

    }

    public void setMoveTrue() {
        if (UpCar) {
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
            this.car.transform.position -= Vector3.up * speed * Time.deltaTime;
        } else {
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
            this.car.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        this.isMoving = true;
    }

    public void resetScore()
    {
        score = 0;
    }



    void OnTriggerStay2D(Collider2D Collider) {
       if (Collider.gameObject.tag == "Student") {
            //decrease score 
            Collider.gameObject.SetActive(false);
            Collider.gameObject.transform.position = 
                new Vector3(11, UnityEngine.Random.Range(-1, 2), 0);
            Collider.gameObject.SetActive(true);
            score = score - 3;
            scoreText.text = "Score: " + score.ToString();
            car.SetActive(false);
            crashedCar.SetActive(true);
            startTimer = true;
            if (UpCar) {
                this.car.transform.position = new Vector3(3, -9, 0);
            }
            else {
                this.car.transform.position = new Vector3(-3, 9, 0);
            }
            
            carObject.SetActive(true);
            car.SetActive(true);
            isMoving = false;
            GetComponent<AudioSource>().Play();
            Debug.Log(numKills);
            numKills++;
            // End Game:
            if (numKills >= 7)
            {
                // Change to game end screen:
                SceneManager.LoadScene(3);
            }
       }
    }
      
}