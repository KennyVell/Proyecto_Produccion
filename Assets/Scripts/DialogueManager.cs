using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue; 

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;

    public float typingSpeed;
    AudioSource myAudio;
    public AudioClip speakSound;

    public int clicks; 

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    IEnumerator StartDialogue()
    {
        GameManager.singleton.inDialogue = true;

        for (int i = 0; i < dialogue.sentenceList.Length; i++)
        {
            activeSentence = dialogue.sentenceList[i];
            Debug.Log(activeSentence);

            yield return new WaitForSeconds(1);

            yield return new WaitUntil(()=>Input.GetMouseButtonUp(0));

            clicks++;
        }

        GameManager.singleton.inDialogue = false;
    }

    private void OnTriggerEnter2D(Collider2D CircleColl)
    {
        if (GameManager.singleton.inDialogue == false && CircleColl.CompareTag("Player"))
        {
            StartCoroutine(StartDialogue());
        }

    }
}
