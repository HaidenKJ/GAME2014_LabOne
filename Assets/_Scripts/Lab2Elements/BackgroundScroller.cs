using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float tileWidth;

    void Start()
    {
        tileWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // once fully off the left side, jump to the right of the other tile
        if (transform.position.x <= -tileWidth)
        {
            transform.position += Vector3.right * tileWidth * 2f;
        }
    }
}