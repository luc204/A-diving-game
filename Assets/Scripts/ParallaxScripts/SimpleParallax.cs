using UnityEngine;

public class SimpleParallax : MonoBehaviour
{
    public Camera cam;
    public float parallaxFactor = 1f;

    private float startPosX;
    private float startPosY;

    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        float distX = (cam.transform.position.x * parallaxFactor);
        float distY = (cam.transform.position.y * parallaxFactor);

        transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);
    }
}
