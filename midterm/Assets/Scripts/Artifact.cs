using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    private string artifactName;
    public int value;

    void Start()
    {
        artifactName = name.Substring(0, 3);

        switch (artifactName)
        {
            case "Art1":
                value = 20;
                break;
            case "Art2":
                value = 10;
                break;
            case "Art3":
                value = 3;
                break;
            case "Art4":
                value = 200;
                break;
        }
        
    }
}
