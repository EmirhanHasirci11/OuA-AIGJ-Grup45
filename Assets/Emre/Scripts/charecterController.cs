using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1f;
    public float runSpeed = 2f;
    public float jumpSpeed = 5f;
    private bool isGround = true;
    private bool wary = false;
    Rigidbody rb;

    public float spellCooldown = 8f;
    public float spellCooldown2 = 10f;
    public float spellCooldown3 = 15f;
    public float portalCooldown = 20f;

    private bool canCastSpell = true;
    private bool canCastSpell2 = true;
    private bool canCastSpell3 = true;
    private bool canCastPortal = true;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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
        {
            animator.SetFloat("speed", 0);
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
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            isGround = false;

        }
        else
        {
            
            animator.SetBool("jump", false);
            isGround = true;
            
        }
        // zaman manipülasyonu
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P))
        {
            if (Input.GetKeyDown(KeyCode.E) && canCastSpell)
            {
                animator.SetTrigger("spell");
                canCastSpell = false;
                Invoke("ResetSpellCooldown", spellCooldown);

            }
            else if (Input.GetKeyDown(KeyCode.Q) && canCastSpell2)
            {
                animator.SetTrigger("spell");
                canCastSpell2 = false;
                Invoke("ResetSpellCooldown2", spellCooldown2);
            }
            else if (Input.GetKeyDown(KeyCode.R) && canCastSpell3)
            {
                animator.SetTrigger("spell");
                canCastSpell3 = false;
                Invoke("ResetSpellCooldown3", spellCooldown3);
            }
            else if (Input.GetKeyDown(KeyCode.P) && canCastPortal)
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
        {
            animator.SetFloat("runSpeed", 0);
        }


        // Hareket vektörü
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);
        //isGround = Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    void ResetSpellCooldown()
    {
        canCastSpell = true;
    }
    void ResetSpellCooldown2()
    {
        canCastSpell2 = true;
    }
    void ResetSpellCooldown3()
    {
        canCastSpell3 = true;
    }
    void ResetPortalCooldown()
    {
        canCastPortal = true;
    }
}

