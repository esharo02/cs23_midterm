using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

      public GameObject scoreText;

      private int earnings = 0;
      // private int timer = 0;

      void Start(){
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
}