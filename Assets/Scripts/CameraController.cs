using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform clampMin, clampMax;

    private Transform target;
    private Camera cam;
    private float halfWidth;
    private float halfHeigth;

    private void Start()
    {
        cam = GetComponent<Camera>();
        halfHeigth = cam.orthographicSize;
        halfWidth = cam.orthographicSize * cam.aspect;
        
        target = FindAnyObjectByType<PlayerController>().transform;

        clampMin.SetParent(null);
        clampMax.SetParent(null);
    }

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampMin.position.y + halfHeigth, clampMax.position.y - halfHeigth);

        transform.position = clampedPosition;
    }
}
