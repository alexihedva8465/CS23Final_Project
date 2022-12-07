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

      void Start(){
            sceneName = SceneManager.GetActiveScene().name;
            updateStatsDisplay();
      }

      void FixedUpdate() {
        elapsedTime += 1 * Time.deltaTime;
      }

      public void AddScore(int newscore){
            gotscore += newscore;
            updateStatsDisplay();
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
      }

      public void killsOverflow(){
            SceneManager.LoadScene("EndScene");
      }

      public void StartGame() {
            SceneManager.LoadScene("CrosswalkScene");
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