using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    private bool isZoomin;

    public Texture2D customCursor;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;
    void Start()
    {
        InspectorEvents.OnZoomin += ZoomIn;
    }
    private void OnDestroy()
    {
        InspectorEvents.OnZoomin -= ZoomIn;
    }

    // Update is called once per frame
    void Update()
    {
        if (isZoomin) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit)) 
                {

                    UnityEngine.Cursor.SetCursor(customCursor, hotspot, cursorMode);
                }               
            }              
        }
        else 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    
                }
            }         
        }
    }
    public void ZoomIn(bool isZooming) 
    {
        isZoomin = isZooming;
    }
}
