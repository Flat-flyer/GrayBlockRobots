using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private InteractArmTriggerObject EndLevelSwitch;
    private int CurScene;
    [SerializeField]
    private int NextScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        CurScene = SceneManager.GetActiveScene().buildIndex;
        NextScene = CurScene + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (EndLevelSwitch.Activated == true)
        {
            SceneManager.LoadScene(NextScene);
        }
        
    }
}
