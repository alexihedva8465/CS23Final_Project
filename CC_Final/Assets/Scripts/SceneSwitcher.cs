using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public bool rulesObjActive = false;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject playButton;
    public float imageTimer = 0;

    public void MoveToScene(int sceneID) {
            SceneManager.LoadScene(sceneID);
    }

    void start() {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        playButton.transform.position = new Vector3(0, 100, 0);
    }

    void FixedUpdate() {
        if (rulesObjActive) {
            playButton.transform.position = new Vector3(1000, 1000, 0);
            imageTimer += 1 * Time.deltaTime;
            if (imageTimer >= 0 && imageTimer <= 3) {
                image1.SetActive(true);
                image2.SetActive(false);
                image3.SetActive(false);
            } else if (imageTimer >= 3 && imageTimer <= 6) {
                image1.SetActive(false);
                image2.SetActive(true);
            } else if (imageTimer >= 6 && imageTimer <= 9) {
                image2.SetActive(false);
                image3.SetActive(true);
            } else {
                image1.SetActive(false);
                image2.SetActive(false);
                image3.SetActive(false);
                playButton.transform.position = new Vector3(500, 300, 0);
            }
        }
    }

    public void setrules() {
        rulesObjActive = true;
    }
}
