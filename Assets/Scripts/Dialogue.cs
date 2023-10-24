using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public Image chatBubble;
    public TextMeshProUGUI chat;
    public string defaultText;
    public int maxCharacters;
    public int dialogueSize;

    private string[] wordsInText;
    private int currentWordIndex;
    // Start is called before the first frame update
    void Start()
    {
        chat.text = defaultText;
        setText("This is a test. I am making this long message to see if this dialogue works. Please do. Thank you.");
    }

    // Update is called once per frame
    void Update()
    {
        bool interacted = PlayerInput.instance.GetInteractPressed();
        Debug.Log($"DIALOGUE: interacted = {interacted}");
        if (interacted)
        {
            chat.fontSize = dialogueSize;
            int accumulatedCharacters = 0;

            for (int i = currentWordIndex; i < wordsInText.Length; ++i)
            {
                string word = wordsInText[i];
                accumulatedCharacters += word.Length;
                if (accumulatedCharacters > maxCharacters)
                {
                    chat.text = string.Join(" ", wordsInText[currentWordIndex..i]);
                    currentWordIndex = i;
                }
            }
        }
    }

    public void setText(string dialogue)
    {
        wordsInText = dialogue.Split();
        currentWordIndex = 0;
    }
}
