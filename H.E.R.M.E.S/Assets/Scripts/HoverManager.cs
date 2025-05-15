using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class HoverManager : MonoBehaviour
{
    public UIDocument document;
    private VisualElement namePanel;
    public CapasInformation panelSupIzq;
    public CapasInformation panelInfIzq;
    public CapasInformation panelSupDer;
    public CapasInformation panelInfDer;
    public CapasInformation asientos;
    public CapasInformation bandaTransVert;
    public CapasInformation bandaTransHoriz;
    public CapasInformation intercambiador;
    public bool isExploding = false;

    void Start()
    {
        document = GameObject.FindWithTag("UI")?.GetComponent<UIDocument>();
        if (document == null)
        {
            Debug.LogError("No se encontró el UIdocument");
            return;
        }
        namePanel = document.rootVisualElement.Q("NamesPanel") as VisualElement;
        if(namePanel != null)
        {
            Debug.Log("NamePanel no encontrado");
        }
        InspectorEvents.OnExploding += hasExploded;
    }
    void OnDestroy()
    {
        InspectorEvents.OnExploding -= hasExploded;
    }
    private void OnMouseEnter()
    {
        if (!isExploding) 
        {
            switch (this.tag)
            {
                case "Asientos":
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(asientos));
                    break;
                case "Panel superior":
                    Debug.Log("Data: " + panelSupIzq);
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(panelSupIzq));
                    break;
                case "Panel inferior":
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(panelInfIzq));
                    break;
                case "Panell superior derecho":
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(panelSupDer));
                    break;
                case "Panell inferior derecho":
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(panelInfDer));
                    break;
                case "Banda transportadora vertical":
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(bandaTransVert));
                    break;
                case "Banda transportadora horizontal":
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(bandaTransHoriz));
                    break;
                case "Intercambiador":
                    namePanel.style.display = DisplayStyle.Flex;
                    namePanel.Bind(new SerializedObject(intercambiador));
                    break;
            }
        }        
    }
    private void OnMouseExit() 
    {
        namePanel.style.display = DisplayStyle.None;
    }
    public void hasExploded(bool state)
    {
        isExploding = state;
    }
}
