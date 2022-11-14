using System;
 using System.Collections.Generic;
 using System.Security.Cryptography;
 using UnityEngine;
 using UnityEngine.UI;


public class Collision : MonoBehaviour
{

    static int score = 0;
    public Text scoreText;


    public GameObject student;
    public GameObject car;
    public GameObject crashedCar;
    public GameObject carObject;
    bool startTimer = false;
    static float time = 3;

    void Start() {
        crashedCar.SetActive(false);

        //text fields
        //scoreText.text = score.ToString() + " cows saved";
        

    }

    void Update() {
        //  if (score <= 3) {
        //     //medical student
        //     endScoreText.text = "You only saved " + score.ToString() + " cows. \n Level: medical student";
        // } else if (score <= 7) {
        //     //resident doctor
        //     endScoreText.text = "You only saved " + score.ToString() + " cows.\n Level: resident";
        // }else if (score <= 10) {
        //     // fellow
        //     endScoreText.text = "You saved " + score.ToString() + " cows. \n Level: fellow";
        // }else if (score <= 15) {
        //     // attending
        //     endScoreText.text = "Congrats! You saved " + score.ToString() + " cows.\n  Level: attending";
        // }else {
        //     // celeb doctor
        //     endScoreText.text = "Amazing! You saved " + score.ToString() + " cows. \n Level: celeb doctor";
        // }
        
        // scoreText.text = score.ToString() + " cows saved";
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
       }
    }
}
