using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levels : MonoBehaviour
{
    private GameHandler GameHandler; 
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public bool finalLevel;

    static float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        GameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!finalLevel) {
            elapsedTime = GameHandler.elapsedTime;
            if (elapsedTime >= 0 && elapsedTime <= 3) {
            level1.SetActive(true);
            } else {
                level1.SetActive(false);
            
                if (elapsedTime >= 20 && elapsedTime <= 23) {
                    level2.SetActive(true);
                } else {
                    level2.SetActive(false);
                    if (elapsedTime >= 40 && elapsedTime <= 43) {
                        level3.SetActive(true);
                    } else {
                        level3.SetActive(false);
                        if (elapsedTime >= 60 && elapsedTime <= 63) {
                            level4.SetActive(true);
                        } else {
                            level4.SetActive(false);
                        } 
                        if (elapsedTime >= 90) {
                            GameHandler.FinalLevel();
                        }
                    }
                }
            }
        } 
        
        else {
            Debug.Log("hey");
        }

        
    }
}
