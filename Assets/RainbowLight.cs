using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowLight : MonoBehaviour
{
    public Light rainbowLight; // 你的光源
    public float switchInterval = 0.1f; // 切換間隔

    private float timer; // 計時器
    private int colorIndex; // 彩虹顏色的索引
    private Color[] rainbowColors; // 彩虹顏色數組
    private bool isSwitching; // 開關是否開啟

    private Color defaultColor = new Color(1f, 0.96f, 0.84f); // FFF4D6 的顏色

    private void Start()
    {
        // 初始化彩虹顏色
        rainbowColors = new Color[] {
            Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta
        };

        // 初始化計時器和顏色索引
        timer = 0f;
        colorIndex = 0;
        isSwitching = false;
    }

    private void Update()
    {
        // 檢查開關狀態
        if (Input.GetKeyDown(KeyCode.L))
        {
            isSwitching = true;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            isSwitching = false;
            SetDefaultColor();
        }

        // 如果開關開啟，則更新計時器並切換顏色
        if (isSwitching)
        {
            timer += Time.deltaTime;

            // 如果計時器超過切換間隔，切換顏色並重置計時器
            if (timer >= switchInterval)
            {
                SwitchColor();
                timer = 0f;
            }
        }
    }

    private void SwitchColor()
    {
        // 更改光源顏色
        rainbowLight.color = rainbowColors[colorIndex];

        // 增加顏色索引，如果超出範圍，重置為零
        colorIndex = (colorIndex + 1) % rainbowColors.Length;
    }

    private void SetDefaultColor()
    {
        // 設定光源顏色為預設顏色
        rainbowLight.color = defaultColor;
    }
}
