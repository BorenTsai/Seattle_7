using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public string enemy_tag;
    public weaponManager weapon_manager;
    private AudioSource slash;

    private void Start()
    {
        weapon_manager = GameObject.Find("WeaponManager").GetComponent<weaponManager>();
        slash = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy_tag))
        {
            weapon_manager.hit();
            slash.PlayOneShot(slash.clip);
        }
        else
        {
            weapon_manager.wrong();
        }
    }
}
