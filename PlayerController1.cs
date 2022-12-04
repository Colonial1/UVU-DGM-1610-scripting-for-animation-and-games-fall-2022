using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]

    public float moveSpeed;
    public float jumpForce;
    
    public int curHp;
    public int maxHp;

    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;
    
    private Camera camera;
    private Rigidbody rb;
    private Weapon weapon;
    
    void Awake()
    {
      //weapon = GetComponent<Weapon>();
    }
   
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }


    public void TakeDamage(int damage)
    {
        curHp -= damage;
        
        if(curHp <= 0)
            Die();
        
        GameManager.instance.UpdateHealthBar(curHp, maxHp);
    }
    
    void Die()
    {
        GameManager.instance.LoseGame();
        Debug.Log("Player has died! Game Over!");
    }

     public void GiveHealth(int amountToGive)
     {
        //curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
       // GameUI.instance.UpdateHealthBar(curHp, maxHp);
         Debug.Log("Player has been healed!");
     }

     public void GiveAmmo(int amountToGive)
     {
        //weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
       // GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
     }
    
    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    
    
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 dir =transform.right * x + transform.forward *z;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
        //rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CameraLook()
    { 
        float y = Input.GetAxis("Mouse X")* lookSensitivity;
        rotX += Input.GetAxis("Mouse Y")* lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f));
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
  
}
