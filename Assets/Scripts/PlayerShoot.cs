using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private LaserGun _weapon;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _weapon.Activate();
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                _weapon.Deactivate();
            }
        }
    }
}
