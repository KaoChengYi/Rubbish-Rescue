using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour { 

    private Queue<string> dialogues;

    // initialisation
    void Start ()
    {
        dialogues = new Queue<string>();
    }

}
