using UnityEngine;
using System.Collections;

public class UR5eController : MonoBehaviour {

    public GameObject RobotBase;
    public float[] jointValues = new float[6];
    private GameObject[] jointList = new GameObject[6];
    private float[] upperLimit = { 360f, 360f, 360f, 360f, 360f, 360f };
    private float[] lowerLimit = { -360f, -360f, -360f, -360f, -360f, -360f };

    // Use this for initialization
    void Start () {
        initializeJoints();
	    
	}
	
	// Update is called once per frame
	void LateUpdate () {
        for ( int i = 0; i < 6; i ++) {
            Vector3 currentRotation = jointList[i].transform.localEulerAngles;
            Debug.Log(currentRotation);
            if (i == 0 || i == 4) {
                currentRotation.y = jointValues[i];
                jointList[i].transform.localEulerAngles = currentRotation;
            }
            else {
                currentRotation.x = jointValues[i];
                jointList[i].transform.localEulerAngles = currentRotation;                
            }
        }
	}

    void OnGUI() {
        int boundary = 20;

#if UNITY_EDITOR
        int labelHeight = 20;
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 20;
#else
        int labelHeight = 40;
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 40;
#endif
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        for (int i = 0; i < 6; i++) {
            GUI.Label(new Rect(boundary, boundary + ( i * 2 + 1 ) * labelHeight, labelHeight * 4, labelHeight), "Joint " + i + ": ");
            jointValues[i] = GUI.HorizontalSlider(new Rect(boundary + labelHeight * 4, boundary + (i * 2 + 1) * labelHeight + labelHeight / 4, labelHeight * 5, labelHeight), jointValues[i], lowerLimit[i], upperLimit[i]);
        }
    }


    // Create the list of GameObjects that represent each joint of the robot
    void initializeJoints() {
        var RobotChildren = RobotBase.GetComponentsInChildren<Transform>();
        for (int i = 0; i < RobotChildren.Length; i++) {
            if (RobotChildren[i].name == "ur5e_shoulder_link") {
                jointList[0] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "ur5e_upper_arm_link") {
                jointList[1] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "ur5e_forearm_link") {
                jointList[2] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "ur5e_wrist_1_link") {
                jointList[3] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "ur5e_wrist_2_link") {
                jointList[4] = RobotChildren[i].gameObject;
            }
            else if (RobotChildren[i].name == "ur5e_wrist_3_link") {
                jointList[5] = RobotChildren[i].gameObject;
            }
        }
    }
}
