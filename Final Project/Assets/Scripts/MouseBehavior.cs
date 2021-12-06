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
                else if (currObj.tag == "Construction") {
                    // toggle station
                    Debug.Log("TIME TO BUILD!");
                }
                else if (currObj.tag == "Train") {
                    Debug.Log("Choo choo!");
                }

            }

        }
    }
}
