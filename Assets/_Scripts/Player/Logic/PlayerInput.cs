using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private RollCoolDown rollCooldown;
    private HealthSystem healthSystem;
    public GameObject inventoryPanel;
    private KeyCode lastKey;
    public Vector2 movementInput { get; private set; }
    public KeyCode key { get; private set; }
    public bool inventoryIsOpen;
    public bool isRolling;
    public float movementX;
    public float movementY;

    private void Update()
    {
        InputProcessing();
    }
    private void Awake()
    {
        rollCooldown = GetComponent<RollCoolDown>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void InputProcessing()
    {
        if(Input.GetKey(KeyCode.U)) SceneManager.LoadScene("Deck");
        #region Movement
        movementX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        movementY = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        movementInput = new Vector2(movementX, movementY).normalized;
        #endregion

        #region KeyInput
        // Checks what the player's last directional key was and sets Roll respectively
        if (Input.GetKey(KeyCode.W)) lastKey = KeyCode.W;

        else if (Input.GetKey(KeyCode.S)) lastKey = KeyCode.S;

        else if (Input.GetKey(KeyCode.A)) lastKey = KeyCode.A;

        else if (Input.GetKey(KeyCode.D)) lastKey = KeyCode.D;

        key = lastKey;
        #endregion

        #region Roll
        if (Input.GetKeyDown(KeyCode.LeftShift) && !rollCooldown.onCooldown)
        {
            isRolling = true;
            rollCooldown.SetCooldown();
        }
        else
        {
            isRolling = false;
        }
        #endregion

        #region Inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventoryIsOpen)
            {
                Debug.Log("opening");
                OpenInventory();
            }
            else if (inventoryIsOpen)
            {
                Debug.Log("closing");
                CloseInventory();
            }
        }
        #endregion

        #region Test
        if(Input.GetKeyDown(KeyCode.K))
        {
            healthSystem.AddHealth(10f);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            healthSystem.RemoveHealth(10f);
        }
        #endregion
    }
    public void OpenInventory()
    {
        inventoryIsOpen = true;
        inventoryPanel.SetActive(true);
    }
    public void CloseInventory()
    {
        inventoryIsOpen = false;
        inventoryPanel.SetActive(false);
    }
}
