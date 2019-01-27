using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroInput : MonoBehaviour
{
    public float speed = 6.0f;
    public GameObject cam;

    private CharacterController _characterController;
    private Animator _animator;
    private AudioSource _audio;
    private SpriteRenderer _spriteRenderer;

    private int _stones;
    private int[] _stoneId;
    private int _stoneIndex;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _stones = 240;
        _stoneId = new[] {3, 1, 2, 4};
        _stoneIndex = 0;
        _audio = GetComponent<AudioSource>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        var movement = Move();
        _characterController.Move(movement);
    }

    private Vector3 Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        if (deltaX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }

        var movement = new Vector3(deltaX, deltaY, 0);
        _animator.SetTrigger(movement == Vector3.zero ? "Stop" : "Walk");
        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        return movement;
    }

    public void AddStone()
    {
        _stones++;
    }

    public bool TakeStone()
    {
        if (_stones < 1)
            return false;
        _stones--;
        return true;
    }

    public bool GiveId(int id)
    {
        if (_stoneId[_stoneIndex] == id)
        {
            _stoneIndex++;
            _audio.Play();
            if (_stoneIndex >= _stoneId.Length)
            {
                _stoneIndex = 0;
            }

            return true;
        }

        cam.GetComponent<ShakeBehavior>().TriggerShake();
        _stoneIndex = 0;

        return false;
    }
}