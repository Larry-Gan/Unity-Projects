using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;

    private int count;

    private float mvtX;
    private float mvtY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue mvtValue)
    {
        Vector2 mvtVector = mvtValue.Get<Vector2>();

        mvtX = mvtVector.x;
        mvtY = mvtVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 mvt = new Vector3(mvtX, 0.0f, mvtY);

        rb.AddForce(mvt * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
    }
}
