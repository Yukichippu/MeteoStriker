using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Goal"))
        {
            StartCoroutine(WaitAndLoadScene());
        }
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("GameClear");
    }
}
