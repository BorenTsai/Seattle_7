using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour {

    public UnityEngine.UI.Text MessageBox;
    public UnityEngine.UI.Text HealthBox;
    private int health = 100;
    public float m_StartingHealth = 100;
    public Color m_FullHealthColor;
    public Color m_ZeroHealthColor;

    private AudioSource speaker;
    public AudioClip cheer_clip; 
    public AudioClip dying_clip;

    public void Start()
    {
        m_FullHealthColor = Color.green;
        m_ZeroHealthColor = Color.red;
    }

    public void win()
    {
        HealthBox.text = string.Empty;
        MessageBox.text = "You Win!";
        speaker= gameObject.GetComponent<AudioSource>();
        speaker.PlayOneShot(cheer_clip);
    }

    public void damage()
    {
        health -= 10;
        HealthBox.text = health.ToString();
        if (health <= 0) {
            death();
        }
    }

    public void death()
    {
        health = 0;
        HealthBox.text = "You have died. You have let down the human race. Gods win.";
        speaker.PlayOneShot(dying_clip);
    }

    public void hit()
    {
        MessageBox.text = "Good Hit!";
        damage();
    }

    public void wrong()
    {
        MessageBox.text = "Wrong Weapon";
    }

}
