using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        this.gameObject.SetActive(false);

        switch (this.gameObject.tag)
        {
            case "Red":
                FirstPersonMovement.hasRed = true;
                Progress.redStatus = true;
                break;
            case "Pink":
                FirstPersonMovement.hasPink = true;
                Progress.pinkStatus = true;
                break;
            case "Blue":
                FirstPersonMovement.hasBlue = true; 
                Progress.blueStatus = true;
                break;
        }

    }

    public string GetClass()
    {
        return "pickup";
    }

    public bool CanUseElement()
    {
        return false;
    }
}
