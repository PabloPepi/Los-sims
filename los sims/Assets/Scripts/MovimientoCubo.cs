using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCubo : MonoBehaviour
{/*
    public enum estados{
    EnEspera,
    ObjetoSeleccionado,
    Mover,
    Soltar,
    Escalar,
    Rotar,
    //etc....
    }

    Vector2 mousePos;

    [SerializeField]
    GameObject button;

    [SerializeField]
    estados estadoActual = estados.EnEspera;
    public GameObject movible;

    // Update is called once per frame
    void Update()
    {
        switch (estadoActual) 

        {

            case estados.ObjetoSeleccionado:
                SeleccionObj();
                break;
            case estados.Mover:
                MoverObj();
                break;
            case estados.Soltar:
                SoltarObj();
                break;

        }


       


    }
    void SeleccionObj()
    {
        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Vector3 pos = Input.mousePosition;

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                GameObject obj = hitInfo.transform.gameObject;
                if (obj.CompareTag("OBJ"))
                {
                    estadoActual = estados.ObjetoSeleccionado;
                    movible = obj;
                    estadoActual = estados.Mover;
                }
               
                
            }
        }
    }
        void MoverObj()
        {
        RaycastHit hitInfo;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        movible.SetActive(false);
        if (Physics.Raycast(rayo, out hitInfo))
        {
            movible.transform.position = hitInfo.point + Vector3.up * movible.transform.localScale.y / 2;
        }
        movible.SetActive(true);
        if (Input.GetMouseButtonUp(0)){ estadoActual = estados.Soltar; }
    }

    void SoltarObj()
    {
        movible = null;
        estadoActual = estados.EnEspera;
    }
   public void boton() 
    {
        estadoActual = estados.ObjetoSeleccionado;
        LeanTween.scale(button, new Vector3(1.5f, 1.5f, 1.5f), 1f).setEase(LeanTweenType.easeOutElastic);
        if (estadoActual == estados.EnEspera)
        {
            LeanTween.scale(button, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeOutElastic);

        }
    }

    void rotarObjeto()
    { Vector2 mouseDelta = mousePos - (Vector2)Input.mousePosition;
        movible.transform.Rotate(mouseDelta.y, mouseDelta.x, 0f);
        mousePos = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
        {

            movible.GetComponent<Rigidbody>().isKinematic = false;
            estadoActual = EstadosSelector.EnEspera;

        }
    }


}*/
    public enum EstadosSelector
    {
        EnEspera,
        SeleccionObjetoMover,
        SeleccionObjetoRotar,
        SeleccionObjetoEscalar,
        Soltar,
        Mover,
        Escalar,
        Rotar,
        //........ Los estados que necesitemos .......//
    }
    Vector2 mousePos;
    [SerializeField]
    EstadosSelector estadoActual = EstadosSelector.EnEspera;

    [SerializeField]
    GameObject canvasBotones, canvasFormas;


    public GameObject objetoSeleccionado;
    void Update()
    {
        switch (estadoActual)
        {
            case EstadosSelector.EnEspera:
                estadoActual = EstadosSelector.EnEspera;
                break;
            case EstadosSelector.SeleccionObjetoMover:
                SeleccionObjeto();
                break;
            case EstadosSelector.SeleccionObjetoRotar:
                SeleccionObjeto();
                break;
            case EstadosSelector.SeleccionObjetoEscalar:
                SeleccionObjeto();
                break;
            case EstadosSelector.Mover:
                MoverObjeto();
                break;
            case EstadosSelector.Soltar:
                SoltarObjeto();
                break;
            case EstadosSelector.Rotar:
                RotarObjeto();
                break;
            case EstadosSelector.Escalar:
                EscalarObjeto();
                break;
        }
    }
    void SeleccionObjeto()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.CompareTag("OBJ"))
                {
                    objetoSeleccionado = objectHit;
                    ObjetoSeleccionadoCambiarEstado();

                }
            }
        }
    }
    void ObjetoSeleccionadoCambiarEstado()
    {
        switch (estadoActual)
        {
            case EstadosSelector.SeleccionObjetoMover:
                estadoActual = EstadosSelector.Mover;
                break;
            case EstadosSelector.SeleccionObjetoRotar:
                objetoSeleccionado.GetComponent<Rigidbody>().isKinematic = true;
                mousePos = Input.mousePosition;
                estadoActual = EstadosSelector.Rotar;
                break;
            case EstadosSelector.SeleccionObjetoEscalar:
                estadoActual = EstadosSelector.Escalar;
                break;
        }
    }
    void MoverObjeto()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        objetoSeleccionado.SetActive(false);
        if (Physics.Raycast(ray, out hit))
        {
            objetoSeleccionado.transform.position = hit.point + ((Vector3.up *
           objetoSeleccionado.transform.localScale.y) / 2);
        }
        objetoSeleccionado.SetActive(true);
        if (Input.GetMouseButtonUp(0))//si hay un clic
        {
            estadoActual = EstadosSelector.Soltar;
        }
    }
    void RotarObjeto()
    {
        Vector2 mouseDelta = mousePos - (Vector2)Input.mousePosition;
        objetoSeleccionado.transform.Rotate(mouseDelta.y, mouseDelta.x, 0f);

        mousePos = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
        {
            objetoSeleccionado.GetComponent<Rigidbody>().isKinematic = false;
            estadoActual = EstadosSelector.EnEspera;
        }
    }
    void EscalarObjeto()
    {
        objetoSeleccionado.transform.localScale += Vector3.one * Input.mouseScrollDelta.y;
        if (Input.GetMouseButtonUp(0))
        {
            estadoActual = EstadosSelector.EnEspera;
        }
    }
    void SoltarObjeto()
    {
        objetoSeleccionado = null;
        estadoActual = EstadosSelector.EnEspera;
    }
    public void EnterSelectMove()
    {
        estadoActual = EstadosSelector.SeleccionObjetoMover;
    }
    public void EnterSelectRotate()
    {
        estadoActual = EstadosSelector.SeleccionObjetoRotar;
    }
    public void EnterSelectEscalar()
    {
        estadoActual = EstadosSelector.SeleccionObjetoEscalar;

    }
    
    public void formas()
    {

        canvasFormas.SetActive(true);


    }










}

