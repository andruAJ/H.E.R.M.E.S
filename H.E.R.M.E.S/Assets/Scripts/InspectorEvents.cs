using Mono.Cecil.Cil;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InspectorEvents : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button rotateLeftButton;
    private Button rotateRightButton;
    private Button lupa;
    private Button capas;
    private VisualElement informationPanel;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool explode = false;
    private bool de_explode = false;
    private bool regroup = false;

    public static event Action<int> OnRotatingLeft;
    public static event Action<int> OnRotatingRight;
    public static event Action<bool> OnExploding;

    public Animator animator;

    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        animator = GameObject.FindWithTag("Tren").GetComponent<Animator>();
        rotateLeftButton = uiDocument.rootVisualElement.Q("RotateLeftButton") as Button;
        rotateLeftButton.RegisterCallback<PointerDownEvent>(evt =>
        {
            isRotatingLeft = true;
            isRotatingRight = false;
        }, TrickleDown.TrickleDown);
        rotateLeftButton.RegisterCallback<PointerUpEvent>(evt =>
        {
                isRotatingLeft = false;
                isRotatingRight = false;
        }, TrickleDown.TrickleDown);
        rotateLeftButton.RegisterCallback<PointerCancelEvent>(evt =>
        {
            isRotatingRight = false;
            isRotatingLeft = false;
        }, TrickleDown.TrickleDown);
        rotateRightButton = uiDocument.rootVisualElement.Q("RotateRightButton") as Button;
        rotateRightButton.RegisterCallback<PointerDownEvent>(evt =>
        {
            isRotatingRight = true;
            isRotatingLeft = false;
        }, TrickleDown.TrickleDown);
        rotateRightButton.RegisterCallback<PointerUpEvent>(evt =>
        {
            isRotatingRight = false;
            isRotatingLeft = false;
        }, TrickleDown.TrickleDown);
        rotateRightButton.RegisterCallback<PointerCancelEvent>(evt =>
        {
            isRotatingRight = false;
            isRotatingLeft = false;
        }, TrickleDown.TrickleDown);
        lupa = uiDocument.rootVisualElement.Q("lupa") as Button;
        lupa.RegisterCallback<ClickEvent>(ZoomEvent);
        capas = uiDocument.rootVisualElement.Q("capas") as Button;
        capas.RegisterCallback<ClickEvent>(CapasEvent);

        if (rotateLeftButton == null || rotateRightButton == null || lupa == null || capas == null)
        {
            Debug.LogError("No se encontraron los botones en el Visual Tree.");
            return;
        }
    }
    private void ZoomEvent(ClickEvent evt) 
    {
        
    }
    private void CapasEvent(ClickEvent evt)
    {
        if (!explode && !de_explode && !regroup) 
        {
            GameObject panelInferior = GameObject.FindWithTag("Panel inferior");
            GameObject panelSuperior = GameObject.FindWithTag("Panel superior");
            GameObject bandaHorizontal = GameObject.FindWithTag("Banda transportadora horizontal").transform.GetChild(0).gameObject;
            GameObject bordeCorte = null;
            GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                if (obj.CompareTag("Borde corte"))
                {
                    bordeCorte = obj;
                    break;
                }
            }

            panelInferior.SetActive(false);
            panelSuperior.SetActive(false);
            bandaHorizontal.SetActive(false);
            bordeCorte.SetActive(true);

            explode = true;
        }    
        else if(explode) 
        {
            GameObject bordecorte = GameObject.FindWithTag("Borde corte");
            bordecorte.SetActive(false);
            animator.SetTrigger("Exploding");
            explode = false;
            de_explode = true;
            OnExploding.Invoke(true);
            Debug.Log("Explosion");
        }
        else if (de_explode) 
        {
            animator.SetTrigger("De-exploding");
            de_explode = false;
            regroup = true;
            OnExploding.Invoke(false);
            GameObject bordeCorte = null;
            GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                if (obj.CompareTag("Borde corte"))
                {
                    bordeCorte = obj;
                    break;
                }
            }
            bordeCorte.SetActive(true);
            animator.SetTrigger("GoingToIdle");
            Debug.Log("De exploding");
        }
        else if (regroup) 
        {
            GameObject panelInferior = null;
            GameObject panelSuperior = null;
            GameObject bandaHorizontal = null;
            GameObject bordeCorte = GameObject.FindWithTag("Borde corte");
            GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                if (obj.CompareTag("Panel inferior"))
                {
                    panelInferior = obj;
                    panelInferior.SetActive(true);
                }
                else if (obj.CompareTag("Panel superior")) 
                {
                    panelSuperior = obj;
                    panelSuperior.SetActive(true);
                }
                else if (obj.CompareTag("Banda transportadora horizontal"))
                {
                    bandaHorizontal = obj.transform.GetChild(0).gameObject;
                    bandaHorizontal.SetActive(true);
                }
            }    
            bordeCorte.SetActive(false);
            regroup = false;
            Debug.Log("re agrupando");
        }
    }

    private void Update()
    {
        if (isRotatingLeft)
        {
            OnRotatingLeft?.Invoke(-1);
        }
        else if (isRotatingRight)
        {
            OnRotatingRight?.Invoke(1);
        }
        else 
        {
            OnRotatingRight?.Invoke(0);
            OnRotatingRight?.Invoke(0);
        }
    }
}
