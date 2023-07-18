using System.Collections;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Symbol;
    public TMP_Text wordText;
    public GameObject text;
    public GameObject Bar;
    public string[] words;
    public string[] words2;
    private int currentIndex;
    private float timer;
    private int currentLetterIndex = 0;
    bool _itsStarted;
    private bool isWords1Completed = false;
    public LoadBar Barmanager;
    public Dots DotsManager;

    void Start()
    {
        
        words = new string[] {"Starting ","Tor ","Browser...","\n",
          "Connecting"," ","to"," ", "the" ," ","Darkweb","...","\n","\n",
          "FR13ND"," ",": ...","\n","\n",
          "FR13ND"," ",": ","I"," ", "got"," ","a" ," ","job"," ", "for"," ", "you.","\n","\n",
          "Me",": ","What ","is ", "it?","\n","\n",
          "FR13ND",": ", "It’s ", "easy. ","You ", "just ", "have ", "to ", "pick ", "up ", "a ", "package.","\n","\n",
          "Me",": ","From ", "Duck?","\n","\n",
          "FR13ND",": ","Yes","\n","\n",

        };
        words2 = new string[] { "Me", ": ", "He ", "is ", "crazy. ", "It’s ", "impossible ", "to ", "find ", "his ", "stuff. ","\n", "You ", "have ", "to ", "follow ", "all ", "his ", "clues ", "to ", "find ", "it. ","\n","\n",
            "FR13ND",": ","It ", "pays ", "well... ","\n","\n",
            "Me",": ","Ok, ", "where ","do  ", "I ", "start. ","\n","\n",
            "FR13ND",": ", "Porta ", "Genova, ", "tonight. ","\n"
        };
        currentIndex = 0;
        timer = 0f;

    }


    void Update()
    {
        if (!_itsStarted)
            return;

        if (_itsStarted)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                timer = 0f;
                DisplayNextWord();
            }

        }
        if (isWords1Completed)
        {
            if (currentIndex >= words2.Length)
            {
                Debug.Log("Tutte le parole sono state visualizzate.");
                _itsStarted = false;
            }
        }
    }

    private void DisplayNextWord()
    {
        if (!isWords1Completed)
        {
            if (currentLetterIndex < words[currentIndex].Length)
            {
                wordText.text += words[currentIndex][currentLetterIndex];
                currentLetterIndex++;
            }
            else
            {
                currentLetterIndex = 0;
                currentIndex++;

                if (currentIndex >= words.Length)
                {
                    isWords1Completed = true;
                    wordText.text = "";
                    currentIndex = 0;
                }
            }
        }
        else
        {
            if (currentLetterIndex < words2[currentIndex].Length)
            {
                wordText.text += words2[currentIndex][currentLetterIndex];
                currentLetterIndex++;
            }
            else
            {
                currentLetterIndex = 0;
                currentIndex++;
            }
        }
    }

    public void OnStartClick()
    {
        Bar.SetActive(true);
        Barmanager.OnStartClick();
        Symbol.SetActive(false);
    }

    public void LoadComplete()
    {
        StartCoroutine(Dots());
        text.SetActive(true);
        Bar.SetActive(false);
        DisplayNextWord();
        _itsStarted = true;
        
    }
    private IEnumerator Dots()
    {
        DotsManager.OnStartDots();
        yield return new WaitForSeconds(3);
   
    }
}
