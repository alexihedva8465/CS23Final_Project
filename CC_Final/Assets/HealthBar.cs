using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

      //public GameObject deathEffect;
      public Image healthBar;
      public Color healthyColor = new Color(0.3f, 0.8f, 0.3f);
      public Color unhealthyColor = new Color(0.8f, 0.3f, 0.3f);

       private GameHandler GameHandler; 
       int time = 20;
       int counter;


      private void Start () {
            GameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            counter = 0;

      }

      void FixedUpdate() {
            //Debug.Log("mod" + GameHandler.elapsedTime % time);
            //Debug.Log("counter" + counter);
            healthBar.fillAmount = (GameHandler.elapsedTime % time) / time;

            //turn red at low health:
            if (GameHandler.elapsedTime < 0.3f){
                  if (GameHandler.elapsedTime == time){
                        SetColor(Color.white);
                  }
                  else {
                        SetColor(unhealthyColor);
                  }
            }
            else {
                  SetColor(healthyColor);
            }
      }

      public void SetColor(Color newColor){
            healthBar.GetComponent<Image>().color = newColor;
      }


}