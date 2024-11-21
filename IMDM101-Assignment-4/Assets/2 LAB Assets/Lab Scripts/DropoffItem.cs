using UnityEngine;

public class DropoffItem : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        this.gameObject.SetActive(false);

        switch (this.gameObject.tag)
        {
            case "Red":
                FirstPersonMovement.hasRed = false;
                FirstPersonMovement.usedRed = true;
                Progress.red2 = true;
                Progress.redStatus = false;
                break;
            case "Pink":
                FirstPersonMovement.hasPink = false;
                FirstPersonMovement.usedPink = true;
                Progress.pink2 = true;
                Progress.pinkStatus = false;
                break;
            case "Blue":
                FirstPersonMovement.hasBlue = false;
                FirstPersonMovement.usedBlue = true;
                Progress.blue2 = true;
                Progress.blueStatus = false;
                break;
        }

    }

    public string GetClass()
    {
        return "dropoff";
    }

    public bool CanUseElement()
    {
        switch (this.gameObject.tag)
        {
            case "Red":
                return FirstPersonMovement.hasRed;
            case "Pink":
                return FirstPersonMovement.hasPink;
            case "Blue":
                return FirstPersonMovement.hasBlue;
            default:
                return false;
        }
    }
}
