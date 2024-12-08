using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    // Referenz auf das HitableChecker-Skript
    private HitableChecker hitableChecker;

    // Startzeit in Sekunden (2 Minuten = 120 Sekunden)
    public float startTime = 120f;

    // Interne Variable, um die verbleibende Zeit zu speichern
    private float remainingTime;

    // UI-Textfeld, um den Timer anzuzeigen (optional)
    public TextMeshProUGUI timerText;

    // Variable, um festzustellen, ob der Timer läuft
    private bool timerRunning = true;

    // Variable zum Anhalten des Timers
    public bool stop = false;

    void Start()
    {
        // Finde das HitableChecker-Objekt und hole die Komponente
        hitableChecker = GameObject.Find("HitableChecker").GetComponent<HitableChecker>();

        // Setze die verbleibende Zeit auf die Startzeit
        remainingTime = startTime;

        // Starte den Timer
        timerRunning = true;
    }

    void Update()
    {
        // Überprüfen, ob der Timer gestoppt werden soll
        if (stop)
        {
            // Wenn stop true ist, pausiert der Timer
            return;
        }

        // Timer läuft nur, wenn er nicht angehalten ist
        if (timerRunning)
        {
            // Überprüfen, ob alle Hitable-Objekte getroffen wurden
            if (hitableChecker.ALLHIT == false)
            {
                // Verbleibende Zeit um die verstrichene Zeit pro Frame reduzieren
                remainingTime -= Time.deltaTime;

                // Falls die Zeit abgelaufen ist, Timer stoppen
                if (remainingTime <= 0)
                {
                    remainingTime = 0;
                    timerRunning = false;
                    stop = true;

                    // Hier kannst du eine Aktion ausführen, wenn der Timer bei 0 ist
                    TimerEnded();
                }

                // Wenn du den Timer in einem UI-Textfeld anzeigen möchtest
                if (timerText != null)
                {
                    // Formatieren der verbleibenden Zeit in Minuten und Sekunden
                    int minutes = Mathf.FloorToInt(remainingTime / 60);
                    int seconds = Mathf.FloorToInt(remainingTime % 60);

                    // Setze den Text im Format "MM:SS"
                    timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                }
            }
            else
            {
                stop = true; 
                timerRunning = false;
                Debug.Log("ALL OBJECTS HAVE BEEN HIT");
            }
        }
    }

    // Methode zum Pausieren des Timers
    public void PauseTimer()
    {
        stop = true;
        Debug.Log("Timer pausiert.");
    }

    // Methode zum Fortsetzen des Timers
    public void ResumeTimer()
    {
        stop = false;
        Debug.Log("Timer fortgesetzt.");
    }

    // Diese Methode wird aufgerufen, wenn der Timer abgelaufen ist
    void TimerEnded()
    {
        Debug.Log("Timer ist abgelaufen!");
        // Füge hier die Logik hinzu, die bei Ablauf des Timers ausgeführt werden soll
        if(hitableChecker.ALLHIT == true)
        {
            Debug.Log("ALL OBJECTS HAVE BEEN HIT");

        }
        else
        {
            Debug.Log("ALL OBJECTS HAVE NOT BEEN HIT");

        }
    }
}
