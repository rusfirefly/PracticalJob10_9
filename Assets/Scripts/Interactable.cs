using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Text _iteractableText;
    [SerializeField] private string _message = "Press E";

    public virtual void OnInteract()
    {
        _iteractableText.text = _message;
    }


    public void ShowMessage()
    {
        SetVisibleText(true);
    }

    public void HideMessage()
    {
        SetVisibleText(false);
    }

    private void SetVisibleText(bool visible)=> _iteractableText.gameObject.SetActive(visible);
}
