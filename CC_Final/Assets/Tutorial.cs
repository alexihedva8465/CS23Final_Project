using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Tutorial : MonoBehaviour
{
    public GameObject student;
    public GameObject car;
    public GameObject carObject;
    public GameObject warningText; 
    // Start is called before the first frame update
    void Start()
    {
        warningText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D Collider) {
       if (Collider.gameObject.tag == "Student") {
            student.SetActive(false);
            car.SetActive(false);
            warningText.SetActive(true);
            transform.position = new Vector3(0, -5, 0);
            carObject.SetActive(true);
            car.SetActive(true);
            GetComponent<AudioSource>().Play();
       }
    }
}
