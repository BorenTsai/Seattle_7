using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public weaponManager weaponManager;

    private void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.CompareTag("Blue") || obj.gameObject.CompareTag("Red") || obj.gameObject.CompareTag("Green"))
        {
            Debug.Log("Decrease Health");
            weaponManager.damage();
            Destroy(obj.gameObject);
        }
    }
}
