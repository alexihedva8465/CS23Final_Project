using System;
 using System.Collections.Generic;
 using System.Security.Cryptography;
 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.SceneManagement;


public class moveCarNew : MonoBehaviour {
    private GameHandler gameHandler; 

    public float speed = 5f;
    bool isMoving = false;

    public bool UpCar;

    public GameObject carObject; 
    public AudioSource crash; 
    float timeFrustration; 
    public GameObject angryFace;


    void Start() {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        //GetComponent<AudioSource> ().clip = crash;
        gameHandler.updateStatsDisplay();
        angryFace.SetActive(false);
        timeFrustration = UnityEngine.Random.Range(15, 20);
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown (0)) {
            setMoveTrue();
            timeFrustration = UnityEngine.Random.Range(15, 20);
            carObject.GetComponent<SpriteRenderer>().color = Color.white;
            angryFace.SetActive(false);
        }
    }

    void FixedUpdate(){
        Debug.Log(timeFrustration);
        if(timeFrustration <= 8) {
             transform.position += Vector3.up * 0.1f * Time.deltaTime;
            carObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            if(timeFrustration <= 3) {
                angryFace.SetActive(true);
                transform.position += Vector3.up * 0.1f * Time.deltaTime;
                carObject.GetComponent<SpriteRenderer>().color = Color.red;
                if(timeFrustration <= 0) {
                    angryFace.SetActive(false);
                    setMoveTrue();
                    timeFrustration = UnityEngine.Random.Range(15, 20);
                    carObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
        timeFrustration -= 1 * Time.deltaTime;
        //TODO: frustration time
        
        if(isMoving) {
            if (UpCar) {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else {
                transform.position -= Vector3.up * speed * Time.deltaTime;
            }
        }

        if (transform.position.y >= 9 && UpCar) {
                gameHandler.AddScore(1);
                transform.position = new Vector3(3, -9, 0);
                isMoving = false;
        } else if (transform.position.y <= -9 && !UpCar) {
            gameHandler.AddScore(1);
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

    void OnTriggerEnter2D(Collider2D Collider) {
       if (Collider.gameObject.tag == "Student") {
       
            Collider.gameObject.SetActive(false);
            Collider.gameObject.transform.position = 
                new Vector3(11, UnityEngine.Random.Range(-1, 2), 0);
            Collider.gameObject.SetActive(true);

            gameHandler.DecreaseScore(1);

            if (UpCar) {
                transform.position = new Vector3(3, -9, 0);
            }
            else {
                transform.position = new Vector3(-3, 9, 0);
            }
            
            carObject.SetActive(true);
            isMoving = false;
            GetComponent<AudioSource>().Play();
            gameHandler.increaseKills();
       }
    }
      
}