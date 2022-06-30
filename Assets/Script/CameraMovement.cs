using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    //[SerializeField] private float zoomStep, minCamSize, maxCamSize;
    [SerializeField] SpriteRenderer mapRenderer;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;
    public float zoomOutMin = 1f;
    public float zoomOutMax = 8f;
    private Vector3 dragOrigin;

    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    public void execute()
    {
        PanCamera();
    }

    public void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = camera.ScreenToWorldPoint(Input.mousePosition);
        }

        //if (Input.touchCount == 2)
        //{
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //    float difference = currentMagnitude - prevMagnitude;

        //    zoom(difference * 0.01f);
        //} 
        if (Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - camera.ScreenToWorldPoint(Input.mousePosition);
                camera.transform.position = ClampCamera(camera.transform.position + difference);
                // camera.transform.position += difference;
            }
    }

    //void zoom(float increment)
    //{
    //    camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - increment, zoomOutMin, zoomOutMax);
    //}

    //  zoom in and out with button
    //public void zoomIn()
    //{
    //    float newSize = camera.orthographicSize - zoomStep;
    //    camera.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    //}

    //public void zoomOut()
    //{
    //    float newSize = camera.orthographicSize + zoomStep;
    //    camera.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    //}

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float cameraHeight = camera.orthographicSize;
        float cameraWitdth = camera.orthographicSize * camera.aspect;

        float minX = mapMinX + cameraWitdth;
        float maxX = mapMaxX - cameraWitdth;
        float minY = mapMinY + cameraHeight;
        float maxY = mapMaxY - cameraHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
