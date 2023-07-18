using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Dots : MonoBehaviour
{

    public TMP_Text dotsText; // Riferimento al componente Text per visualizzare i puntini

    public float blinkInterval = 0.5f; // Intervallo di lampeggio dei puntini
    public float delayBetweenDots = 0.5f; // Ritardo tra l'apparizione di un punto e l'altro
    public int numDots = 3; // Numero di puntini da visualizzare
    public bool DotsStart;
    private float blinkTimer; // Timer per il lampeggio dei puntini
    private int dotsVisibleCount; // Numero di puntini attualmente visibili
    private float totalTimePassed; // Tempo totale trascorso dall'avvio dello script

    private void Start()
    {
        blinkTimer = blinkInterval; // Inizializza il timer al valore dell'intervallo di lampeggio
    }

    private void Update()
    {
        totalTimePassed += Time.deltaTime; // Aggiorna il tempo totale trascorso

        if (DotsStart)
        {
            blinkTimer -= Time.deltaTime;
            if (blinkTimer <= 0f)
            {
                blinkTimer = blinkInterval; // Resettare il timer

                if (dotsVisibleCount < numDots)
                {
                    // Mostra il puntino successivo
                    dotsVisibleCount++;
                    dotsText.text = new string('.', dotsVisibleCount);

                    // Se hai ancora puntini da mostrare, imposta il timer per il prossimo lampeggio
                    if (dotsVisibleCount < numDots)
                    {
                        blinkTimer = delayBetweenDots;
                    }
                }
                else
                {
                    // Nascondi tutti i puntini
                    dotsText.enabled = false;
                }
            }
        }
    }

    public void OnStartDots()
    {
        DotsStart = true;

    }
}
