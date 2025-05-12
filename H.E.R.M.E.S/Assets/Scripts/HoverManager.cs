using UnityEngine;
using UnityEngine.UIElements;

public class HoverManager : MonoBehaviour
{
    public UIDocument document;
    private TextField namePanel;

    void Start()
    {
        document = GameObject.FindWithTag("UI")?.GetComponent<UIDocument>();
        if (document == null)
        {
            Debug.LogError("No se encontró el UIdocument");
            return;
        }
        namePanel = document.rootVisualElement.Q("NamePanel") as TextField;
        if(namePanel != null)
        {
            Debug.Log("NamePanel no encontrado");
        }       
    }
    private void OnMouseEnter()
    {
        Debug.Log(this.tag);
    }
    private void OnMouseExit() 
    {
    
    }
}
