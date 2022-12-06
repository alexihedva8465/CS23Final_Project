using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levels : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

    static float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += 1 * Time.deltaTime;

        if (elapsedTime >= 0 && elapsedTime <= 3) {
            level1.SetActive(true);
        } else {
            level1.SetActive(false);
           
            if (elapsedTime >= 30 && elapsedTime <= 33) {
                level2.SetActive(true);
            } else {
                level2.SetActive(false);
                if (elapsedTime >= 50 && elapsedTime <= 53) {
                    level3.SetActive(true);
                } else {
                    level3.SetActive(false);
                    if (elapsedTime >= 80 && elapsedTime <= 83) {
                        level4.SetActive(true);
                    } else {
                        level4.SetActive(false);
                    }
                }
            }
        }
    }
}
