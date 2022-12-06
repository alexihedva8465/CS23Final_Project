using System;
 using System.Collections.Generic;
 using System.Security.Cryptography;
 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.SceneManagement;


public class moveCarNew : MonoBehaviour {

    public float speed = 5f;
    bool isMoving = false;
    // static int score = 0;
    // public Text scoreText;
    // public float elapsedTime = 0;

    public bool UpCar;

    // To help with ending the game:
    // static int numKills = 0;
    // End game screen:
    // int endGamesceneID = 2;

    // public GameObject student;
    // public GameObject car;
    //public GameObject crashedCar; //car art  busted
    public GameObject carObject; //car art normal
    public AudioSource crash; 
    //bool startTimer = false;
    public float timeFrustration = 3f; // time until car goes anyway


    void Start() {
        //resetScore();
        //GetComponent<AudioSource> ().clip = crash;
        //scoreText.text = "Score: " + score.ToString();
        //crashedCar.SetActive(false);
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown (0)) {
            setMoveTrue();
        }
    }

    void FixedUpdate(){
        //elapsedTime += 1 * Time.deltaTime;
        //if(startTimer == true) {
        //    timeFrustration -= 1 * Time.deltaTime;
         //   if(timeFrustration <= 0) {
                //crashedCar.SetActive(false);
         //       startTimer = false;
          //      timeFrustration = 3;
          //  }
        //}
        
        if(isMoving) {
            if (UpCar) {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else {
                transform.position -= Vector3.up * speed * Time.deltaTime;
            }
        }

        if (transform.position.y >= 9 && UpCar) {
                //score++;
                //scoreText.text = "Score: " + score.ToString();

                // Update the number of kills:
                

                transform.position = new Vector3(3, -9, 0);
                isMoving = false;
        } else if (transform.position.y <= -9 && !UpCar) {
            //score++;
            //scoreText.text = "Score: " + score.ToString();

            // Update the number of kills:

            transform.position = new Vector3(-3, 9, 0);
            isMoving = false;
        }
        if(transform.position.y <= -4 && UpCar) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        } else if (transform.position.y >= 4 && !UpCar) {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }

    }

    public void setMoveTrue() {
        if (UpCar) {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            transform.position -= Vector3.up * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        this.isMoving = true;
    }

    //public void resetScore()
    //{
    //    score = 0;
    //}



    void OnTriggerEnter2D(Collider2D Collider) {
       if (Collider.gameObject.tag == "Student") {
            //decrease score 
            Collider.gameObject.SetActive(false);
            Collider.gameObject.transform.position = 
                new Vector3(11, UnityEngine.Random.Range(-1, 2), 0);
            Collider.gameObject.SetActive(true);
            //score = score - 3;
            //scoreText.text = "Score: " + score.ToString();
            //carObject.SetActive(false);
            //crashedCar.SetActive(true);
            //startTimer = true;
            if (UpCar) {
                transform.position = new Vector3(3, -9, 0);
            }
            else {
                transform.position = new Vector3(-3, 9, 0);
            }
            
            carObject.SetActive(true);
            isMoving = false;
            GetComponent<AudioSource>().Play();
            //Debug.Log(numKills);
            //numKills++;
            // End Game:
            //if (numKills >= 7)
            //{
                // Change to game end screen:
            //    SceneManager.LoadScene(3);
            //}
       }
    }
      
}