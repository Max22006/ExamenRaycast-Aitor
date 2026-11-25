using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Raycast : MonoBehaviour
{
    private InputAction _clickAction;
    private InputAction _lookAction;

    private Vector2 _mousePosition;

    [SerializeField] private float _timer = 5f;
    
    void Awake()
    {
        _clickAction = InputSystem.actions["Attack"];
        _lookAction = InputSystem.actions["MousePosition"];
    }

    
    void Update()
    {
        if(_clickAction.WasPressedThisFrame())
        {
            //Timer();
            ShotRaycast();   
        }
    }

    void ShotRaycast()
    {
        _mousePosition = _lookAction.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider.name == "Cube1")
            {
                SceneManager.LoadScene("Scene1");
            }

            if(hit.collider.name == "Cube2")
            {
                SceneManager.LoadScene("Scene3");
            }

            if(hit.collider.name == "Sphere")
            {
                SceneManager.LoadScene("Scene2");
            }
            
        }
    }
   /* void Timer()
    {
        _timer -= Time.deltaTime;
    }*/
}
