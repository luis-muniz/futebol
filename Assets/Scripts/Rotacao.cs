using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour
{
    [SerializeField]private Transform posStart;
    [SerializeField]private Image setaImage;

    public GameObject setaGO;

    public float zRotateSeta;
    public bool liberaRotacao = false;
    public bool liberarTiro = false;

    // Start is called before the first frame update
    void Start()
    {        
        PosicionaBola();
    }

    // Update is called once per frame
    void Update()
    {
        RotacionaSeta();
        RotacionarSetaMouse();
        LimitarRotacao();
        PosicionaSeta();

    }

    void PosicionaSeta()
    {
        this.setaImage.rectTransform.position = this.transform.position;
    }

    void PosicionaBola()
    {
        this.gameObject.transform.position = posStart.position;
    }

    void RotacionaSeta()
    {
        setaImage.rectTransform.eulerAngles = new Vector3(0, 0, zRotateSeta);
    }

    void RotacionarSetaTeclado()
    {
        if (zRotateSeta>=0 && zRotateSeta<=90)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                zRotateSeta += 0.5f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                zRotateSeta -= 0.5f;
            }
        }
       
    }

    void RotacionarSetaMouse()
    {
        if (liberaRotacao)
        {
            float moveX = Input.GetAxis("Mouse X");
            float moveY = Input.GetAxis("Mouse Y");


            if (moveY > 0 && moveX < 0)
            {
                zRotateSeta += 0.5f;
            }
            else if (moveY < 0 && moveX > 0)
            {
                zRotateSeta -= 0.5f;
            }
        }
       
    }

    void LimitarRotacao()
    {
        if(zRotateSeta > 90)
        {
            zRotateSeta = 90;
        }
        else if (zRotateSeta < 0)
        {
            zRotateSeta = 0;
        }
    }

    void OnMouseDown()
    {
        liberaRotacao = true;
        setaGO.SetActive(true);
    }

    void OnMouseUp()
    {
        liberaRotacao = false;
        liberarTiro = true;
        setaGO.SetActive(false);
    }
}
