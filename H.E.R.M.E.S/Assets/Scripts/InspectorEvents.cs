using Mono.Cecil.Cil;
using System;
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

    public static event Action<int> OnRotatingLeft;
    public static event Action<int> OnRotatingRight;

    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        rotateLeftButton = uiDocument.rootVisualElement.Q("RotateLeftButton") as Button;
        rotateLeftButton.RegisterCallback<ClickEvent>(evt =>
        {
            isRotatingLeft = true;
            Debug.Log("LeftButton Down");
        });
        rotateRightButton = uiDocument.rootVisualElement.Q("RotateRightButton") as Button;
        rotateRightButton.RegisterCallback<ClickEvent>(evt =>
        {
            isRotatingRight = true;
            Debug.Log("RightButton Down");
        });
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

    //private void OnEnable()
    //{
    //    Botón Izquierdo
    //    rotateLeftButton.RegisterCallback<PointerDownEvent>(evt =>
    //    {
    //        isRotatingLeft = true;
    //        Debug.Log("LeftButton Down");
    //    });
    //    rotateLeftButton.RegisterCallback<PointerUpEvent>(evt =>
    //    {
    //        isRotatingLeft = false;
    //        Debug.Log("LeftButton Up");
    //    });
    //    rotateLeftButton.RegisterCallback<PointerCancelEvent>(evt =>
    //    {
    //        isRotatingLeft = false;
    //        Debug.Log("LeftButton Cancel");
    //    });

    //    Botón Derecho
    //    rotateRightButton.RegisterCallback<PointerDownEvent>(evt =>
    //    {
    //        isRotatingRight = true;
    //        Debug.Log("RightButton Down");
    //    });
    //    rotateRightButton.RegisterCallback<PointerUpEvent>(evt =>
    //    {
    //        isRotatingRight = false;
    //        Debug.Log("RightButton Up");
    //    });
    //    rotateRightButton.RegisterCallback<PointerCancelEvent>(evt =>
    //    {
    //        isRotatingRight = false;
    //        Debug.Log("RightButton Cancel");
    //    });
    //}
    private void ZoomEvent(ClickEvent evt) 
    {
    
    }
    private void CapasEvent(ClickEvent evt)
    {

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
    }
}
