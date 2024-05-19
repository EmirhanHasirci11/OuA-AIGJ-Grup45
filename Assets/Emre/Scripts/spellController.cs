using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellController : MonoBehaviour
{
    public GameObject spellPrefab;
    public GameObject spellPrefab2;
    public GameObject spellPrefab3;
    public GameObject portalPrefab;
    public Transform spellSpawnPoint;
    public Transform portalSpawnPoint;

    public float spellCooldown = 8f;
    public float spellCooldown2 = 10f;
    public float spellCooldown3 = 15f;
    public float portalCooldown = 20f;

    private bool canCastSpell = true;
    private bool canCastSpell2 = true;
    private bool canCastSpell3 = true;
    private bool canCastPortal = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCastSpell)
        {
            CastSpell();
            canCastSpell = false;
            Invoke("ResetSpellCooldown", spellCooldown);
        }
        if (Input.GetKeyDown(KeyCode.Q) && canCastSpell2)
        {
            CastSpell2();
            canCastSpell2 = false;
            Invoke("ResetSpellCooldown2", spellCooldown2);
        }
        if (Input.GetKeyDown(KeyCode.R) && canCastSpell3)
        {
            CastSpell3();
            canCastSpell3 = false;
            Invoke("ResetSpellCooldown3", spellCooldown3);
        }

        if (Input.GetKeyDown(KeyCode.P) && canCastPortal)
        {
            GameObject portalInstance = CastPortal();
            canCastPortal = false;
            Invoke("ResetPortalCooldown", portalCooldown);
            Destroy(portalInstance, 10);
        }
    }

    GameObject CastPortal()
    {
        if (portalPrefab != null && portalSpawnPoint != null)
        {
            GameObject portalInstance = Instantiate(portalPrefab, portalSpawnPoint.position, portalSpawnPoint.rotation);
            return portalInstance;
        }
        return null;
    }

    void CastSpell()
    {
        if (spellPrefab != null && spellSpawnPoint != null) 
        { 
            Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
        }
    }

    void CastSpell2()
    {
        if (spellPrefab2 != null && spellSpawnPoint != null)
        {
            Instantiate(spellPrefab2, spellSpawnPoint.position, spellSpawnPoint.rotation);
        }
    }

    void CastSpell3()
    {
        if (spellPrefab3 != null && spellSpawnPoint != null)
        {
            Instantiate(spellPrefab3, spellSpawnPoint.position, spellSpawnPoint.rotation);
        }
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
