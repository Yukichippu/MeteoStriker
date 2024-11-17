using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpScript : MonoBehaviour
{
    private float DestroyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        DestroyCount += Time.deltaTime;
        if (DestroyCount > 0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
