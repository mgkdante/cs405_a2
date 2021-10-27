using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float health;
    public Slider slider;
    public Text text;
    public AudioSource damage;

    private void Start()
    {
        health = 100;
    }

    void Update()
    {
        slider.value = health;
        text.text = "Health: " + health;
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Hand")
        {
            health -= 1f;
            damage.Play();
        }
        if (obj.gameObject.tag == "Leg")
        {
            health -= 1f;
            damage.Play();
        }
    }
}