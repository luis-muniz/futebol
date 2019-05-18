using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaManager : MonoBehaviour
{
    private GameObject bombaEfeito;

    private void Awake()
    {
        bombaEfeito = GameObject.Find("BombaEfeito"); 
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bola"))
        {
            this.gameObject.SetActive(false);
            Instantiate(bombaEfeito, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
}
