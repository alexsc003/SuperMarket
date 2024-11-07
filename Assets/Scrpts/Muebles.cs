using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muebles : MonoBehaviour
{
    [SerializeField]
    public int muebleSeleccionado;
    SuperMerfcado juego;
    void DarAElegir()
    {
        juego.ElegirMueble(muebleSeleccionado);
    }
}
