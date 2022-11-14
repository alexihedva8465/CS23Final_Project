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
      public GameObject light;

      public float waitingTime;

        void Start() {
            speed = UnityEngine.Random.Range(4, 12);
            xPosition = UnityEngine.Random.Range(-5, -7);
            yPosition = UnityEngine.Random.Range(-1, 2);
            waitingTime = (float)UnityEngine.Random.Range(4, 10);
            transform.position = new Vector3(xPosition, yPosition, 0);
        }


      void Update(){
      waitingTime -= 1 * Time.deltaTime;
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

        
        if (transform.position.x >= 13) {
                transform.position = new Vector3(-10, 0, 0);
        }
        if(transform.position.x <= UnityEngine.Random.Range(-6, -4)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
     
      }
}