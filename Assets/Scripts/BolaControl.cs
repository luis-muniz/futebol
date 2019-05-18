using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaControl : MonoBehaviour
{
    //rotacao
    private GameObject setaGO;
    private float zRotateSeta;
    private bool liberaRotacao = false;
    private bool liberarTiro = false;

    //forca
    private Rigidbody2D bolaRigidbody2D;
    private float forcaBola = 0.0f;
    private GameObject setaForcaImage;

    //
    private Transform paredeDir, paredeEsq;

    private void Awake()
    {
        this.setaGO = GameObject.Find("setaFundo");
        this.setaForcaImage = setaGO.transform.GetChild(0).gameObject;
        this.setaGO.GetComponent<Image>().enabled = false;
        this.setaForcaImage.GetComponent<Image>().enabled = false;
        this.bolaRigidbody2D = GetComponent<Rigidbody2D>();
        this.paredeDir = GameObject.Find("ParedeRight").GetComponent<Transform>();
        this.paredeEsq = GameObject.Find("ParedeLeft").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotacao
        RotacionaSeta();
        RotacionarSetaMouse();
        LimitarRotacao();
        PosicionaSeta();

        //forca
        AddForca();
        ControleDeForca();

        //
        MatarBola();
    }

    //rotacao
    void PosicionaSeta()
    {
        this.setaGO.GetComponent<Image>().rectTransform.position = this.transform.position;
    }    

    void RotacionaSeta()
    {
        this.setaGO.GetComponent<Image>().rectTransform.eulerAngles = new Vector3(0, 0, zRotateSeta);
    }

    void RotacionarSetaTeclado()
    {
        if (zRotateSeta >= 0 && zRotateSeta <= 90)
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
        if (zRotateSeta > 90)
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
        if (GameManager.instance.getPossuiTiro())
        {
            liberaRotacao = true;
            this.setaGO.GetComponent<Image>().enabled = true;
            this.setaForcaImage.GetComponent<Image>().enabled = true;
        }
    }

    void OnMouseUp()
    {
        liberaRotacao = false;
        this.setaGO.GetComponent<Image>().enabled = false;
        this.setaForcaImage.GetComponent<Image>().enabled = false;

        if (GameManager.instance.getPossuiTiro() && this.forcaBola > 0)
        { 
            liberarTiro =  true;
            this.setaForcaImage.GetComponent<Image>().fillAmount = 0;

            AudioManager.instance.SonsFxTocar(1);
            GameManager.instance.setPossuiTiro(false);
        }
       
    }

    //forca
    void AddForca()
    {
        float x = forcaBola * Mathf.Cos(zRotateSeta * Mathf.Deg2Rad);
        float y = forcaBola * Mathf.Sin(zRotateSeta * Mathf.Deg2Rad);

        if (this.liberarTiro)
        {
            this.bolaRigidbody2D.AddForce(new Vector2(x, y));
            this.liberarTiro = false;
        }
    }

    void ControleDeForca()
    {
        if (this.liberaRotacao)
        {
            float moveX = Input.GetAxis("Mouse X");

            if (moveX < 0)
            {
                this.setaForcaImage.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
                this.forcaBola = this.setaForcaImage.GetComponent<Image>().fillAmount * 1000;
            }
            else if (moveX > 0)
            {
                this.setaForcaImage.GetComponent<Image>().fillAmount -= 0.8f * Time.deltaTime;
                this.forcaBola = this.setaForcaImage.GetComponent<Image>().fillAmount * 1000;
            }
        }
    }

    //outros
    private void BolaDinamica()
    {
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void MatarBola()
    {
        if(this.gameObject.transform.position.x > this.paredeDir.position.x)
        {
            Destroy(this.gameObject);
            GameManager.instance.setBolaEmCena(false);
            GameManager.instance.setBolasNum(1);
        }
        else if(this.gameObject.transform.position.x < this.paredeEsq.position.x)
        {
            Destroy(this.gameObject);
            GameManager.instance.setBolaEmCena(false);
            GameManager.instance.setBolasNum(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("armadilha"))
        {
            Destroy(this.gameObject);
            GameManager.instance.setBolaEmCena(false);
            GameManager.instance.setBolasNum(1);
        }

        if (collision.gameObject.CompareTag("gol"))
        {
            GameManager.instance.isGoal(true);
        }
    }
}
