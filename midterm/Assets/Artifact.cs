using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    private string artifactName;
    public int value;

    void Start()
    {
        artifactName = name.Substring(0, 4);

        switch (artifactName)
        {
            case "Item1":
                value = 1;
                break;
            case "Item2":
                value = 2;
                break;
            case "Item3":
                value = 3;
                break;
            case "Item4":
                value = 4;
                break;
        }
        
    }
}
