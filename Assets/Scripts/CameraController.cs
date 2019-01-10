﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    private bool doMovement = true;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

	void Update ()
    {
        //allows user to lock screen with esc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if(!doMovement)
        {
            return;
        }
		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // allow scroll zooming
        Vector3 pos = transform.position;
        pos.y -= scroll * 750 * scrollSpeed * Time.deltaTime;

        // setting limits on screen movement
        pos.x = Mathf.Clamp(pos.x, -60, 12);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -75, 5);
        transform.position = pos;
    }
}
