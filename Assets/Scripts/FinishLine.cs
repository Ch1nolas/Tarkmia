using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    public Data dataKill;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag== "Player") {
            dataKill.vicoryPreviusScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Victory");
        }
    }
}
