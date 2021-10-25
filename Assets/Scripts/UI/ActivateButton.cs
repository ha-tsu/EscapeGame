using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    [SerializeField] GameObject toActive;
    [SerializeField] GameObject disActive;

    public void OnClick()
    {
        if (this.toActive != null)
        {
            this.toActive.SetActive(true);
        }
        if (this.disActive != null)
        {
            this.disActive.SetActive(false);
        }
    }
}