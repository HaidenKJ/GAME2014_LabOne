using UnityEngine;

// Attach to BOTH background tiles. Tile 1 at Y = 0, Tile 2 at Y = tile height.
public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float tileHeight;

    void Start()
    {
        tileHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // once fully below the first position, jump above the other tile
        if (transform.position.y <= -tileHeight)
        {
            transform.position += Vector3.up * tileHeight * 2f;
        }
    }
}