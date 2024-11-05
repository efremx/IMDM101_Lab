using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

interface IInteractable
{
    public void Interact();
    public string GetClass();
    public bool CanUseElement();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public GameObject PickupText, DropoffText;
    public AudioSource Source;
    public AudioClip pickup, dropoff, alarm;
    int count;
    float switchTimer;
    public bool done;

    void Awake()
    {
        PickupText.SetActive(false);
        DropoffText.SetActive(false);
        Source = GetComponent<AudioSource>();
        count = 0;
        switchTimer = 0;
        done = false;
    }

    void Update()
    {
        if (done)
        {
            switchTimer += Time.deltaTime;
            if(switchTimer > 3.0f)
            {
                SceneManager.LoadScene("Cutscene");
                Debug.Log("change the scene");
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    switch (interactObj.GetClass())
                    {
                        case "pickup":
                            interactObj.Interact();
                            Source.clip = pickup;
                            Source.Play();
                            break;
                        case "dropoff":
                            if (interactObj.CanUseElement())
                            {
                                interactObj.Interact();
                                count++;
                                Source.clip = dropoff;  
                                Source.Play();
                                if(count == 3)
                                {
                                    done = true;
                                    Source.clip = alarm;
                                    Source.Play();
                                    FirstPersonMovement.finished = true;
                                }
                            }
                            break;
                    }
                    
                }
            }
        }
        else
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    switch (interactObj.GetClass()) {
                        case "pickup":
                            PickupText.SetActive(true);
                            break;
                        case "dropoff":
                            if (interactObj.CanUseElement())
                            {
                                DropoffText.SetActive(true);
                            }
                            break;
                    }

                }
                else
                {
                    if (PickupText.activeSelf)
                    {
                        PickupText.SetActive(false);
                    }
                    if (DropoffText.activeSelf) 
                    {  
                        DropoffText.SetActive(false); 
                    }
                }
            }
        }
    }

    //public void Alarm()
    //{
    //    done = true;
    //    Source.clip = alarm;
    //    Source.Play();
    //}

}
