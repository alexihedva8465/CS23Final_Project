using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    static float time;
    public GameObject StopLight;
    
    // Start is called before the first frame update
    void Start()
    {
        StopLight.GetComponent<SpriteRenderer>().color = Color.red;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        if (time >= 5) {
            time = 0;
            if (StopLight.GetComponent<SpriteRenderer>().color == Color.green) {
                StopLight.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (StopLight.GetComponent<SpriteRenderer>().color == Color.red) {
                StopLight.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
