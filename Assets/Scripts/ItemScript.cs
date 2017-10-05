using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Mathew McGerty
public class ItemScript : MonoBehaviour {

    public Text ItemText;

    int [] counts = new int[7];

    public GameObject platform;
    bool placeable = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        ItemText.text = 
                         "Yellow: " + counts[0] +
                         "\nPurple: " + counts[1];
        

        if (counts[0] == 3) //Victory Condition
        {
            SceneManager.LoadScene("Win");
        }

        if (counts[1] > 0)
        {
            placeable = true;
        }

        if (counts[1] == 0)
        {
        placeable = false;
        }
    

    if (Input.GetMouseButtonDown(1) && placeable == true)
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 PlacePos = new Vector3(Mathf.Round(MousePos.x), Mathf.Round(MousePos.y), 0f);

        if (Physics2D.OverlapCircleAll(PlacePos, 0.25f).Length == 0)
        {
            GameObject newPlatform = Instantiate(platform, PlacePos, Quaternion.identity) as GameObject;
            counts[1]--;
        }
    }
	
}
    public void add(int itemType, int count)
{
    counts[itemType] += count;
}

    public void delete(int itemType, int count)
    {
        counts[itemType] -= count;
    }


    
}
