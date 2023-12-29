using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 人物的Transform组件
    public float smoothSpeed = 0.125f;  // 相机移动的平滑速度
    public Vector3 offset = new Vector3(0, 12, -8);  // 相机相对于人物的偏移量

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;  // 考虑偏移
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);  // 使相机朝向人物

        // 获取人物的旋转并应用到相机上，实现画面跟随角色转动
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
    }
}