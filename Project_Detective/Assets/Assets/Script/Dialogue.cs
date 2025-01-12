using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the UI text
    public DialogueData dialogueData;    // Reference to the ScriptableObject

    private int index;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect mouse click
        {
            if (textComponent.text == dialogueData.lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueData.lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        if (dialogueData == null) return;

        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueData.lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(dialogueData.textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogueData.lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); // Hide the dialogue box when done
        }
    }
}
