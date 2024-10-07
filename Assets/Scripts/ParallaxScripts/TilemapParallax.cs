using UnityEngine;

public class TilemapParallax : MonoBehaviour
{
    public Camera cam;
    public float parallaxFactor = 1f;
    public bool repeatHorizontally = true;
    public bool repeatVertically = false;

    private float textureUnitSizeX;
    private float textureUnitSizeY;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Sprite sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector2 camPosition = cam.transform.position;
        Vector2 temp = camPosition * (1 - parallaxFactor);
        Vector2 distance = camPosition * parallaxFactor;

        transform.position = new Vector3(
            startPosition.x + distance.x,
            startPosition.y + distance.y,
            transform.position.z
        );

        if (repeatHorizontally)
        {
            if (temp.x > startPosition.x + textureUnitSizeX)
            {
                startPosition.x += textureUnitSizeX;
            }
            else if (temp.x < startPosition.x - textureUnitSizeX)
            {
                startPosition.x -= textureUnitSizeX;
            }
        }

        if (repeatVertically)
        {
            if (temp.y > startPosition.y + textureUnitSizeY)
            {
                startPosition.y += textureUnitSizeY;
            }
            else if (temp.y < startPosition.y - textureUnitSizeY)
            {
                startPosition.y -= textureUnitSizeY;
            }
        }
    }
}