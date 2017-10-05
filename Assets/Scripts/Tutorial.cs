using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Dig 3 Yellow Blocks to Win" +
                    "\nAD To Move" +
                    "\nSpace to Jump" +
                    "\nLeft Click To Dig Terrain" +
                    "\nRight Click to Place Available Tiles" +
                    "\nBlue=Health+" +
                    "\nRed=Health-" +
                    "\nPurple=Available Tiles" +
                    "\nHealth in Other Levels" +
                    "\nIf Health Reaches 0 you Lose";
                    
	}
}
