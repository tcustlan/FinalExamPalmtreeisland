using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Transform player; // ���a�� Transform ����

    private void Update()
    {
        // ������a�� Y �b��ʭ�
        float rotationY = player.rotation.eulerAngles.y;
        Debug.Log(rotationY);
        string directionString = ""; // �Ыؤ@�Ӧr��Ӧs�x��V

        if (rotationY > 45 && rotationY <= 135)
        {
            directionString = "East";
        }
        else if (rotationY > 135 && rotationY <= 225)
        {
            directionString = "South";
        }
        else if (rotationY > 225 && rotationY <= 315)
        {
            directionString = "West";
        }
        else
        {
            directionString = "North";
        }
        
        // ��s���Y��ܦr������r
        GetComponentInChildren<Text>().text = "Direction �� " + directionString;

        // ��s��V���ܾ�������
        GetComponentInChildren<Image>().transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
