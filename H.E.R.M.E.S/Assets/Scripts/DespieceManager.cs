using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DespieceManager : MonoBehaviour
{
    public UIDocument document;
    private VisualElement informationPanel;
    public CapasInformation panelSupIzq;
    public CapasInformation panelInfIzq;
    public CapasInformation panelSupDer;
    public CapasInformation panelInfDer;
    public CapasInformation asientos;
    public CapasInformation bandaTransVert;
    public CapasInformation bandaTransHoriz;
    public CapasInformation intercambiador;
    public CapasInformation bateria;
    public CapasInformation oruga;
    public bool isExploding = false;
    void Start()
    {
        document = GameObject.FindWithTag("UI")?.GetComponent<UIDocument>();
        if (document == null)
        {
            Debug.LogError("No se encontró el UIdocument");
            return;
        }
        informationPanel = document.rootVisualElement.Q("InformationPanel") as VisualElement;
        if (informationPanel != null)
        {
            //Debug.Log("NamePanel no encontrado");
        }
        InspectorEvents.OnExploding += hasExploded;
    }
    void OnDestroy()
    {
        InspectorEvents.OnExploding -= hasExploded;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isExploding) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Asientos":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(asientos);
                            break;
                        case "Panel superior":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(panelSupIzq);
                            break;
                        case "Panel inferior":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(panelInfIzq);
                            break;
                        case "Panell superior derecho":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(panelSupDer);
                            break;
                        case "Panell inferior derecho":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(panelInfDer);
                            break;
                        case "Banda transportadora vertical":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(bandaTransVert);
                            break;
                        case "Banda transportadora horizontal":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(bandaTransHoriz);
                            break;
                        case "Intercambiador":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(intercambiador);
                            break;
                        case "Bateria":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(bateria);
                            break;
                        case "Oruga":
                            informationPanel.style.display = DisplayStyle.Flex;
                            ActualizarPanelConDatos(oruga);
                            break;
                    }
                }
                else 
                {
                    informationPanel.style.display = DisplayStyle.None;
                }
            }            
        }
    }
    public void hasExploded(bool state) 
    {
        isExploding = state;
    }
    private void ActualizarPanelConDatos(CapasInformation data)
    {
        var nombre = informationPanel.Q<Label>("Name");
        var descripcion = informationPanel.Q<Label>("Description");
        var material = informationPanel.Q<Label>("Material");

        if (nombre != null) nombre.text = data.nombre;
        if (descripcion != null) descripcion.text = data.description;
        if (material != null) material.text = data.material;
    }
}
