using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField] public GameObject ExpMissile;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //エネミーとボムにふれたら爆破
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Bomb")
        {
            Vector2 ExpPos = transform.position;
            Instantiate(ExpMissile, ExpPos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
