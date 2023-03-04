using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speed = 10f; // 飞行速度
    public float rollSpeed = 50f; // 滚转速度
    public float pitchSpeed = 50f; // 俯仰速度
    public float yawSpeed = 50f; // 偏航速度

    private Quaternion targetRotation; // 目标旋转
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // 获取用户输入
        float roll = Input.GetAxis("Horizontal");
        float pitch = Input.GetAxis("Vertical");

        // 计算目标旋转
        Quaternion rollRotation = Quaternion.AngleAxis(roll * rollSpeed * Time.deltaTime, Vector3.back);
        Quaternion pitchRotation = Quaternion.AngleAxis(-pitch * pitchSpeed * Time.deltaTime, Vector3.right);
        targetRotation *= rollRotation * pitchRotation;

        // 平滑旋转
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);

        // 根据当前方向移动
        Vector3 velocity = transform.forward * speed;
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }
}