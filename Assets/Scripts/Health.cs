using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Mathew McGerty
public class Health : MonoBehaviour {

    public float health = 100;
    public Text text;
    public float multiplier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        health -= Time.deltaTime * multiplier;
        text.text = "Health:" + Mathf.Round(health);
        if (health <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
	}

}
