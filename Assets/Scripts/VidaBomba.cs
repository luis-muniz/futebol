using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBomba : MonoBehaviour
{

    public void Aux()
    {
        StartCoroutine(Vida());
    }

    IEnumerator Vida()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
