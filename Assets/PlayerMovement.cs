using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update()
    {
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
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
