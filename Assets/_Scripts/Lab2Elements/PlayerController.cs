using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;      // how fast the player slides toward the touch
    public float padding = 0.5f;   // keeps the sprite fully on screen

    private Camera cam;
    private float targetX;

    void Start()
    {
        cam = Camera.main;
        targetX = transform.position.x;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // ignore touches that land on UI buttons (Back / Next)
            if (!IsOverUI(touch.fingerId))
                targetX = cam.ScreenToWorldPoint(touch.position).x;
        }
        else if (Input.GetMouseButton(0)) // mouse fallback for testing in the Editor
        {
            if (!IsOverUI(-1))
                targetX = cam.ScreenToWorldPoint(Input.mousePosition).x;
        }

        float halfWidth = cam.orthographicSize * cam.aspect - padding;
        targetX = Mathf.Clamp(targetX, -halfWidth, halfWidth);

        Vector3 pos = transform.position;
        pos.x = Mathf.MoveTowards(pos.x, targetX, speed * Time.deltaTime);
        transform.position = pos;
    }

    private bool IsOverUI(int fingerId)
    {
        if (EventSystem.current == null) return false;
        return fingerId < 0 ? EventSystem.current.IsPointerOverGameObject() : EventSystem.current.IsPointerOverGameObject(fingerId);
    }
}