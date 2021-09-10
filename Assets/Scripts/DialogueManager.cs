using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue; 

    string activeSentence;
    public int clicks; 

    IEnumerator StartDialogue()
    {

        DialogueUI.singleton.Mostrar();

        for (int i = 0; i < dialogue.sentenceList.Length; i++)
        {
            activeSentence = dialogue.sentenceList[i];
            DialogueUI.singleton.MostrarTexto(activeSentence);

            yield return new WaitForSeconds(1);

            yield return new WaitUntil(()=>Input.GetMouseButtonUp(0));

            clicks++;
        }

        DialogueUI.singleton.Ocultar();
    }

    private void OnTriggerEnter2D(Collider2D CircleColl)
    {
        if (GameManager.singleton.inDialogue == false && CircleColl.CompareTag("Player"))
        {
            StartCoroutine(StartDialogue());
        }

    }
}
