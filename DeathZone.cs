using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    //public B_INV b_INV; // Script B_INV
    //public B_FALL b_FALL; // Script B_FALL
    
    public B_INV[] blocInvArray; // Array des blocs invisible
    public B_FALL[] blocFallArray; // Array des blocs Tombe
    
    // Liste les Blocs
    private void Start()
    {
        //blocInvTab = GameObject.FindGameObjectWithTag("B_INV");
        //blocFallTab = GameObject.FindGameObjectWithTag("B_FALL");
        blocInvArray= GameObject.FindGameObjectsWithTag("B_INV").GetComponents(typeof(B_INV));
        blocFallArray= GameObject.FindGameObjectsWithTag("B_FALL").GetComponents(typeof(B_FALL));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
        {
            // Rajoute +1 mort dans le script "Inventory"
            Inventory.instance.AddDeath(1);
            // Place le Player au Spawn
            collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
                   
            // Remet le(s) Bocl(s) Invisible
            
            foreach (B_INV blocInv in blocInvArray)
            {
                blocInv.sprite.color = new Color(1f, 1f, 1f, 0f);
            }
            
            //foreach (B_INV g_OBJ in blocInvTab)
            //{
                //g_OBJ.actived = false;
                //g_OBJ.sprite.color = new Color(1f, 1f, 1f, 0f);

                //g_OBJ.setInvisibleColor(new Color(1f, 1f, 1f, 0f));
                //b_INV.Start(g_OBJ.GetComponent<GameObject>());
                //g_OBJ.GetComponent<SpriteRenderer>() = new color(1f, 1f, 1f, 0f);
            //}
            
            // Remet le(s) Bocl(s) Fall à sa position original
           
                
        }       
    }
}