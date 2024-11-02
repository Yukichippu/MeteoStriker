using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Example()
    {
        int Y = Random.Range(1, 6);
        Physics2D.gravity = new Vector2(0, Y);//èdóÕÇÃê›íË
    }
}
