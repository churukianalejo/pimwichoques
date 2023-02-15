using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class badmotor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody bmf;
    [SerializeField] private float speedRotation;
    private float acelerationRotation;
    private Vector3 aceleration;
    [SerializeField] private Vector3 axis;
    [SerializeField] private float turboDelay;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;
    void Start()
    {
    }
    void Update()
    {
        MovementCharacter();
        Turbo();
        Turbotimer();
        Nootnoot();
        if (transform.position.y < -15)
        {
            Debug.Log("perdiste");
        }
        //float dir = Input.GetAxis("Vertical");
        //gameObject.transform.position += Vector3.right*(dir * speed * Time.deltaTime);
        //aceleration = gameObject.transform.position.x*dir*speed;
        //bmf.AddForce(new Vector3(aceleration,0,0)*Time.deltaTime,ForceMode.Acceleration);
    }
    private void MovementCharacter()
    {
        float dir = Input.GetAxis("Vertical");
        float speedrotation = Input.GetAxis("Horizontal");
        acelerationRotation = Mathf.Lerp(0,speedRotation*speedrotation,0.6f);
        transform.Rotate(axis, acelerationRotation*Time.deltaTime);

        aceleration = transform.forward * dir * speed;
        bmf.AddForce(aceleration, ForceMode.Acceleration);
    }
    private void efectosdesonido(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
        source.loop= false;
    }
    private void Turbotimer()
    {
        turboDelay -= Time.deltaTime;
    }
    private void Turbo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (turboDelay <= 0)
            {
                Debug.Log("turbo activado");
                efectosdesonido(sound1);
                bmf.AddForce(aceleration * 10, ForceMode.Impulse);
                turboDelay= 5;
            }
        }
    }
    private void Nootnoot()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            efectosdesonido(sound2);
        }
    }
}
