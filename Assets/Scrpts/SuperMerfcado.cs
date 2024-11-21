using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMerfcado : MonoBehaviour
{
    float tiempo;

    [SerializeField]
    GameObject[] muebles;

    GameObject objectoCreado;
    [SerializeField]
    GameObject modoDestruccion;

    [SerializeField]
    GameObject popUpAcciones;

    [SerializeField]
    GameObject popUpMuebles;
    
    [SerializeField]
    GameObject circulo;
    
        public float alturaActivo;
    public float distanciaActivo;
    public float alturaDesactivo;
    public float distanciaDesactivo;

    public int i;

    public float speedScale = 3.0f;

    public void ElegirMueble(int amount)
    {
        i = amount;
    }
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        objectoCreado.SetActive(false);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(tiempo <= 0.5)
        { 
        LeanTween.scale(circulo, new Vector3(19f, 1f, 19f), 0.5f);
        }
        if(tiempo >= 1) 
        { 
        LeanTween.scale(circulo, new Vector3(16f, 1f, 16f), 0.0f);
            tiempo = 0;
        }
       
        
        Vector3 newScale = transform.localScale;
            newScale += Vector3.one * Input.mouseScrollDelta.y * Time.deltaTime * speedScale;
            transform.localScale = newScale;
            objectoCreado.transform.localScale = newScale;

        Rotacion();
        
        if (Physics.Raycast(ray, out hit))
        {                   
            objectoCreado.transform.position = hit.point;
            circulo.transform.position = hit.point;
        }
        DestruccionClick();
        
        objectoCreado.SetActive(true);
        if (objectoCreado.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                objectoCreado = Instantiate(muebles[i], Vector3.zero, Quaternion.identity);
            }
        }
    }
    public void CrearObjecto()
    {
        objectoCreado = Instantiate(muebles[i], Vector3.zero, Quaternion.identity);
        circulo.SetActive(true);
    }
    public void PopUpObjectos()
    {
        LeanTween.moveLocal(popUpAcciones, new Vector3(0.0f, alturaDesactivo, 0.0f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(popUpMuebles, new Vector3(distanciaActivo, 0.0f, 0.0f), 2f).setEase(LeanTweenType.easeOutElastic);
    }
    public void PopUpAcciones()
    {
        LeanTween.moveLocal(popUpAcciones, new Vector3(0.0f, alturaActivo, 0.0f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(popUpMuebles, new Vector3(distanciaDesactivo, 0.0f, 0.0f), 2f).setEase(LeanTweenType.easeOutElastic);
        modoDestruccion.SetActive(false);
        Destroy(objectoCreado);
    }
    public void DestruccionClick()
    { 
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            Destroy(objectoCreado);
            circulo.SetActive(false);
        }
    }
    public void Rotacion()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            objectoCreado.transform.Rotate(0.0f, -0.5f, 0.0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            objectoCreado.transform.Rotate(0.0f, 0.5f, 0.0f);
        }
    }
    public void Destruccion()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                    Debug.Log("Clicked");
                    Destroy(hit.transform.gameObject);

            }
        }
    }
    public void BotonDestruccion()
    {
        modoDestruccion.SetActive(true);
        LeanTween.moveLocal(popUpAcciones, new Vector3(0.0f, alturaDesactivo, 0.0f), 2f).setEase(LeanTweenType.easeOutElastic);
    }
    
}