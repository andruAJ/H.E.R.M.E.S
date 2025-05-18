using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    private bool isZoomin = false;

    public Texture2D customCursor;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    public float zoomDistance = 3f;      // Distancia deseada entre cámara y este objeto
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
        if (isZoomin) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit)) 
                {
                    target = hit.transform;
                    if (target == null) return;

                    // Dirección del target a la cámara
                    Vector3 direction = (transform.position - target.position).normalized;

                    // Nueva posición a distancia deseada
                    Vector3 newPosition = target.position + direction * zoomDistance;

                    // Puedes hacerlo con Lerp si quieres suavidad, o directo:
                    StopAllCoroutines();
                    StartCoroutine(SmoothMove(transform.position, newPosition, transform.rotation, Quaternion.LookRotation(target.position - newPosition)));
                    UnityEngine.Cursor.SetCursor(customCursor, hotspot, cursorMode);
                }               
            }              
        }
        else if (!isZoomin)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    StopAllCoroutines();
                    StartCoroutine(SmoothMove(transform.position, originalPosition, transform.rotation, originalRotation));

                }
            }         
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
