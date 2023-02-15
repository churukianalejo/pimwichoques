using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public float speed;
    [SerializeField] private float speedrotation = 2;
    void Start()
    {
        
    }

    void Update()
    {
        
        stalkPlayer();
        mirarObjetivo();
    }

    private void stalkPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += speed * direction * Time.deltaTime; 
    }
    private void mirarObjetivo()
    {
        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedrotation * Time.deltaTime);
    }
}
