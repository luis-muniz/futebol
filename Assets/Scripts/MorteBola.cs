using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteBola : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VidaBola());
    }

    // Update is called once per frame
    IEnumerator VidaBola()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
