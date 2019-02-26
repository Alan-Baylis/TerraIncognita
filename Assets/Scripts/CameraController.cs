using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public enum AxisRotation {
        mouseX = 1,
        mouseY = 2
    }

    public AxisRotation axes = AxisRotation.mouseX;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    public float sHorizontal = 10.0f;
    public float sVertical = 10.0f;

    public float _rotationX = 0;

    void Update() {
        if (axes == AxisRotation.mouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sHorizontal, 0);

        }
        else if (axes == AxisRotation.mouseY) {
            _rotationX -= Input.GetAxis("Mouse Y") * sVertical;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);


            float _rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
    }