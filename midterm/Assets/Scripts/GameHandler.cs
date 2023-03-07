using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      public GameObject scoreText;

      public GameObject Door_ClosedL;
      public GameObject Door_ClosedR;
      public GameObject Door_OpenedL;

      public float timeLeft = 120;
      public bool timerOn = false;
      public GameObject timerText;
      public Image gameOver;

      public GameObject GameOverTxt;
      public GameObject SubtractTime;
    private Vector3 fromScale;

    private int earnings = 0;

      void Start(){
            timerOn = true;
            UpdateScore();
            fromScale = SubtractTime.transform.localScale;
            SubtractTime.gameObject.SetActive(false);
      }

      public void AddScore(int points){
            earnings += points;
            UpdateScore();
      }

      public void RemoveScore(int points){
            if (earnings != 0) { earnings -= points; }
            UpdateScore();
      }

      void UpdateScore(){
            Text scoreTextB = scoreText.GetComponent<Text>();
            scoreTextB.text = "Earnings: $" + earnings + " Million";
        //Text subtractTimeTxt = scoreText.GetComponent<Text>();
            SubtractTime.gameObject.SetActive(true);
        StartCoroutine(ScaleDownAnimation(1.0f));
    }

    IEnumerator ScaleDownAnimation(float time)
    {
        float i = 0;
        float rate = 1 / time;

        
        Vector3 toScale = Vector3.zero;
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            SubtractTime.transform.localScale = Vector3.Lerp(fromScale, toScale, i);
            yield return 0;
        }
    }

    void Update() 
      {
            if(timerOn) {
                  if(timeLeft > 0) {
                        timeLeft -= Time.deltaTime;
                        UpdateTimer(timeLeft);
                        if (earnings >= 230) {
                              OpenDoor(4);
                        }
                  } else {
                  Debug.Log("Time is up!");
                  timeLeft = 0;
                  timerOn = false;
                  LoseGame();
                  //gameOver.gameObject.SetActive(true);
                  //Text sudbtractTimeTxt = scoreText.GetComponent<Text>();
                  //GameOverTxt.gameObject.SetActive(true);
            }
            } 
      }

      void UpdateTimer(float currentTime) 
      {
            currentTime += 1;
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            Text timerTxt = timerText.GetComponent<Text>();
            timerTxt.text = string.Format("{0:00} : {1:00}",  minutes, seconds);
      }

      public void ReduceTime(int deductTime) {
            timeLeft -= deductTime;
      }

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
            //reset all static variables
            //playerHealth = StartPlayerHealth;
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

      public void WinGame() {
            SceneManager.LoadScene("EndWin");
      }

      public void LoseGame() {
            SceneManager.LoadScene("EndLose");
      }

      public void OpenDoor(int artifactCount) {
            if (artifactCount == 4) {
                  Door_ClosedL.gameObject.SetActive(false);
                  Door_ClosedR.gameObject.SetActive(false);
                  Door_OpenedL.gameObject.SetActive(true);
            }
      }






}