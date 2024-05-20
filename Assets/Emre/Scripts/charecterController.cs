using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1f;
    public float runSpeed = 2f;
    public float jumpSpeed = 5f;
    public float rotationSpeed = 100.0f;

    private bool isGround = true;
    private bool wary = false;
    Rigidbody rb;

    public float spellCooldown = 8f;
    public float spellCooldown2 = 15f;
    public float spellCooldown2_1 = 5f; 
    public float portalCooldown = 20f;

    private bool canCastSpell = true;
    private bool canCastSpell2 = true;
    private bool canCastSpell3 = true;
    private bool canCastPortal = true;

    public float slowTimeScale = 0.5f;
    private float defaultTimeScale;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        defaultTimeScale = Time.timeScale;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // yürüme
        if (verticalInput != 0 || horizontalInput != 0)
        {
            animator.SetFloat("speed", 0.5f);
            speed = 1f;
        }
        else
            animator.SetFloat("speed", 0);
        // saða sola dönme
        if (horizontalInput != 0) 
        {
            float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }
        // çömelme
        if (Input.GetKey(KeyCode.C))
        {
            wary = !wary; // Çömelme durumunu tersine çevir
            animator.SetBool("wary", wary);
        }
        // zýplama
        if (verticalInput != 0 && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {

            animator.SetBool("jump", true);
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rb.AddForce(transform.up * 25f, ForceMode.Impulse);
            isGround = false;

        }
        else
        {
            
            animator.SetBool("jump", false);
            isGround = true;
            
        }
        // zaman manipülasyonu
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKeyDown(KeyCode.E) && canCastSpell)
            {
                animator.SetTrigger("spell");
                canCastSpell = false;
                Time.timeScale = slowTimeScale;
                Invoke("ResetSpellCooldown", spellCooldown);

            }
            else if (Input.GetKeyDown(KeyCode.Q) && canCastSpell2)
            {
                animator.SetTrigger("spell");
                canCastSpell2 = false;
                speed = 3f;
                runSpeed = 4f;
                Invoke("ResetSpellCooldown2_1", spellCooldown2_1);
                Invoke("ResetSpellCooldown2", spellCooldown2);
            }
            else if (Input.GetKeyDown(KeyCode.R) && canCastPortal)
            {
                animator.SetTrigger("spell");
                canCastPortal = false;
                Invoke("ResetPortalCooldown", portalCooldown);
            }
        }

        //koþma
        if ((verticalInput != 0 || horizontalInput != 0) && Input.GetKey(KeyCode.LeftShift) && wary == false)
        {
            animator.SetFloat("runSpeed", 0.5f);
            animator.SetFloat("speed", 0);
            speed = runSpeed;
            
        }
        else
            animator.SetFloat("runSpeed", 0);


        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void ResetSpellCooldown()
    {
        canCastSpell = true;
        Time.timeScale = defaultTimeScale;
    }
    void ResetSpellCooldown2()
    {
        canCastSpell2 = true;
    }
    void ResetSpellCooldown2_1()
    {
        speed = 1f;
        runSpeed = 2f;
    }
    void ResetPortalCooldown()
    {
        canCastPortal = true;
    }
}

