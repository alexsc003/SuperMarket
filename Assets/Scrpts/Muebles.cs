using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Muebles : MonoBehaviour
{
    [SerializeField]
    string nombreObjecto;
    [SerializeField]
    TextMeshProUGUI TextoObjecto;
    [SerializeField]
    public int muebleSeleccionado;
    public SuperMerfcado juego;
    public void DarAElegir()
    {
        juego.ElegirMueble(muebleSeleccionado);
    }
    void Update()
    {
        TextoObjecto.text = nombreObjecto.ToString();
    }
}
