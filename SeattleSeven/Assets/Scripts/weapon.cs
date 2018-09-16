using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public string enemy_tag;
    public weaponManager weapon_manager;

    private void Start()
    {
        weapon_manager = GameObject.Find("WeaponManager").GetComponent<weaponManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy_tag))
        {
            weapon_manager.hit();
        }
        else
        {
            weapon_manager.wrong();
        }
    }
}
