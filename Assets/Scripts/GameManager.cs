using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI questionNumberText;
    //public string option1;
    //public string option2;
    //public string answerText;

    public int questionId;
    public int questionNumber;
    public int maxQuestionNumber;

    public Transform climbPointParent;
    
    Vector3 spawnOffset;

    public GameObject climbPointPrefab;

    public QuestionLoader instance;

    public List<string> optionList = new List<string>();
    public List<GameObject> climbPointList;

    int randNumber;
    public Question questionData;
    public Articles articleData;
    public Prepositions prepositionData;




    void Start()
    {
        spawnOffset = new Vector3(-6f,0,0);
        questionNumber = 0;
        //maxQuestionNumber = instance.questionsList.Count;

       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextQuestion()
    {
        randNumber = Random.Range(0, instance.questionsList.Count - 1);
        questionNumber += 1;
        if (questionNumber > maxQuestionNumber)
        {
            Debug.LogWarning("Run out of question");
        }
        else
        {
            questionData = instance.questionsList[randNumber];
            questionText.text = questionData.questionText;
            questionNumberText.text = questionNumber.ToString();
            optionList.Add(questionData.option1);
            optionList.Add(questionData.option2);
            optionList.Add(questionData.answerText);

        }

        AssignOptions();
    }

    public void AssignOptions()
    {
        climbPointList[0].GetComponentInChildren<TextMeshPro>().text = questionData.answerText;
        climbPointList[1].GetComponentInChildren<TextMeshPro>().text = questionData.option1;
        climbPointList[2].GetComponentInChildren<TextMeshPro>().text = questionData.option2;



    }

    public void SpawnClimbPoints()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject climbPoint = Instantiate(climbPointPrefab, spawnOffset, Quaternion.identity);
            climbPoint.transform.parent = climbPointParent;
            climbPointList.Add(climbPoint);
            spawnOffset = spawnOffset + new Vector3(6f, 0, 0);
        }
        
    }

    public void SelectGameMode(string gameMode)
    {
        if(gameMode == "Article")
        {

        }
        else if(gameMode == "Preposition")
        {

        }

        
        //AssignOptions();
        SpawnClimbPoints();
        LoadNextQuestion();
    }
    
}
