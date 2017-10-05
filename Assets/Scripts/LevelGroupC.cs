using UnityEngine;
using System.Collections;

public class LevelGroupC : MonoBehaviour
{

    public GameObject groups;
    int groupWidth;
    public int groupCount;
    float seed;

    // Use this for initialization
    void Start()
    {
        groupWidth = groups.GetComponent<LevelGenerationC>().width;
        seed = Random.Range(-100000f, 100000f);
        Generation();
    }

    // Update is called once per frame
    public void Generation()
    {
        int lastX = -groupWidth;
        for (int i = 0; i < groupCount; i++)
        {
            GameObject newGroup = Instantiate(groups, new Vector3(lastX + groupWidth, 0f), Quaternion.identity) as GameObject;
            newGroup.GetComponent<LevelGenerationC>().seed = seed;
            lastX += groupWidth;
        }
    }
}
