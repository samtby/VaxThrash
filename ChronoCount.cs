using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Utilise UI

public class ChronoCount : MonoBehaviour
{
    Text text; // Reférence au Text (00:00:00)

    float theTime; // Variable Nombre
    public float speed = 1; // Changer la vitesse d'écoulement du chrono

    bool playingChrono; // Chrono Activé Oui/Non 

    //bool stopChrono;




    // Start is called before the first frame update
    void Start()
    {
       
        // Affiche le text
        text = GetComponent<Text>();   
        //Lance le chrono
        //StartChrono();
    }

    // Update is called once per frame
    void Update()   
    {
        // Si variable playingChrono = true, lance le script
        if (playingChrono == true)
        {
            // 
            theTime += Time.deltaTime * speed;
            //Format Millisecondes
            //string milliseconds = Mathf.Floor(theTime % 99).ToString("00");
            
            // Affiche les secondes "format 60" - ToString = Affiche le format int en format strin (text)
            string seconds = Mathf.Floor(theTime % 60).ToString("00");
            // Affiche les minutes après écoulement des 60 secondes (60 * 60 = 3600)
            string minutes = Mathf.Floor((theTime % 3600)/60).ToString("00");
            // Affiche Minutes : secondes (01:56)
            text.text = minutes + " : " + seconds; 
        }

        //Si le joueur appuie sur n'importe quelle touche
        if (Input.GetKeyDown("space") || Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            StartChrono();
            
        }
    }

    public void StartChrono() // Passe le Chrono en True > Start Chrono
    {
        if (Input.anyKey)
        {
            playingChrono = true;
        }
    }

    public void StopChrono() // Passe le Chrono en False > Stop Chrono
    {
        // text = GetComponent<Text>();
        playingChrono = false;
    }
}
