using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Transform player; // 玩家的 Transform 元件

    private void Update()
    {
        // 獲取玩家的 Y 軸轉動值
        float rotationY = player.rotation.eulerAngles.y;
        Debug.Log(rotationY);
        string directionString = ""; // 創建一個字串來存儲方向

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
        
        // 更新抬頭顯示字幕的文字
        GetComponentInChildren<Text>().text = "Direction → " + directionString;

        // 更新方向指示器的旋轉
        GetComponentInChildren<Image>().transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
