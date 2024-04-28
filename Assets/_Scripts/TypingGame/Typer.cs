using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public int score = 0;
    public float time = 0;
    public TextMeshProUGUI Score,Timer;
    bool Playing = false;

    public WordBank wordBank = null;
    public TextMeshProUGUI wordOutput = null;
    //public Text wordOutput = null;    

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    private void Start()
    {
        SetCurrentWord();
    }


    private void SetCurrentWord()
    {
        //Get bank word.
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }
    // Update is called once per frame
    private void Update()
    {
        CheckInput();
        Score.text = $"Score: {score}";

        if(Playing == true)
            Timer.text = $"Time: {(time += Time.deltaTime).ToString("F2")}";
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
                EnterLetter(keysPressed);
        }
    }

    private void EnterLetter(string typedLetter)
    {
       if(IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                score++;
                GameObject.Find("SdM_UI").GetComponent<SdM_ui>().score();
                SetCurrentWord();

                if (score == 6)
                {
                    Playing = false;

                    GameObject.Find("Flowchart").GetComponent<Flowchart>().SetFloatVariable("Game1Time", time);

                    GameObject.Find("Flowchart").GetComponent<Flowchart>().SendFungusMessage("Game1Done");
                }
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        GameObject.Find("SdM_UI").GetComponent<SdM_ui>().key();
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    public void StartPlaying()
    {
        Playing = true;
    }
}
