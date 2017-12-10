using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public Animator anim;
    //private GameController cont;

    // Use this for initialization
    void Awake()
    {
        sentences = new Queue<string>();
        //cont = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (anim.GetBool("isOpen") && Input.GetKeyDown(KeyCode.E)) DisplayNextSentence();
    }

    public void startDialogue(Dialogue dialogue)
    {
        //cont.start = false;
        anim.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void endDialogue()
    {
        //cont.start = true;
        anim.SetBool("isOpen", false);
    }
}
