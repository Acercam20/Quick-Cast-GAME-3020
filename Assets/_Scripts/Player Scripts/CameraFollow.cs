using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

    private void Start()
    {
        mapBounds = GameObject.FindWithTag("BG").GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.x;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    void Update()
    {
        camY = Mathf.Clamp(player.transform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(player.transform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        Debug.Log(camY);
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        //gameObject.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
