using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;

    private float _gravity = -9.81f;
    private Vector3 _velocity;

    [SerializeField] private Transform _grountCheck;
    [SerializeField] private LayerMask _groundMask;
    private float _jumpHeight = 3f;
    private float _groundDistance = 0.4f;
    private bool _isGround;

    private bool _isPressButtonE;
    private Interactable _interactableObject;

    private void FixedUpdate()
    {
        if (_interactableObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactableObject.OnInteract();
            }
            
        }

        _isGround = Physics.CheckSphere(_grountCheck.position, _groundDistance, _groundMask);

        if(_isGround && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -1f * _gravity);
        }

        Move(x, z);
        Gravity();
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckInteracteble(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        CheckInteracteble(other, false);
        _interactableObject = null;
    }

    private void CheckInteracteble(Collider collider, bool show)
    {
       Interactable interactable = collider.GetComponent<Interactable>();
        _interactableObject = interactable;
       if(interactable)
       {
            if (show)
            {
                interactable.ShowMessage();
            }
            else
                interactable.HideMessage();
       }
    }

    private void Move(float x, float z)
    {
        Vector3 move = (transform.right * x + transform.forward * z) * _speed;
        _controller.Move(move * Time.deltaTime);
    }

    private void Gravity()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime * 2f);
    }
}
