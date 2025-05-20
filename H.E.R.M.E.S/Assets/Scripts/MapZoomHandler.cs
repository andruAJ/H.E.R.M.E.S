using UnityEngine;
using UnityEngine.UIElements;

public class MapZoomHandler : MonoBehaviour
{
    public UIDocument uiDocument;
    private VisualElement mapImage;
    private float zoom = 1f;
    private const float zoomMin = 0.5f;
    private const float zoomMax = 3f;
    private const float zoomStep = 0.1f;

    private Vector2 panStartMouse;
    private Vector2 panStartOffset;
    private bool isPanning = false;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;
        mapImage = root.Q<VisualElement>("Map");

        mapImage.RegisterCallback<WheelEvent>(evt =>
        {
            zoom -= evt.delta.y * zoomStep * 0.1f;
            zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);

            mapImage.style.scale = new Scale(new Vector3(zoom, zoom, 1f));
        });
        mapImage.RegisterCallback<PointerDownEvent>(evt =>
        {
            if (evt.button == 0 || evt.button == 2) // botón izquierdo o del medio
            {
                isPanning = true;
                panStartMouse = evt.position;
                panStartOffset = mapImage.resolvedStyle.translate;
                mapImage.CapturePointer(evt.pointerId);
            }
        });

        mapImage.RegisterCallback<PointerMoveEvent>(evt =>
        {
            if (isPanning)
            {
                Vector2 mousePos = new Vector2(evt.position.x, evt.position.y);
                Vector2 delta = mousePos - panStartMouse;
                mapImage.style.translate = new Translate(
                    panStartOffset.x + delta.x,
                    panStartOffset.y + delta.y,
                    0f
                );
            }
        });

        mapImage.RegisterCallback<PointerUpEvent>(evt =>
        {
            isPanning = false;
            mapImage.ReleasePointer(evt.pointerId);
        });

        mapImage.RegisterCallback<PointerLeaveEvent>(evt =>
        {
            isPanning = false;
            mapImage.ReleasePointer(evt.pointerId);
        });
    }
}
