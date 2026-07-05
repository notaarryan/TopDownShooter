using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        float x = 0f;
        float y = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            y += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            y -= 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            x -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            x += 1;
        }
        Vector2 direction = new Vector2(x, y).normalized;
        Vector2 mousePositionPx = Mouse.current.position.ReadValue();
        Vector3 mousePositionPoint3d = cam.ScreenToWorldPoint(
            new Vector3(mousePositionPx.x, mousePositionPx.y, 0)
        );
        Vector2 mouseWorld = new Vector2(mousePositionPoint3d.x, mousePositionPoint3d.y);
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        Vector2 aimDirection = (Vector2)mouseWorld - (Vector2)transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject newBullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
            );
            newBullet.GetComponent<BulletMovement>().direction = aimDirection;
        }
    }
}
