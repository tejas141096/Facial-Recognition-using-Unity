using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Watson.DeveloperCloud.Services.VisualRecognition.v3;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.Connection;

public class FaceDetecter : MonoBehaviour {

    public Text dataOutput;

    private VisualRecognition _visualRecognition;

	// Use this for initialization
	void Start () {
        Credentials credentials = new Credentials("/*api access token*/", "https://gateway.watsonplatform.net/visual-recognition/api");
        _visualRecognition = new VisualRecognition(credentials);
        _visualRecognition.VersionDate = "2016-05-20";
	}

    public void DetectFaces(string path)
    {
        //  Classify using image url
        // if(!_visualRecognition.DetectFaces("https://pbs.twimg.com/profile_images/802344884690677760/xYxHgWd2_400x400.jpg", OnDetectFaces, OnFail))
        //    Debug.Log("ExampleVisualRecognition.DetectFaces(), Detect faces failed!");

        //  Classify using image path
        if (!_visualRecognition.DetectFaces(OnDetectFaces, OnFail, path))
        {
            Debug.Log("ExampleVisualRecognition.DetectFaces(),Detect faces failed!");
        }
        else
        {
            Debug.Log("Calling Watson");
            dataOutput.text = "";
        }
    }

    private void OnDetectFaces(DetectedFaces multipleImages, Dictionary<string, object> customData)
    {
        var data = multipleImages.images[0].faces[0];
        dataOutput.text = "Age: " + data.age.min + "-" + data.age.max + "\tProbability: " + data.age.score + "\n" + "Gender: " + data.gender.gender + "\tProbability: " + data.gender.score;
        Debug.Log(dataOutput.text);
        Debug.Log("ExampleVisualRecognition.OnDetectFaces(),Detect faces result: {0}");
        Debug.Log(customData["json"].ToString());
    }

    private void OnFail(RESTConnector.Error error, Dictionary<string, object> customData)
    {
        Debug.LogError("ExampleVisualRecognition.OnFail(), Error received: {0}");
        Debug.Log(error.ToString());
    }
}
