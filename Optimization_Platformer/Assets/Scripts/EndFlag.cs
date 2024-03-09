using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    //Back to Main upon beating the level
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
