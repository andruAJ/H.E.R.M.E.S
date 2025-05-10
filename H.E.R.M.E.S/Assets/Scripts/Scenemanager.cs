using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button modelo;
    private Button mapa;
    private Button video;
    private string escena;
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        modelo = uiDocument.rootVisualElement.Q("Modelo") as Button;
        modelo.RegisterCallback<ClickEvent>(evt =>
        {
            escena = "ModeloTren";
            ChangeScene(escena);
        });
        mapa = uiDocument.rootVisualElement.Q("Mapa") as Button;
        mapa.RegisterCallback<ClickEvent>(evt =>
        {
            escena = "MapaScene";
            ChangeScene(escena);
        });
        video = uiDocument.rootVisualElement.Q("Video") as Button;
        video.RegisterCallback<ClickEvent>(evt =>
        {
            escena = "VideoScene";
            ChangeScene(escena);
        });
    }
    private void ChangeScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
}
