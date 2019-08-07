using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private Transform limiteEsq, limiteDir, bola;

    private float t = 1;

    private void Awake()
    {
        this.limiteEsq = GameObject.Find("LimiteEsq").GetComponent<Transform>();
        this.limiteDir = GameObject.Find("LimiteDir").GetComponent<Transform>();
    }

    //Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isJogoComecou() == true)
        {
            if (this.transform.position.x != this.limiteEsq.position.x)
            {
                t -= 0.08f * Time.deltaTime;
                this.transform.position = new Vector3(Mathf.SmoothStep(this.limiteEsq.position.x, Camera.main.transform.position.x,t), this.transform.position.y,this.transform.position.z);

            }


            if (this.bola == null && GameManager.instance.getBolaEmCena() == true)
            {
                this.bola = GameObject.Find("bola(Clone)").GetComponent<Transform>();
            }
            else if (GameManager.instance.getBolaEmCena() == true)
            {
                Vector3 posCam = this.transform.position;
                posCam.x = this.bola.position.x;
                posCam.x = Mathf.Clamp(posCam.x, this.limiteEsq.position.x, this.limiteDir.position.x);
                this.transform.position = posCam;
            }
        }
    }
}
