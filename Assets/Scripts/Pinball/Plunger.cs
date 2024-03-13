using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class Plunger : MonoBehaviour
{
    [SerializeField] SpringJoint _spring;



    private void OnValidate()
    {
        _spring ??= GetComponent<SpringJoint>();
    }

    private void Update()
    {
        
    }
}
