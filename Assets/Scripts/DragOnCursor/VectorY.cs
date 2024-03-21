using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorY : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject objectToMove;
    [SerializeField] GameObject objectvector;
    [SerializeField] GameObject arrow1;
    [SerializeField] GameObject arrow2;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        objectToMove = gameObject; // El objeto que se moverá
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        objectToMove.transform.position = new Vector3(objectToMove.transform.position.x, curPosition.y, objectToMove.transform.position.z);
        objectvector.transform.position = objectToMove.transform.position;
        float y = objectToMove.transform.position.y;
        arrow1.transform.position = new Vector3(arrow1.transform.position.x, curPosition.y, arrow1.transform.position.z);
        arrow2.transform.position = new Vector3(arrow2.transform.position.x, curPosition.y, arrow2.transform.position.z);
    }
}
