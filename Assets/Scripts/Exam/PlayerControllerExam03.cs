using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;


    private float horizontalInput;  
    private InputAction moveAction;
    private InputAction shootAction;

    private float autofireTimer;
    

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        
    }

    // Update is called once per frame
   

    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            enableAutoFireMode = !enableAutoFireMode;
        }

        if ( enableAutoFireMode) 
        {
            autofireTimer = autoFireInterval;
            if (autofireTimer > 0f)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                
            }
        }

        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
