using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomManager : MonoBehaviour
{
    private bool isZoomin = false;

    public Texture2D customCursor;
    public Texture2D customCursorZoomIn;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    public float zoomDistance = 5f;      // Distancia deseada entre cámara y este objeto
    public float zoomSpeed = 5f;         // Velocidad del movimiento

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public Transform target;

    void Start()
    {
        // Guarda la posición y rotación inicial
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        InspectorEvents.OnZoomin += ZoomIn;
    }
    private void OnDestroy()
    {
        InspectorEvents.OnZoomin -= ZoomIn;
    }

    // Update is called once per frame
    void Update()
    {
        //if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            //return;    
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;

        Transform clickedObject = hit.transform;

        if (isZoomin)
        {
            // Si ya está haciendo zoom a este objeto => salir
            if (clickedObject == target)
            {
                Debug.Log("Target: " + clickedObject.name);
                StopAllCoroutines();
                StartCoroutine(SmoothMove(transform.position, originalPosition, transform.rotation, originalRotation));
                target = null;
                UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                return;
            }

            // Nuevo objetivo de zoom
            target = clickedObject;
            Debug.Log("Target: " + target.name);

            Vector3 direction = (transform.position - target.position).normalized;
            Vector3 newPosition = target.position + direction * zoomDistance;
            Quaternion newRotation = Quaternion.LookRotation(target.position - newPosition);

            StopAllCoroutines();
            StartCoroutine(SmoothMove(transform.position, newPosition, transform.rotation, newRotation));

            UnityEngine.Cursor.SetCursor(customCursor, hotspot, cursorMode);
        }
        else
        {
            // Modo "zoom off" → siempre regresa a original
            StopAllCoroutines();
            StartCoroutine(SmoothMove(transform.position, originalPosition, transform.rotation, originalRotation));
            target = null;
            UnityEngine.Cursor.SetCursor(customCursorZoomIn, Vector2.zero, CursorMode.Auto);
        }
    }
    private System.Collections.IEnumerator SmoothMove(Vector3 fromPos, Vector3 toPos, Quaternion fromRot, Quaternion toRot)
    {
        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * zoomSpeed;
            transform.position = Vector3.Lerp(fromPos, toPos, elapsed);
            transform.rotation = Quaternion.Slerp(fromRot, toRot, elapsed);
            yield return null;
        }

        transform.position = toPos;
        transform.rotation = toRot;
    }
    public void ZoomIn(bool isZooming) 
    {
        isZoomin = isZooming;
    }
}
