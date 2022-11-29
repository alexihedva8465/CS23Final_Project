using System;
 using System.Collections.Generic;
 using System.Security.Cryptography;
 using UnityEngine;
 using UnityEngine.UI;

public class movePerson : MonoBehaviour {

      static float speed;
      public GameObject student;

      static int xPosition;
      static int yPosition;
      public float elapsedTime = 0;
      public GameObject light;

      public float waitingTime;

        void Start() {
            speed = UnityEngine.Random.Range(4, 10);
            xPosition = UnityEngine.Random.Range(-8, -9);
            yPosition = UnityEngine.Random.Range(-1, 2);
            waitingTime = (float)UnityEngine.Random.Range(4, 10);
            transform.position = new Vector3(xPosition, yPosition, 0);
        }


      void Update(){
      waitingTime -= 1 * Time.deltaTime;
      elapsedTime += 1 * Time.deltaTime;
        if (light.GetComponent<SpriteRenderer>().color == Color.green 
            && student.GetComponent<SpriteRenderer>().color == Color.green
            && waitingTime <= 0) {
                if (transform.position.x >= 10) {
                    waitingTime = (float)UnityEngine.Random.Range(4, 10);
                    transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
                }
                transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (light.GetComponent<SpriteRenderer>().color == Color.red 
            && student.GetComponent<SpriteRenderer>().color == Color.red
            && waitingTime <= 0) {
                if (transform.position.x >= 10) {
                    waitingTime = (float)UnityEngine.Random.Range(4, 10);
                    transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
                }
                transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (elapsedTime >= 20) {
            if (light.GetComponent<SpriteRenderer>().color == Color.green 
            && student.GetComponent<SpriteRenderer>().color == Color.blue
            && waitingTime <= 0) {
                 if (transform.position.x >= 10) {
                    waitingTime = (float)UnityEngine.Random.Range(4, 10);
                    transform.position = new Vector3(-10, UnityEngine.Random.Range(-1, 2), 0);
                }
                transform.position += Vector3.right * speed * Time.deltaTime;
                int check = UnityEngine.Random.Range(0, 2);
                if (check >= 0 && check <= 1) {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
                else if (check >= 1 && check <= 2) {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                } 
            }
        }
        

        
        if (transform.position.x >= 13) {
                transform.position = new Vector3(-10, 0, 0);
        }
        if(transform.position.x <= UnityEngine.Random.Range(-8, -6)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
     
      }
}