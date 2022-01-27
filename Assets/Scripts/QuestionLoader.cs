using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionLoader : MonoBehaviour
{
    public List<Question> questionsList;
    public List<Prepositions> prepositionsList;
    public List<Articles> articlesList;
    

    public Dictionary<int, Question> questions;
    public Dictionary<int, Prepositions> prepositions;
    public Dictionary<int, Articles> articles;

    public string gameMode;


    private void Awake()
    {
        questions = new Dictionary<int, Question>();
        prepositions = new Dictionary<int, Prepositions>();
        articles = new Dictionary<int, Articles>();

        


        QuestionDictionary articleDictionary = JsonUtility.FromJson<QuestionDictionary>(JsonFileReader.LoadJsonAsResource("Items/ArticleDictionary.json"));
        QuestionDictionary prepositionDictionary = JsonUtility.FromJson<QuestionDictionary>(JsonFileReader.LoadJsonAsResource("Items/PrepositionDictionary.json"));
        //QuestionDictionary dictionary = JsonUtility.FromJson<QuestionDictionary>(JsonFileReader.LoadJsonAsResource("Items/QuestionDictionary.json"));


        //SetAndLoadDictionary(gameMode);


        //foreach (string dictionaryQuestion in dictionary.questions)
        //{
        //    LoadQuestion(dictionaryQuestion);
        //}

        //foreach (KeyValuePair<int, Question> entry in questions)
        //{
        //    Question temp = entry.Value;
        //    questionsList.Add(temp);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadQuestion(string path)
    {
        
        string myLoadedQuestion = JsonFileReader.LoadJsonAsResource(path);
        Question myQuestion = JsonUtility.FromJson<Question>(myLoadedQuestion);

        if (questions.ContainsKey(myQuestion.questionId))
        {
            Debug.LogWarning("Question " + myQuestion.questionText + " Key already exists as " + questions[myQuestion.questionId]);

        }
        else
        {
            questions.Add(myQuestion.questionId, myQuestion);
        }
    }

    public void SetAndLoadDictionary(string gameMode)
    {
        QuestionDictionary dictionary;

        if (gameMode == "Articles")
        {
            dictionary = JsonUtility.FromJson<QuestionDictionary>(JsonFileReader.LoadJsonAsResource("Items/ArticleDictionary.json"));
            foreach (string dictionaryQuestion in dictionary.questions)
            {
                LoadQuestion(dictionaryQuestion);
            }

            foreach (KeyValuePair<int, Articles> entry in articles)
            {
                Articles temp = entry.Value;
                articlesList.Add(temp);
            }
        }
        else if(gameMode == "Prepositions")
        {
            dictionary = JsonUtility.FromJson<QuestionDictionary>(JsonFileReader.LoadJsonAsResource("Items/PrepositionDictionary.json"));
            foreach (string dictionaryQuestion in dictionary.questions)
            {
                LoadQuestion(dictionaryQuestion);
            }

            foreach (KeyValuePair<int, Prepositions> entry in prepositions)
            {
                Prepositions temp = entry.Value;
                prepositionsList.Add(temp);
            }
        }

    }

    public void SetGameMode(string mode)
    {

        if(mode == "Article")
        {
            gameMode = mode;
            SetAndLoadDictionary(gameMode);
        }
        else if(mode == "Preposition")
        {
            gameMode = mode;
            SetAndLoadDictionary(gameMode);
        }
    }
}
