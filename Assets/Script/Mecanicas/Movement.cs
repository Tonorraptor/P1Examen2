using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    public Camera firstPersonCam;
    public Camera thirdPersonCam;

    private Rigidbody rb;
    private float xRotation = 0f;
    private bool isFirstPerson = true;
    public float mouseSensitivity = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        firstPersonCam.enabled = true;
        thirdPersonCam.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;
            firstPersonCam.enabled = isFirstPerson;
            thirdPersonCam.enabled = !isFirstPerson;
        }


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        if (isFirstPerson)
            firstPersonCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        else
            thirdPersonCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }
}