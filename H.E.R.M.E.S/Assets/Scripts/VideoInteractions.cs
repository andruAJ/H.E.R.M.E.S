using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class VideoInteractions : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button home;
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        home = uiDocument.rootVisualElement.Q("Home") as Button;
        home.RegisterCallback<ClickEvent>(ReturnToMenu);
    }
    private void ReturnToMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Update()
    {
        
    }
}
