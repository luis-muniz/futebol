using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forca : MonoBehaviour
{
    private Rigidbody2D bolaRigidbody2D;
    private Rotacao rotacaoSeta;
    public float forcaBola = 0.0f;
    [SerializeField]private Image setaForcaImage;

    // Start is called before the first frame update
    void Start()
    {
        bolaRigidbody2D = GetComponent<Rigidbody2D>();
        rotacaoSeta = GetComponent<Rotacao>();
    }

    // Update is called once per frame
    void Update()
    {
        AddForca();
        ControleDeForca();
    }

    void AddForca()
    {
        float x = forcaBola * Mathf.Cos(rotacaoSeta.zRotateSeta * Mathf.Deg2Rad);
        float y = forcaBola * Mathf.Sin(rotacaoSeta.zRotateSeta * Mathf.Deg2Rad);

        if (this.rotacaoSeta.liberarTiro)
        {
            bolaRigidbody2D.AddForce(new Vector2(x, y));
            this.rotacaoSeta.liberarTiro = false;
        }
    }

    void ControleDeForca()
    {
        if (this.rotacaoSeta.liberaRotacao)
        {
            float moveX = Input.GetAxis("Mouse X");

            if (moveX < 0)
            {
                setaForcaImage.fillAmount += 0.8f*Time.deltaTime;
                this.forcaBola = this.setaForcaImage.fillAmount * 1000;
            }else if (moveX > 0)
            {
                setaForcaImage.fillAmount -= 0.8f * Time.deltaTime;
                this.forcaBola = this.setaForcaImage.fillAmount * 1000;
            }
        }
    }
}
