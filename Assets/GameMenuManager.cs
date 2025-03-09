using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public Transform head;
    public float distance = 2;
    public GameObject gameMenu;
    public InputActionProperty showButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(showButton.action.WasPressedThisFrame())
        {
            gameMenu.SetActive(!gameMenu.activeSelf);

            gameMenu.transform.position = head.position + new Vector3(head.forward.x, head.forward.z).normalized * distance;
        }

        gameMenu.transform.LookAt(new Vector3(head.forward.x, gameMenu.transform.position.y, head.position.z));
        gameMenu.transform.forward *= -1;   

    }
}
