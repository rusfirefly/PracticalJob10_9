using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _mouseSensitivity;

    private float _xRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation,-90, 45);

        _camera.transform.localEulerAngles = new Vector3(_xRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

   

}
