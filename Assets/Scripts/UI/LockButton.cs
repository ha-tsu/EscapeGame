using UnityEngine;
using UnityEngine.UI;

public class LockButton : Button
{
    private Lock lo;
    [SerializeField] private string targetId;

    public override void Start()
    {
        base.Start();
        if (this.targetId.Equals(""))
        {
            Debug.Log("KeyButton target has not defined");
            return;
        }
        this.lo = (Lock)MysteryManager.GetInstance().SearchIIdentifiable(targetId);
        this.gameObject.GetComponent<Image>().sprite = this.lo.GetImage();
        if (this.lo.GetVisible())
        {
            this.gameObject.SetActive(false);
        }
    }

    public override void OnClick()
    {
        this.lo.Unlock();
    }
}