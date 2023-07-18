using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBar : MonoBehaviour
{
    public GameObject Barra;
    public float durataAnimazione = 5f; 
    public float larghezzaIniziale = 1f; 
    public float larghezzaFinale = 5f;  
    private float tempoTrascorso = 0f;   
    public bool Start;
    public Manager manager;

    public void OnStartClick()
    {
        Start = true;
    }

    private void FixedUpdate()
   
    {
        if (Start)
        {
            tempoTrascorso += Time.deltaTime;


            float percentualeCompletamento = tempoTrascorso / durataAnimazione;
            percentualeCompletamento = Mathf.Clamp01(percentualeCompletamento);


            float larghezzaCorrente = Mathf.Lerp(larghezzaIniziale, larghezzaFinale, percentualeCompletamento);


            Barra.transform.localScale = new Vector3(larghezzaCorrente + 100, transform.localScale.y, transform.localScale.z);

            if (Barra.transform.localScale.x >= 200f)
            {
                Barra.transform.localScale = new Vector3(larghezzaCorrente + 200, transform.localScale.y, transform.localScale.z);
                if(larghezzaCorrente >= 300)
                {
                    manager.LoadComplete();
                }
            }
        }
    }
}
