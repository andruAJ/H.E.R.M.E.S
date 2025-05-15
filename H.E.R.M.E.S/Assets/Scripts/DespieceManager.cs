using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

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
            Debug.Log("NamePanel no encontrado");
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
                            informationPanel.Bind(new SerializedObject(asientos));
                            break;
                        case "Panel superior":
                            Debug.Log("Data: " + panelSupIzq);
                            informationPanel.style.display = DisplayStyle.Flex;
                            informationPanel.Bind(new SerializedObject(panelSupIzq));
                            break;
                        case "Panel inferior":
                            informationPanel.style.display = DisplayStyle.Flex;
                            informationPanel.Bind(new SerializedObject(panelInfIzq));
                            break;
                        case "Panell superior derecho":
                            informationPanel.style.display = DisplayStyle.Flex;
                            informationPanel.Bind(new SerializedObject(panelSupDer));
                            break;
                        case "Panell inferior derecho":
                            informationPanel.style.display = DisplayStyle.Flex;
                            informationPanel.Bind(new SerializedObject(panelInfDer));
                            break;
                        case "Banda transportadora vertical":
                            informationPanel.style.display = DisplayStyle.Flex;
                            informationPanel.Bind(new SerializedObject(bandaTransVert));
                            break;
                        case "Banda transportadora horizontal":
                            informationPanel.style.display = DisplayStyle.Flex;
                            informationPanel.Bind(new SerializedObject(bandaTransHoriz));
                            break;
                        case "Intercambiador":
                            informationPanel.style.display = DisplayStyle.Flex;
                            informationPanel.Bind(new SerializedObject(intercambiador));
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
}
