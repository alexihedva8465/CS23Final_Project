using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      public static int gotscore = 0;
      public static int kills = 0;
      public GameObject scoreText;
      private string sceneName;
      public float elapsedTime = 0;
      public float rewardTimer = 0;
      public GameObject rewardText;
      public GameObject rewardObject;
      public static int carsAcross = 0;
      public static bool rewardTextActive = false;

      void Start(){
            sceneName = SceneManager.GetActiveScene().name;
            rewardObject.SetActive(false);
            updateStatsDisplay();
      }

      void FixedUpdate() {
            elapsedTime += 1 * Time.deltaTime;
            if (rewardTextActive) {
                  rewardTimer += 1 * Time.deltaTime;
                  if (rewardTimer >= 3) {
                        rewardTextActive = false;
                        rewardObject.SetActive(false);
                  }
            }
      }

      public void AddScore(int newscore){
            rewardObject.SetActive(false);
            carsAcross++;
            gotscore += newscore;
            updateStatsDisplay();
            if(carsAcross % 4 == 0) {
                  rewardObject.SetActive(true);
                  rewardTextActive = true;
            }
      }

      public void DecreaseScore(int newscore){
            gotscore -= newscore;
            updateStatsDisplay();
      }

      public void increaseKills(){
            kills++;
            if (kills == 7) {
                killsOverflow();
            }
      }

      public void updateStatsDisplay(){
            Text scoreTextTemp = scoreText.GetComponent<Text>();
            scoreTextTemp.text = "SCORE: " + gotscore;

            Text rewardTextTemp = rewardText.GetComponent<Text>();
            rewardTextTemp.text = "YOU GOT " + carsAcross + " CARS ACROSS SAFELY! KEEP GOING!";
      }

      public void killsOverflow(){
            SceneManager.LoadScene("EndScene");
      }

      public void StartGame() {
            SceneManager.LoadScene("StoryScene");
      }

      public void RestartGame() {
            SceneManager.LoadScene("Tutorial");
            gotscore = 0;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
}