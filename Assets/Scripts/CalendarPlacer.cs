using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarPlacer : MonoBehaviour
{
    public GameObject calendarPrefab;
    public Transform placementIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if ( placementIndicator != null)
            {
                placementIndicator.position = hit.point;
                placementIndicator.rotation = Quaternion.LookRotation(hit.normal);
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                PlaceCalendar(hit.point, hit.normal);
            }
        }
    }

    void PlaceCalendar(Vector3 position, Vector3 normal)
    {
        GameObject calendar = Instantiate(calendarPrefab, position, Quaternion.LookRotation(normal));
    }
}
