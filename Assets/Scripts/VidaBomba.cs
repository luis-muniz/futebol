using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBomba : MonoBehaviour
{

    private GameObject barril;

    void Start()
    {
        barril = GameObject.Find("BarrilExplosao");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Vida());
    }

    IEnumerator Vida()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.barril.gameObject);
        Destroy(this.gameObject);
    }
}
