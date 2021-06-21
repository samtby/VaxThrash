using System.Collections;//Pour Coroutine
using System.Collections.Generic;
using UnityEngine;


public class B_FALL : MonoBehaviour
{

    public GameObject objectToFall;
    public Rigidbody2D rb; // "Gravité"
    public bool actived; // Bloc activé oui-non

    Vector3 originalPos; // Position original du bloc



    // Start is called before the first frame update
    public void Start()
    {
        // Position original
        originalPos = gameObject.transform.position;
        // Bloc activé non
        actived = false; 
        rb = GetComponent<Rigidbody2D>();
        // "Gravité" désactivé           
        rb.bodyType = RigidbodyType2D.Static;
    }
        // Appel la fonction blocFalling si le joueur rentre dans le trigger
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(blocFalling());
        }
    }

    public IEnumerator blocFalling()
    {
        // Bloc activé oui
        actived = true; 
        
        // Attend 0.30 seconds | Active le RigidBody (Gravité On)
        yield return new WaitForSeconds(0.30f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        
        // Attend 3 seconds | Désactive le rigid body (Gravité Off)
        yield return new WaitForSeconds(3f);
        rb.bodyType = RigidbodyType2D.Static;

    }
}
