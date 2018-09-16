using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour {

    public UnityEngine.UI.Text messagesTextBox;
    public UnityEngine.UI.Text healthTextBox;
    private int health = 100;
    public float m_StartingHealth = 100;
    public Color m_FullHealthColor;
    public Color m_ZeroHealthColor;

    public void Start()
    {
        m_FullHealthColor = Color.green;
        m_ZeroHealthColor = Color.red;
    }

    public void win()
    {
        healthTextBox.text = string.Empty;
        messagesTextBox.text = "You Win!";
    }

    public void damage()
    {
        health -= 10;
        healthTextBox.text = health.ToString();
    }

    public void hit()
    {
        messagesTextBox.text = "Good Hit!";
    }

    public void wrong()
    {
        messagesTextBox.text = "Wrong Weapon";
    }

}
