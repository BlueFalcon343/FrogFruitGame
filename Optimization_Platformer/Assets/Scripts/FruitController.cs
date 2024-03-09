using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public AudioSource FruitSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        //Starts the players function for increasing jump height, play sound FX, and destroys
        if (controller != null)
        {
            controller.getFruit(1);
            FruitSound.Play();
            Destroy(gameObject);
            
        }
    }
}
