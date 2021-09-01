using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue; 

    Queue<string> sentences;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;

    public float typingSpeed;
    AudioSource Myaudio;
    public AudioClip speakSound;

    void Start()
    {
        sentences = new Queue<string>();
        Myaudio = GetComponent<AudioSource>();
    }

    void StartDialogue()
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return; 
        }

        activeSentence = sentences.Dequeue();
        Debug.Log(activeSentence);
    }

    private void OnTriggerEnter2D(Collider2D CircleColl)
    {
        if (CircleColl.CompareTag("Player"))
        {
            StartDialogue();
        }

    }

    void OnTriggerStay2D(Collider2D StayColl)
    {
        if (StayColl.CompareTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                DisplayNextSentence();
            }
        }
    }
}
