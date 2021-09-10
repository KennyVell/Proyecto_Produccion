using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI singleton;

    public GameObject panel;
    public Text texto;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        Ocultar();
    }

    public void Mostrar()
    {
        GameManager.singleton.inDialogue = true;
        panel.SetActive(true);
        texto.text = "";
    }

    public void Ocultar()
    {
        GameManager.singleton.inDialogue = false;
        panel.SetActive(false);
    }

    public void MostrarTexto(string _texto)
    {
        texto.text = _texto;
    }
}
