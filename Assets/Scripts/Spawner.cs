using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject previewPrefab;
    private GameObject currentPreview;

    // Start is called before the first frame update
    void Start()
    {
        currentPreview = Instantiate(previewPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch), OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            currentPreview.transform.position = hit.point;
            currentPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Instantiate(prefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }
}
