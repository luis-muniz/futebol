using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bomba;

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
            Instantiate(bomba, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
}
