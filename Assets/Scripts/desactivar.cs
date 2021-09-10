using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class desactivar : MonoBehaviour
{
    public GameObject inventario;
    [SerializeField] Button inventarioBtn = null;
    private void Start()
    {

        inventarioBtn.onClick.AddListener(OcultarAudio);
    }

    void OcultarAudio()
    {
        inventario.SetActive(false);
    }
}
