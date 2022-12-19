using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingEffect : MonoBehaviour
{
    static bool flash = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator Fade() {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0.1; alpha -= 0.1f)
        {
            if (flash) {
                c.a = 1;
                flash = false;
            } else {
                c.a = 0;
                flash = true;
            }

            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(.5f);
        }
    }
}
