using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowLight : MonoBehaviour
{
    public Light rainbowLight; // �A������
    public float switchInterval = 0.1f; // �������j

    private float timer; // �p�ɾ�
    private int colorIndex; // �m�i�C�⪺����
    private Color[] rainbowColors; // �m�i�C��Ʋ�
    private bool isSwitching; // �}���O�_�}��

    private Color defaultColor = new Color(1f, 0.96f, 0.84f); // FFF4D6 ���C��

    private void Start()
    {
        // ��l�Ʊm�i�C��
        rainbowColors = new Color[] {
            Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta
        };

        // ��l�ƭp�ɾ��M�C�����
        timer = 0f;
        colorIndex = 0;
        isSwitching = false;
    }

    private void Update()
    {
        // �ˬd�}�����A
        if (Input.GetKeyDown(KeyCode.L))
        {
            isSwitching = true;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            isSwitching = false;
            SetDefaultColor();
        }

        // �p�G�}���}�ҡA�h��s�p�ɾ��ä����C��
        if (isSwitching)
        {
            timer += Time.deltaTime;

            // �p�G�p�ɾ��W�L�������j�A�����C��í��m�p�ɾ�
            if (timer >= switchInterval)
            {
                SwitchColor();
                timer = 0f;
            }
        }
    }

    private void SwitchColor()
    {
        // �������C��
        rainbowLight.color = rainbowColors[colorIndex];

        // �W�[�C����ޡA�p�G�W�X�d��A���m���s
        colorIndex = (colorIndex + 1) % rainbowColors.Length;
    }

    private void SetDefaultColor()
    {
        // �]�w�����C�⬰�w�]�C��
        rainbowLight.color = defaultColor;
    }
}
