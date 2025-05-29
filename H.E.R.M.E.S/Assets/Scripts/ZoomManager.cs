using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomManager : MonoBehaviour
{
    public Texture2D customCursor;
    public Texture2D customCursorZoomIn;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    public float zoomDistance = 5f;
    public float zoomSpeed = 5f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private Transform target;

    private bool isZoomMode = false;   // Si se activó el botón de zoom
    private bool isZoomedIn = false;   // Si la cámara ya está acercada a un objeto

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        InspectorEvents.OnZoomin += ToggleZoomMode;
    }

    void OnDestroy()
    {
        InspectorEvents.OnZoomin -= ToggleZoomMode;
    }

    void Update()
    {
        if (!isZoomMode) return;
        if (!Input.GetMouseButtonDown(0)) return;
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;

        Transform clickedObject = hit.transform;

        if (isZoomedIn && clickedObject == target)
        {
            // Zoom out
            StopAllCoroutines();
            StartCoroutine(SmoothMove(transform.position, originalPosition, transform.rotation, originalRotation));
            UnityEngine.Cursor.SetCursor(customCursorZoomIn, hotspot, cursorMode);
            isZoomedIn = false;
            target = null;
            return;
        }

        // Zoom in to new target
        target = clickedObject;
        Vector3 direction = (transform.position - target.position).normalized;
        Vector3 newPosition = target.position + direction * zoomDistance;
        Quaternion newRotation = Quaternion.LookRotation(target.position - newPosition);

        StopAllCoroutines();
        StartCoroutine(SmoothMove(transform.position, newPosition, transform.rotation, newRotation));
        UnityEngine.Cursor.SetCursor(customCursor, hotspot, cursorMode);
        isZoomedIn = true;
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

    public void ToggleZoomMode(bool enable)
    {
        isZoomMode = enable;
        isZoomedIn = false;
        target = null;

        if (isZoomMode)
        {
            UnityEngine.Cursor.SetCursor(customCursorZoomIn, hotspot, cursorMode);
        }
        else
        {
            UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
