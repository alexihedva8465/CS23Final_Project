using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class movePerson : MonoBehaviour {

    public float speed;
    public GameObject student;
    public string studentcolor;
    public Animator anim;
    private GameHandler GameHandler;
    static int xPosition;
    static int yPosition;
    public GameObject light;
    public float waitingTime;
    float elapsedTime;

    void Start() {
        GameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        stopAnim();
        if (studentcolor == "orange") {
            startAnim();
        }
        if (studentcolor == "blue"
            || studentcolor == "white"
            || studentcolor == "orange") {
            student.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
        } 
        xPosition = UnityEngine.Random.Range(-8, -9);
        yPosition = UnityEngine.Random.Range(-1, 2);
        waitingTime = (float)UnityEngine.Random.Range(4, 10);
        transform.position = new Vector3(xPosition, yPosition, 0);
    }


    void Update(){
    if (GameHandler.FinalLevelBool == true) {
        elapsedTime = 100;
    }

    waitingTime -= 1 * Time.deltaTime;
    elapsedTime = GameHandler.elapsedTime;
    // elapsedTime += 1 * Time.deltaTime;
    if (light.GetComponent<SpriteRenderer>().color == Color.green 
        && studentcolor == "green"
        && waitingTime <= 0) {
            stopAnim();
            if (transform.position.x >= 10) {
                stopAnim();
                waitingTime = (float)UnityEngine.Random.Range(4, 10);
                transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
                student.SetActive(true);
            }else {
                startAnim();
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            
    }
    else if (light.GetComponent<SpriteRenderer>().color == Color.red 
        && studentcolor == "red"
        && waitingTime <= 0) {
            if (transform.position.x >= 10) {
                stopAnim();
                waitingTime = (float)UnityEngine.Random.Range(4, 10);
                transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
            } else {
                startAnim();
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
    }
    else if (elapsedTime >= 20) {
        if (studentcolor == "blue"
        && waitingTime <= 0) {
            student.GetComponent<SpriteRenderer>().color = new Color (0, 0, 1, 1);
            student.SetActive(true);
                if (transform.position.x >= 10) {
                stopAnim();
                waitingTime = (float)UnityEngine.Random.Range(7, 10);
                transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
            } else {
                startAnim();
                transform.position += Vector3.right * speed * Time.deltaTime;
                int check = UnityEngine.Random.Range(0, 2);
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        if (elapsedTime >= 40) {
            Debug.Log("this");
            if (studentcolor == "white"
            && waitingTime <= 0) {
                student.GetComponent<SpriteRenderer>().color = new Color (230, 230, 250, 1);
                student.SetActive(true);
                if (transform.position.x >= 10) {
                    stopAnim();
                    waitingTime = (float)UnityEngine.Random.Range(4, 10);
                    transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
                } else {
                    startAnim();
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
            }
        }
        if (elapsedTime >= 60) {
            if (studentcolor == "orange") {
                student.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
                startAnim();
            }
        }
    }

    else if ( waitingTime <= 0 && student.transform.position.x >= -2 
            && student.transform.position.x <= 10) {
            stopAnim();
                if (transform.position.x >= 10) {
                    waitingTime = (float)UnityEngine.Random.Range(4, 10);
                    transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
                } else if(studentcolor != "orange") {
                    startAnim();
                    transform.position += Vector3.right * speed * Time.deltaTime;
                } else {
                    startAnim();
                }
                
    }

    

    
    if (transform.position.x >= 13) {
            transform.position = new Vector3(-10, 0, 0);
    }
    if(transform.position.x <= UnityEngine.Random.Range(-8, -6)) {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    
    }

    private void stopAnim() {
    anim.SetBool("ChangedLight", false);
    }
    private void startAnim() {
    anim.SetBool("ChangedLight", true);
    }
}