using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // Fields
    // Window
    public GameObject window;
    // Indicator
    public GameObject indicator;
    // Selection
    public GameObject selection;
    // Text component
    public TMP_Text dialogueText;
    // Dialogue list
    public List<string> dialogues;
    // Writing speed
    public float writingSpeed;
    // Index on dialogue
    private int index;
    // Character index
    private int charIndex;
    // Started boolean
    private bool started;
    // Wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }


    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    // Start Dialogue
    public void StartDialogue()
    {
        if (started)
            return;

        // Boolean to indicate that we have started
        started = true;
        // Show the window
        ToggleWindow(true);
        // Hide the indicator
        ToggleIndicator(false);
        // Start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        // Start index at zero
        index = i;
        // Reset the character index
        charIndex = 0;
        // Clear the dialogue component text
        dialogueText.text = string.Empty;
        // Start writing
        StartCoroutine(Writing());
    }

    // End Dialogue
    public void EndDialogue()
    {
        // Hide the window
        ToggleWindow(false);
    }
    // Writing logic
    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
        // Write the character
        dialogueText.text += currentDialogue[charIndex];
        // Increase the character index
        charIndex++;
        // Make sure you have reached the end of the sentence
        if(charIndex < currentDialogue.Length)
        {
            // Wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            // Restart the same process
            StartCoroutine(Writing());
        }
        else
        {
            // End this sentence and wait for the next one
            waitForNext = true;
        }
    }

    private void Update()
    {
        if (!started)
            return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            if (index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                EndDialogue();
            }
        }
    }
}
