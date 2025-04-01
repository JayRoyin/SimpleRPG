using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoonSpeed;

    private Vector3 offset;
    private Transform playertrans;

    // Start is called before the first frame update
    void Start()
    {
        zoonSpeed = 5;
        playertrans = GameObject.FindGameObjectsWithTag(Tag.PLAYER).Length > 0 ? GameObject.FindGameObjectsWithTag(Tag.PLAYER)[0].transform : null;
        offset = transform.position - playertrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playertrans.position + offset;

        //Debug.Log(UnityEngine.Input.GetAxis("Mouse ScrollWheel"));
        float scrol = UnityEngine.Input.GetAxis("Mouse ScrollWheel");
        
        //Camera.main.fieldOfView += scrol*zoonSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView += scrol * zoonSpeed, 40f, 70f);
    }
}
