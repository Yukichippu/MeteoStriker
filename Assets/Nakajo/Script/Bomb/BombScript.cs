using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] public GameObject ExpObject;
    void Start()
    { 
    }
        
    void Update()
    {
    }

    //���e�ɂ�����Ɣ���
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb"�@|| other.gameObject.tag == "Missile")
        {
            Vector2 ExpPos = transform.position;
            Instantiate(ExpObject,ExpPos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
