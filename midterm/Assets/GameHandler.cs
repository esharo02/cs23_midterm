using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

      public GameObject scoreText;
      private int totalAmount = 0;
      private int timer = 0;

      void Start(){
            UpdateScore();
      }

      public void AddScore(int points){
            totalAmount += points;
            UpdateScore();
      }

      void UpdateScore(){
            Text scoreTextB = scoreText.GetComponent<Text>();
            scoreTextB.text = "" + totalAmount;
      }
}