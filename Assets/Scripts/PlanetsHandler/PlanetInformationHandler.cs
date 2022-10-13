using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetInformationHandler : MonoBehaviour
{
    [Tooltip("This is the object that the script's game object will show the information based on the player clicking on a gameObject")]
    [SerializeField] private GameObject planetTextGameObject;

    [Tooltip("The float property to give the length of the ray to hit the object")]
    [SerializeField] private float rayLength;

    [SerializeField] private LayerMask layerMask;

    // To store & cehck current gameObject is active or not from hierarchy.
    private GameObject storeGameObject;

    private void Start()
    {
        storeGameObject = planetTextGameObject;
    }

    private void Update()
    {
        ChooseOnePlanet();
    }

    public void ChooseOnePlanet()
    { 
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && storeGameObject.activeInHierarchy == false)
        {
            RaycastHit hit;

            // determine the ray from the camera to the mousePosition
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                storeGameObject.SetActive(true);
            }
        } else if (Input.GetMouseButtonDown(0) && storeGameObject.activeInHierarchy == true)
        {
            storeGameObject.SetActive(false);
        }
    }
}
