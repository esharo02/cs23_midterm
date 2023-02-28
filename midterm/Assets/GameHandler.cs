using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

      public GameObject scoreText;

      public float timeLeft = 60;
      public bool timerOn = false;
      public GameObject timerText;
      public Text gameOverText;

      private int earnings = 0;

      void Start(){
            timerOn = true;
            UpdateScore();
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
      }

      void Update() 
      {
            if(timerOn) {
                  if(timeLeft > 0) {
                        timeLeft -= Time.deltaTime;
                        UpdateTimer(timeLeft);
                  } else {
                  Debug.Log("Time is up!");
                  timeLeft = 0;
                  timerOn = false;
                  gameOverText.gameObject.SetActive(true);
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
}