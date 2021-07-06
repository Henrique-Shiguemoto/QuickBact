using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private float textTimer;
    private float time = 0f;
    private int textPosition = 0;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Text tutorialText;
    private string[] tutorialTexts = {"You need to collect all the <color=#de2626>strawberrys</color> in the map before your time runs out!",
                                      "There are also <color=#d1931f>oranges</color> to increase your speed!",
                                      "But be careful! There are enemies that will come after you! Don't let them touch you!",
                                      "<color=#e06cc9>Pink enemies</color> are <color=#e06cc9>followers</color>, they will follow you if you're close",
                                      "<color=#513478>Purple enemies</color> are <color=#513478>shooters</color>, they will shoot cute creatures at you if you're close",
                                      "Good luck!!",
                                      ""};
    void Start()
    {
        
    }

    void Update()
    {
        time = time + Time.deltaTime;
        if (time >= textTimer)
        {
            time = 0f;
            if (textPosition < tutorialTexts.Length)
            {
                tutorialText.text = tutorialTexts[textPosition];
                textPosition++;
            }
        }
    }
}
