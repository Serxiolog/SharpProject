using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float Sensitivity;
    private CharacterController _characterController;
    private Camera _camera;
    public Transform weapon_transform;
    public Shooting_Counter points;
    public Menu_Choosing menu;

    private float moveHight = 0;
    private float _rotationX = 0;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;



    }

    // Update is called once per frame
    void Update()
    {
        if (points.HP <= 0)
            menu.ExitToMenu();

        Vector3 vertical = transform.forward * Input.GetAxis("Vertical") * Speed;
        Vector3 horizontal = transform.right * Input.GetAxis("Horizontal") * Speed;

        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");

        float groundedPower = _characterController.isGrounded ? 0 : 10;

        moveHight -= groundedPower * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            moveHight = 5;
        }

        Vector3 dir = vertical + horizontal;
        dir.y = moveHight;

        Vector3 motion = dir * Time.deltaTime;

        _characterController.Move(motion);

        _rotationX -= mouseY * Sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -50, 50);

        _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX * Sensitivity, 0);
        weapon_transform.transform.localRotation = Quaternion.Euler(-_rotationX, 180, 0);


    }

}
