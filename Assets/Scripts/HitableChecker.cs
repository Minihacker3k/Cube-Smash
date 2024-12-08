using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableChecker : MonoBehaviour
{
    // Bool, das standardm��ig immer false ist, bis alle Objekte das Script "Hit" haben
    public bool ALLHIT = false;

    // Liste oder Array, um alle Objekte mit dem Tag "Hitable" zu speichern
    private GameObject[] hitableObjects;

    void Start()
    {
        // Finde alle Objekte mit dem Tag "Hitable" beim Start
        
    }

    void Update()
    {
        hitableObjects = GameObject.FindGameObjectsWithTag("Hitable");

        // Setze ALLHIT standardm��ig immer auf false zu Beginn jeder �berpr�fung
        ALLHIT = false;

        // Gehe davon aus, dass alle Objekte das Script "Hit" haben (wird �berpr�ft)
        bool allObjectsHaveHit = true;

        // �berpr�fe jedes Objekt im hitableObjects-Array
        foreach (GameObject obj in hitableObjects)
        {
            // Wenn das Objekt das "Hit"-Skript nicht hat, setze allObjectsHaveHit auf false
            if (obj.GetComponent<Hit>() == null)
            {
                allObjectsHaveHit = false;
                
            }
            
        }

        if(allObjectsHaveHit)
        {
            ALLHIT = true;
        }
        
    }
}
