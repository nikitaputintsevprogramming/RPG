using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{    
    public PlayerMovement _playerMovement;

    public Camera camera;

    public LayerMask movementMask;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        camera = Camera.main;
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Создаем луч
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.blue);
            // Если луч ударяется 
            if(Physics.Raycast(ray, out hit, 1000f))
            {                    
                Debug.Log(hit.point);
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            // Создаем луч
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            // Если луч ударяется 
            if(Physics.Raycast(ray, out hit, movementMask))
            {         
                // Фокусировка направления игрока
            }
        }
    }
}
