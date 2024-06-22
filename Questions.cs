using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography;
using UnityEngine.PlayerLoop;

public class Questions : MonoBehaviour
{
    [SerializeField] private Score qnumber;
    [SerializeField] private GameObject nextpart,allrounds;
    [SerializeField] private Teamsinfo info;
    [SerializeField] private chooseparts chooseparts;
    [SerializeField] private TextMeshProUGUI Question,answer,roundnumber;
    [SerializeField] private Button nextquestion;
    private int currentindex;
    public int sumscore=1;
    public int roundnum=1;
    public static bool IsNext = false;

    /// <summary>
    /// //////team 1 info
    
    [SerializeField] private GameObject[] Strikes1;
    public int strkieindex1 = 0;
    public int increasecount1 = 0;

    /// <summary>
    /// //////team 2 info

    [SerializeField] private GameObject[] Strikes2;
    public int strkieindex2 = 0;
    public int increasecount2 = 0;

    /// <summary>
    /// Buttons 
    [SerializeField]private Button startbutton,Strike1,Strike2;
    /// </summary>
    /// 




    private List<string> questions = new List<string> {
    "countries that start with the letter \"B\"?",
    "movie titles that start with the letter \"T\"?",
    "football players name starts with the letter \"m\"?",
    "villages in irbid?",
    "yalla fam names?",
    "palestinian cities?",
    "Country currencies?",
    "Capitals of Arab countries?",
    "countries in Africa?",
    "universities in the Jordan?",
    "programming languages?"
    ,"national dishes from around the MENA?",
    "superheroes from Marvel Comics?",
    "teams in the English Premier League?",
    "clubs in La Liga?",
    "FIFA World Cup winners?",
    "cartoon characters?",
    "characters from the Harry Potter series?",
    "board games?"
    };
    public GameObject togglePrefab;
    public Transform contentPanel;
    private List<List<string>> answers = new List<List<string>>
    {
        new List<string> { "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina Faso",
            "Burundi"},
        new List<string> { "Titanic",
            "The Terminator",
            "Top Gun",
            "Toy Story",
            "Transformers",
            "The Truman Show",
            "The Twilight Saga",
            "True Grit",
            "The Town",
            "The Tourist",
            "Thor",
            "The Theory of Everything",
            "The Transporter",
            "The Texas Chain Saw Massacre",
            "The Tree of Life",
            "The Thing",
            "The Time Traveler's Wife",
            "The Tuxedo",
            "True Lies",
            "Twister"
            },
        new List<string> { "Lionel Messi",
            "Mesut Özil",
            "Mohamed Salah",
            "Mario Balotelli",
            "Manuel Neuer",
            "Marcus Rashford",
            "Marco Reus",
            "Mauro Icardi",
            "Miralem Pjanić",
            "Marouane Fellaini",
            "Mats Hummels",
            "Mario Götze",
            "Marcelo Vieira",
            "Marcos Alonso",
            "Moussa Sissoko",
            "Milan Skriniar",
            "Mateo Kovačić",
            "Michy Batshuayi",
            "Memphis Depay",
            "Mathieu Valbuena" },
        new List<string> { "Al Husn",
            "Ar Ramtha",
            "Koura",
            "Kofranjah",
            "Bartaa",
            "Kufr Abil",
            "Bani Kinanah",
            "Kufr Asad",
            "Ayy",
            "Al Masharee",
            "Malka",
            "Al Hashimiyya",
            "Al Rai",
            "Kufr Khall",
            "Kharja",
            "Kafr Yuba",
            "Ain Al Basha",
            "Ain Al Dhikr",
            "Sakib",
            "Mareh",
            "Ain Al Bayda",
            "Bayt Ras",
            "Bayt Idis",
            "Al Hashimiyya",
            "Bayt Yafa",
            "Al Malha"},
        new List<string>
        {
            "baraah","ahmad","osama1","osama2","hayat","lissa","noor","bahaa","zaid","saja","islam","lama","yasmeen","hashim","sewar","toqa","roa'a"
            ,"assad"
        },
        new List<string>
        {
            "Ramallah",
            "Gaza City",
            "Hebron (Al-Khalil)",
            "Nablus",
            "Bethlehem",
            "Jericho",
            "Jenin",
            "Tulkarm",
            "Qalqilya",
            "Rafah",
            "Beit Sahour",
            "Beit Jala",
            "Tubas",
            "Salfit",
            "Dura",
            "Al-Bireh",
            "Khan Yunis",
            "Deir al-Balah",
            "Beit Ula",
            "Bir Zeit",
            "Halhul",
            "Kafr Qaddum",
            "Kafr Thulth",
            "Kifl Haris",
            "Qabatiya",
            "Silwad",
            "Surif"
        },
        new List<string>
        {
             "United States Dollar ",
             "Canadian Dollar ",
            "Pound Sterling",
            "Euro",
            "Japanese Yen",
            "Chinese Yuan Renminbi",
            "Australian Dollar",
            "Indian Rupee",
            "Brazilian Real",
            "Russian Ruble",
            "South African Rand",
            "Swiss Franc ",
            "Mexican Peso ",
            "South Korean Won ",
            "Saudi Riyal",
            "Turkish Lira",
            "Singapore Dollar ",
            "New Zealand Dollar ",
            "Norwegian Krone ",
            "Swedish Krona "
        },
        new List<string>
        {
            "Algiers",           // Algeria
            "Manama",            // Bahrain
            "Moroni",            // Comoros
            "Djibouti",          // Djibouti
            "Cairo",             // Egypt
            "Baghdad",           // Iraq
            "Amman",             // Jordan
            "Kuwait City",       // Kuwait
            "Beirut",            // Lebanon
            "Tripoli",           // Libya
            "Nouakchott",        // Mauritania
            "Rabat",             // Morocco
            "Muscat",            // Oman
            "Ramallah",          // Palestine
            "Doha",              // Qatar
            "Riyadh",            // Saudi Arabia
            "Mogadishu",         // Somalia
            "Khartoum",          // Sudan
            "Damascus",          // Syria
            "Tunis",             // Tunisia
            "Abu Dhabi",         // United Arab Emirates
            "Sana'a"             // Yemen
        },
        new List<string>
        {
            "Algeria",
            "Angola",
            "Benin",
            "Botswana",
            "Burkina Faso",
            "Burundi",
            "Cabo Verde",
            "Cameroon",
            "Central African Republic",
            "Chad",
            "Comoros",
            "Democratic Republic of the Congo",
            "Djibouti",
            "Egypt",
            "Equatorial Guinea",
            "Eritrea",
            "Eswatini"
        },
        new List < string > {

        "University of Jordan",
            "Jordan University of Science and Technology",
            "Hashemite University",
            "Yarmouk University",
            "Princess Sumaya University for Technology",
            "German Jordanian University",
            "Mutah University",
            "Philadelphia University",
            "Applied Science University",
            "Al-Zaytoonah University of Jordan",
            "Amman Arab University",
            "Middle East University",
            "Petra University",
            "Jerash University",
            "Aqaba University of Technology"},
        new List < string > {
            "C",
            "C++",
            "Java",
            "Python",
            "JavaScript",
            "C#",
            "Swift",
            "PHP",
            "Ruby",
            "Go",
            "Rust",
            "TypeScript",
            "Kotlin",
            "Perl",
            "Scala",
            "Haskell",
            "Lua",
            "Objective-C",
            "R",
            "SQL"},
        new List < string > {
            "Egypt - Koshari",
            "Morocco - Tagine",
            "Tunisia - Couscous",
            "Lebanon - Kibbeh",
            "Jordan - Mansaf",
            "Saudi Arabia - Kabsa",
            "United Arab Emirates - Machboos",
            "Iraq - Tashreeb",
            "Syria - Fattoush",
            "Palestine - Musakhan",
            "Algeria - Couscous",
            "Iran - Chelo kebab",
            "Turkey - Kebab",
            "Yemen - Saltah",
            "Oman - Shuwa",
            "Libya - Bazin",
            "Bahrain - Machboos"},
        new List < string > {
            "Spider-Man",
            "Iron Man",
            "Captain America",
            "Thor",
            "Hulk",
            "Black Widow",
            "Black Panther",
            "Doctor Strange",
            "Captain Marvel",
            "Wolverine",
            "Deadpool",
            "Scarlet Witch",
            "Thanos",
            "Groot",
            "Star-Lord",
            "Nick Fury",
            "Daredevil",
            "Storm",
            "Professor X",
            "Magneto"},
        new List < string > {"Arsenal",
            "Aston Villa",
            "Brentford",
            "Brighton",
            "Burnley",
            "Chelsea",
            "Crystal Palace",
            "Everton",
            "Leeds United",
            "Leicester City",
            "Liverpool",
            "Manchester City",
            "Manchester United",
            "Newcastle United",
            "Norwich City",
            "Southampton",
            "Tottenham Hotspur",
            "Watford",
            "West Ham United",
            "Wolverhampton " },
        new List<string>
        {
            "Athletic Bilbao",
            "Atlético Madrid",
            "Barcelona",
            "Cádiz",
            "Celta Vigo",
            "Elche",
            "Espanyol",
            "Getafe",
            "Granada",
            "Levante",
            "Mallorca",
            "Osasuna",
            "Rayo Vallecano",
            "Real Betis",
            "Real Madrid",
            "Real Sociedad",
            "Sevilla",
            "Valencia",
            "Villarreal"
        },
        new List<string>
        {
            "Uruguay",
            "Italy",
            "Germany",
            "Brazil",
            "Argentina",
            "England",
            "France",
            "Spain"
        },
        new List<string>
        {
            "u answer"
        },
        new List<string>
        {
            "Harry Potter",
            "Hermione Granger",
            "Ron Weasley",
            "Albus Dumbledore",
            "Severus Snape",
            "Rubeus Hagrid",
            "Sirius Black",
            "Remus Lupin",
            "Ginny Weasley",
            "Neville Longbottom",
            "Luna Lovegood",
            "Fred Weasley",
            "George Weasley",
            "Draco Malfoy",
            "Bellatrix Lestrange",
            "Voldemort (Tom Riddle)",
            "Minerva McGonagall",
            "Dobby",
            "Lucius Malfoy",
            "Dolores Umbridge",
            "Cedric Diggory",
            "Sirius Black",
            "Argus Filch",
            "Filius Flitwick",
            "Vernon Dursley",
            "Petunia Dursley"
        },
        new List<string>
        {
             "Monopoly",
            "Scrabble",
            "Risk",
            "Chess",
            "Checkers",
            "Settlers of Catan",
            "Ticket to Ride",
            "Carcassonne",
            "Clue (Cluedo)",
            "Battleship",
            "Twister",
            "Puerto Rico",
            "Pandemic",
            "Codenames",
            "Splendor",
            "Axis & Allies",
            "Dominion",
            "Catan",
            "Uno",
            "Sequence",
            "Sorry!",
            "Yahtzee",
            "Trivial Pursuit",
            "Connect Four",
            "Jenga",
            "The Game of Life"
        }
    };
    public resizing resizing;
    public List<string> currentAnswers;
    void AddToggles(List<List<string>> answers, int index)
    {
        float XOffset = 0;
        float YOffset = 0;//-31.47f
        float contentWidth = 667f;
        float horizontalSpacing = 10f;
        float verticalSpacing = 60f;
        float toggleHeight = 0f;
        float toggleWidth= 0f;
        currentAnswers = answers[index];
        int totalToggles = currentAnswers.Count;
        foreach (var answer in currentAnswers)
        {

            GameObject newToggle = Instantiate(togglePrefab, contentPanel);

            Text label = newToggle.GetComponentInChildren<Text>();
            if (label != null)
            {
                label.text = answer;
            }

            toggleWidth = resizing.AdjustToggleSize(newToggle);

            RectTransform toggleRect = newToggle.GetComponent<RectTransform>();
            toggleRect.anchoredPosition = new Vector2(XOffset, YOffset);

            if (toggleHeight == 0f)
            {
                toggleHeight = toggleRect.sizeDelta.y;
            }

            XOffset += toggleWidth + horizontalSpacing;

            if (XOffset + toggleWidth > contentWidth)
            {
                XOffset = 0;
                YOffset -= toggleRect.sizeDelta.y + verticalSpacing;
            }
        }
        float totalRows = Mathf.Ceil(totalToggles / Mathf.Floor(contentWidth / (toggleWidth + horizontalSpacing)));
        float requiredHeight = totalRows * (toggleHeight + verticalSpacing) - verticalSpacing;

        RectTransform contentRectTransform = contentPanel.GetComponent<RectTransform>();
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, Mathf.Abs(YOffset) + toggleHeight);
    }
    void cleartoggles()
    {
        currentAnswers.Clear();
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }
    }
    private void Start()
    {
        ChooseRandomQuestion();
    }

    public void NextQuestion()
    {
        info.next= true;
        StartCoroutine(ChangeQuestionAfterDelay(2f));
        desabledbuttons();
    }
    private void Update()
    {
        roundnumber.text="#"+roundnum.ToString();
        if (qnumber.isactive)
        {
            RoundNumber();
        }
    }
    
    void RoundNumber()
    {
        if (roundnum > qnumber.getQcounter())
        {
            roundnum = qnumber.getQcounter();
            desabledbuttons();
            qnumber.isactive = false;
            if (chooseparts.IsAtEnd()) {
                info.setinfo();
                SceneManager.LoadScene(3);
            }
            Invoke("loadNextPart", .11f);// load scene after 3s
        }
    }
    void loadNextPart()
    {
        this.gameObject.SetActive(false);
        allrounds.SetActive(false);
        chooseparts.NextPart();
    }
    public void enabledbuttons()
    {
        startbutton.interactable = true;
        Strike1.enabled = true;
        Strike2.enabled = true;
    }
    public void desabledbuttons()
    {
        startbutton.interactable = false;
        Strike1.enabled = false;
        Strike2.enabled = false;
    }
    public IEnumerator ChangeQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Change the question text after 3 seconds
        cleartoggles();
        if (strkieindex1 == 3|| strkieindex2==3)
        {
            info.fillstrikes(Strikes1, Strikes2);
        }
        strkieindex1 = 0;
        strkieindex2 = 0;
        roundnum++;
        enabledbuttons();
        ChooseRandomQuestion();
    }
    IEnumerator replaceQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        enabledbuttons();
        ChooseRandomQuestion();
    }
    public void Replace()
    {
        cleartoggles();
        desabledbuttons();
        StartCoroutine(replaceQuestionAfterDelay(1.5f));
    }
    private void ChooseRandomQuestion()
    {
        currentindex = Random.Range(0, questions.Count);
        Question.text = "Mention a " + questions[currentindex];
        AddToggles(answers,currentindex);
    }
    public void strike1()
    {
        info.strikes(Strikes2, Strikes1, strkieindex1,1);
        strkieindex1++;
    }
    public void strike2()
    {
        info.strikes(Strikes1,Strikes2,strkieindex2,2);
        strkieindex2++;
    }
}
