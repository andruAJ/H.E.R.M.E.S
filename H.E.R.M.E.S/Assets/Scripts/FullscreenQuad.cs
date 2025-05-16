using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FullscreenQuad : MonoBehaviour
{
    public Camera targetCamera;
    public float distanceFromCamera = 5f;

    void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }

        // Calcula la altura visible en unidades del mundo a esa distancia
        float height = 2f * distanceFromCamera * Mathf.Tan(targetCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float width = height * targetCamera.aspect;

        // Escala el Quad
        transform.localScale = new Vector3(width, height, 1f);

        // Posiciona el Quad justo frente a la c�mara
        transform.position = targetCamera.transform.position + targetCamera.transform.forward * distanceFromCamera;

        // Aseg�rate de que est� orientado hacia la c�mara
        transform.rotation = targetCamera.transform.rotation;
    }
}
