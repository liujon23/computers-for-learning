using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    public Camera mainCamera;

    private void Update() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            transform.position = raycastHit.point;
            //Debug.Log(raycastHit.point);

            if (Input.GetMouseButtonDown(0)) {
                GameObject currObj = raycastHit.transform.gameObject;

                if (currObj == null) {
                    return;
                }
                //tags are easier to deal w than names so i've been adding tags
                //to our game objects
                else if (currObj.tag == "Construction") {
                    Debug.Log("TIME TO BUILD!"); //this works, other stuff doesnt
                    StationBehavior sb = currObj.GetComponent<StationBehavior>();
                    sb.toggleStation(1);
                    //currObj.toggleStation(1);
                }
                else if (currObj.tag == "JunctionStation") {
                    StationBehavior sb = currObj.GetComponent<StationBehavior>();
                    sb.toggleStation(2);
                }
                else if (currObj.tag == "Train") {
                    Debug.Log("Choo choo!");
                }

            }

        }
    }
}
