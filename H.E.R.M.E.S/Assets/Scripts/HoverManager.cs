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
                    ActualizarPanelConDatos(asientos);
                    break;
                case "Panel superior":
                    Debug.Log("Data: " + panelSupIzq);
                    namePanel.style.display = DisplayStyle.Flex;
                    ActualizarPanelConDatos(panelSupIzq);
                    break;
                case "Panel inferior":
                    namePanel.style.display = DisplayStyle.Flex;
                    ActualizarPanelConDatos(panelInfIzq);
                    break;
                case "Panell superior derecho":
                    namePanel.style.display = DisplayStyle.Flex;
                    ActualizarPanelConDatos(panelSupDer);
                    break;
                case "Panell inferior derecho":
                    namePanel.style.display = DisplayStyle.Flex;
                    ActualizarPanelConDatos(panelInfDer);
                    break;
                case "Banda transportadora vertical":
                    namePanel.style.display = DisplayStyle.Flex;
                    ActualizarPanelConDatos(bandaTransVert);
                    break;
                case "Banda transportadora horizontal":
                    namePanel.style.display = DisplayStyle.Flex;
                    ActualizarPanelConDatos(bandaTransHoriz);
                    break;
                case "Intercambiador":
                    namePanel.style.display = DisplayStyle.Flex;
                    ActualizarPanelConDatos(intercambiador);
                    break;
            }
        }        
    }
    private void OnMouseExit() 
    {
        namePanel.style.display = DisplayStyle.None;
    }
    private void ActualizarPanelConDatos(CapasInformation data)
    {
        var nombre = namePanel.Q<Label>("Name");
        if (nombre != null) nombre.text = data.nombre;
    }
    public void hasExploded(bool state)
    {
        isExploding = state;
    }
}
