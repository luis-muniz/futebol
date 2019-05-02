using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBomba : MonoBehaviour
{

    private GameObject bombaRepresentacao;

    void Start()
    {
        bombaRepresentacao = GameObject.Find("BombaRepresentacao");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Vida());
    }

    IEnumerator Vida()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(bombaRepresentacao.gameObject);
        Destroy(this.gameObject);
    }
}
