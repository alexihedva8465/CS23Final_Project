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
       int[] times = {10, 20, 20, 30};
       int counter;


      private void Start () {
            GameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            counter = 0;

      }

      void Update() {
            //Debug.Log("mod" + GameHandler.elapsedTime % times[counter]);
            //Debug.Log("counter" + counter);
            healthBar.fillAmount = (GameHandler.elapsedTime % times[counter]) / times[counter];

            //turn red at low health:
            if (GameHandler.elapsedTime < 0.3f){
                  if (GameHandler.elapsedTime == times[counter]){
                        SetColor(Color.white);
                  }
                  else {
                        SetColor(unhealthyColor);
                  }
            }
            else {
                  SetColor(healthyColor);
            }

            if(GameHandler.elapsedTime % times[counter] == 0) {
                  counter += 1;
                  Debug.Log("hello");
                  healthBar.fillAmount = 0;
            }
      }

      public void SetColor(Color newColor){
            healthBar.GetComponent<Image>().color = newColor;
      }


}