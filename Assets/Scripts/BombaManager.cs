using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bombaEfeito;

    void Awake()
    {
        bombaEfeito = GameObject.Find("BombaEfeito");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bola"))
        {
            AudioManager.instance.SonsFxTocar(2);
            GameObject bombaEfeitoAux = Instantiate(bombaEfeito, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            bombaEfeitoAux.GetComponent<Animator>().Play("Explosao");
            //Destroy(this.gameObject);
            // this.gameObject.SetActive(false);
            StartCoroutine(Vida());

        }
    }

    IEnumerator Vida()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);     
        Destroy(GameObject.Find("BombaEfeito(Clone)")); ;
    }

}
