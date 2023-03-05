// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public GameObject theSprite; //laser
 
//  void Start()
//  {
//      StartCoroutine(StartBlinking()); //Doesn't need to be in Start() but use t$$anonymous$$s line wherever you need it.
//  }
 
//  IEnumerator StartBlinking()
//  {
//      yield return new WaitForSeconds(1); //However many seconds you want
//      theSprite.GetComponent<SpriteRenderer>().enabled = !theSprite.GetComponent<SpriteRenderer>().enabled; //T$$anonymous$$s toggles it
//      StartCoroutine(StartBlinking());
//  }
