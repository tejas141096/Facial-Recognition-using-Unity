using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRender : MonoBehaviour {
    public Image overlay;
    public FaceDetecter fd;

	// Use this for initialization
	void Start () {
        WebCamTexture backCam = new WebCamTexture();
        backCam.Play();
        overlay.material.mainTexture = backCam;
	}

    public void CaptureImage() {
        ScreenCapture.CaptureScreenshot("screenshot.png");
        fd.DetectFaces("D:/Game Developement/Unity/Facial Recognition/screenshot.png");
    }

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            CaptureImage();
        }
	}
}
