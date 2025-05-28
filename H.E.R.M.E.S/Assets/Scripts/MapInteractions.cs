using UnityEngine;
using UnityEngine.UIElements;

public class MapInteractions : MonoBehaviour
{
    public UIDocument uiDocument;
    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;
        Toggle carril_Rio = root.Q<Toggle>("Carril_Rio");
        VisualElement Carril_Rio_Image = root.Q<VisualElement>("Carril_Rio");
        Label Carril_Rio_Title = root.Q<Label>("Carril_Rio");
        Label Carril_Rio_Texto = root.Q<Label>("Carril_Rio_Texto");
        carril_Rio.RegisterValueChangedCallback(evt =>
        {
            Carril_Rio_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Carril_Rio_Title.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Carril_Rio_Texto.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle carril_Norte = root.Q<Toggle>("Carril_Norte");
        VisualElement Carril_Norte_Image = root.Q<VisualElement>("Carril_Norte");
        Label Carril_Norte_Title = root.Q<Label>("Carril_Norte");
        Label Carril_Norte_Texto = root.Q<Label>("Carril_Norte_Texto");
        carril_Norte.RegisterValueChangedCallback(evt =>
        {
            Carril_Norte_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Carril_Norte_Title.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Carril_Norte_Texto.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle carril_Sur = root.Q<Toggle>("Carril_Sur");
        VisualElement Carril_Sur_Image = root.Q<VisualElement>("Carril_Sur");
        Label Carril_Sur_Title = root.Q<Label>("Carril_Sur");
        Label Carril_Sur_Texto = root.Q<Label>("Carril_Sur_Texto");
        carril_Sur.RegisterValueChangedCallback(evt =>
        {
            Carril_Sur_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Carril_Sur_Title.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Carril_Sur_Texto.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle conexion_Sureste = root.Q<Toggle>("Conexion_Sureste");
        VisualElement Conexion_Sureste_Image = root.Q<VisualElement>("Conexion_Sureste");
        Label Conexion_Sureste_Title = root.Q<Label>("Conexion_Sureste");
        Label Conexion_Sureste_Texto = root.Q<Label>("Conexion_Sureste_Texto");
        conexion_Sureste.RegisterValueChangedCallback(evt =>
        {
            Conexion_Sureste_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Conexion_Sureste_Title.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Conexion_Sureste_Texto.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle conexion_Noroeste = root.Q<Toggle>("Conexion_Noroeste");
        VisualElement Conexion_Noroeste_Image = root.Q<VisualElement>("Conexion_Noroeste");
        Label Conexion_Noroeste_Title = root.Q<Label>("Conexion_Noroeste");
        Label Conexion_Noroeste_Texto = root.Q<Label>("Conexion_Noroeste_Texto");
        conexion_Noroeste.RegisterValueChangedCallback(evt =>
        {
            Conexion_Noroeste_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Conexion_Noroeste_Title.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Conexion_Noroeste_Texto.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle transversal_Sur = root.Q<Toggle>("Transversal_Sur");
        VisualElement Transversal_Sur_Image = root.Q<VisualElement>("Transversal_Sur");
        Label Transversal_Sur_Title = root.Q<Label>("Transversal_Sur");
        Label Transversal_Sur_Texto = root.Q<Label>("Transversal_Sur_Texto");
        transversal_Sur.RegisterValueChangedCallback(evt =>
        {
            Transversal_Sur_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Transversal_Sur_Title.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Transversal_Sur_Texto.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle transversal_Norte = root.Q<Toggle>("Transversal_Norte");
        VisualElement Transversal_Norte_Image = root.Q<VisualElement>("Transversal_Norte");
        Label Transversal_Norte_Title = root.Q<Label>("Transversal_Norte");
        Label Transversal_Norte_Texto = root.Q<Label>("Transversal_Norte_Texto");
        transversal_Norte.RegisterValueChangedCallback(evt =>
        {
            Transversal_Norte_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Transversal_Norte_Title.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            Transversal_Norte_Texto.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle conexiones = root.Q<Toggle>("Conexiones");
        VisualElement Conexiones_Image = root.Q<VisualElement>("Conexiones");
        conexiones.RegisterValueChangedCallback(evt =>
        {
            Conexiones_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
        Toggle estaciones = root.Q<Toggle>("Estaciones");
        VisualElement Estaciones_Image = root.Q<VisualElement>("Estaciones");       
        estaciones.RegisterValueChangedCallback(evt =>
        {
            Estaciones_Image.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
        });
    }
}
