using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_1_Persone : MonoBehaviour
{
    public float Speed;
    private CharacterController _characterController;
    private Camera _camera;
    //public Shooting_Counter points;
    //public Animator animator;
    private float _rotationX = 0;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    
    void Update()
    {
        Vector3 vertical = transform.forward * Input.GetAxis("Vertical") * Speed;
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = vertical;
        Vector3 motion = dir * Time.deltaTime;
        _characterController.Move(motion);
        _rotationX -= horizontal;
        transform.rotation = Quaternion.Euler(0, -_rotationX, 0);






        _camera.transform.LookAt(transform);

    }
}
