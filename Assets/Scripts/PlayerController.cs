using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(
                ((Vector2.up * verticalInput) * movementSpeed) * Time.deltaTime
            );
        gameObject.transform.Rotate(
                ((new Vector3(0,0,1f) * horizontalInput) * -rotationSpeed) * Time.deltaTime
            );
    }
}
