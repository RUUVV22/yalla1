using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Auction : MonoBehaviour
{
    [SerializeField] private Score qnumber;
    public chooseparts chooseparts;
    [SerializeField] private AudioSource timer10s;
    [SerializeField] private Teamsinfo info;
    [SerializeField] private TextMeshProUGUI Question, answer, auction, timer, RoundNumber;
    [SerializeField] private GameObject ansewrs, nextpart, allrounds;
    private int roundnumber = 1;
    private int AuctionCounter = 0;
    private int CurrentIndex;
    /// timer athribute
    private float TimeRemaining = 3f;
    private bool timerIsRunninng;
    /// <summary> buttons
    public static bool Player1 = false;
    public static bool Player2 = false;
    [SerializeField] private Button Correct1;
    [SerializeField] private Button Correct2, right, faul;
    [SerializeField] private GameObject choosetheplayer, thetimer;
    /// </summary>

    /// <summary>
    /// Button color change
    [SerializeField] private Color disabledcolor, enabledcolor;
    [SerializeField] Button Starttimer;
    public Selectable selectable;
    /// </summary>

    private List<string> questions = new List<string> {
    "types of fruit in 30 seconds?",
    "car brands in 30 seconds?",
    "sports in 30 seconds?",
    "movie titles in 30 seconds?",
    "video game titles in 30 seconds?",
    "famous singers in 30 seconds?",
    "professional football players in 30 seconds?",
    "songs by Taylor Swift in 30 seconds?",
    "countries in Asia in 30 seconds?",
    "popular social media platforms in 30 seconds?",
    "famous actors in 30 seconds?",
    "FIFA World Cup host countries in 30 seconds?",
    "football managers who have won the UEFA Champions League in 30 seconds?",
    "Islamic holidays in 30 seconds?",
    "Islamic countries in 30 seconds?",
    " luxury car brands in 30 seconds?",
    "languages in 30 seconds?",
    "Palestinian dishes or traditional foods in 30 seconds?",
    "historical sites in Jordan in 30 seconds?"
    };
    public GameObject togglePrefab;
    public Transform contentPanel;
    private List<List<string>> answers = new List<List<string>>
    {
        new List<string> { "Apple",
                            "Banana",
                            "Orange",
                            "Grape",
                            "Strawberry",
                            "Watermelon",
                            "Pineapple",
                            "Mango",
                            "Cherry",
                            "Kiwi" },//1
        new List<string> { "Toyota",
                            "Honda",
                            "Ford",
                            "Chevrolet",
                            "BMW",
                            "Mercedes-Benz",
                            "Audi",
                            "Volkswagen",
                            "Nissan",
                            "Hyundai",
                            "Kia",
                            "Volvo",
                            "Mazda",
                            "Subaru",
                            "Lexus",
                            "Porsche",
                            "Jaguar",
                            "Land Rover",
                            "Jeep",
                            "Tesla" },//2
        new List<string> { "Tennis",
                            "Golf",
                            "Cricket",
                            "Rugby",
                            "Swimming",
                            "Table Tennis",
                            "Volleyball",
                            "Badminton",
                            "Boxing",
                            "Gymnastics",
                            "Ice Hockey",
                            "Skiing",
                            "Archery",
                            "Fencing",
                            "Wrestling",
                            "Surfing",
                            "Sailing",
                            "Cycling",
                            "Formula 1",
                            "Skateboarding" },//3
        new List<string> { "The Shawshank Redemption",
                            "Inception",
                            "The Godfather",
                            "Titanic",
                            "Forrest Gump",
                            "The Dark Knight",
                            "Pulp Fiction",
                            "Avengers: Endgame",
                            "Gladiator",
                            "The Matrix",
                            "Jurassic Park",
                            "The Lord of the Rings",
                            "Star Wars: Episode IV - A New Hope",
                            "Fight Club",
                            "Avatar",
                            "La La Land",
                            "Interstellar",
                            "The Lion King",
                            "Frozen",
                            "Harry Potter and the Sorcerer's Stone" },//4
        new List<string> { "The Legend of Zelda: Breath of the Wild",
                            "Red Dead Redemption 2",
                            "Grand Theft Auto V",
                            "The Witcher 3: Wild Hunt",
                            "Minecraft",
                            "Fortnite",
                            "Super Mario Odyssey",
                            "Overwatch",
                            "Call of Duty: Modern Warfare",
                            "Cyberpunk 2077",
                            "Animal Crossing: New Horizons",
                            "Super Smash Bros. Ultimate",
                            "Final Fantasy VII Remake",
                            "Assassin's Creed Valhalla",
                            "Resident Evil Village",
                            "Halo Infinite",
                            "Battlefield 2042",
                            "Stardew Valley",
                            "League of Legends",
                            "Persona 5" },//5
        new List<string> { "Beyoncé",
                            "Adele",
                            "Taylor Swift",
                            "Ed Sheeran",
                            "Rihanna",
                            "Justin Bieber",
                            "Ariana Grande",
                            "Bruno Mars",
                            "Lady Gaga",
                            "Drake",
                            "Katy Perry",
                            "Shawn Mendes",
                            "Billie Eilish",
                            "Mariah Carey",
                            "Michael Jackson",
                            "Madonna",
                            "Whitney Houston",
                            "Elton John",
                            "Dua Lipa",
                            "Selena Gomez"},//6
        new List<string> { "Lionel Messi",
                            "Cristiano Ronaldo",
                            "Neymar Jr.",
                            "Kylian Mbappé",
                            "Mohamed Salah",
                            "Robert Lewandowski",
                            "Kevin De Bruyne",
                            "Sergio Ramos",
                            "Virgil van Dijk",
                            "Harry Kane",
                            "Luka Modrić",
                            "Erling Haaland",
                            "Antoine Griezmann",
                            "Paulo Dybala",
                            "Sadio Mané",
                            "Romelu Lukaku",
                            "Raheem Sterling",
                            "Bruno Fernandes",
                            "N'Golo Kanté",
                            "Alisson Becker" },//7
        new List<string> { "Love Story",
                            "You Belong with Me",
                            "Blank Space",
                            "Shake It Off",
                            "Bad Blood",
                            "Style",
                            "Wildest Dreams",
                            "Look What You Made Me Do",
                            "Delicate",
                            "ME!",
                            "Lover",
                            "Cardigan",
                            "Willow",
                            "We Are Never Ever Getting Back Together",
                            "I Knew You Were Trouble",
                            "All Too Well",
                            "Red",
                            "Fearless",
                            "Mean",
                            "22"},//8
        new List<string> { "Japan",
                            "South Korea",
                            "North Korea",
                            "Vietnam",
                            "Thailand",
                            "Malaysia",
                            "Singapore",
                            "Indonesia",
                            "Philippines",
                            "Myanmar (Burma)",
                            "Cambodia",
                            "Laos",
                            "Bangladesh",
                            "Sri Lanka",
                            "Nepal",
                            "Bhutan",
                            "Maldives",
                            "Mongolia",
                            "Afghanistan",
                            "Pakistan" },//9
        new List<string> { "Facebook",
                            "Instagram",
                            "Twitter",
                            "TikTok",
                            "Snapchat",
                            "LinkedIn",
                            "Pinterest",
                            "Reddit",
                            "WhatsApp",
                            "YouTube",
                            "Tumblr",
                            "Discord",
                            "Telegram",
                            "WeChat",
                            "Viber",
                            "LINE",
                            "Twitch",
                            "QQ",
                            "Sina Weibo" },//10
        new List<string> {  "Tom Hanks",
                            "Leonardo DiCaprio",
                            "Brad Pitt",
                            "Denzel Washington",
                            "Robert De Niro",
                            "Johnny Depp",
                            "Will Smith",
                            "Matt Damon",
                            "Tom Cruise",
                            "Morgan Freeman",
                            "Samuel L. Jackson",
                            "Harrison Ford",
                            "Christian Bale",
                            "Daniel Day-Lewis",
                            "Jake Gyllenhaal",
                            "Ryan Reynolds",
                            "Chris Hemsworth",
                            "Dwayne Johnson",
                            "Scarlett Johansson",
                            "Jennifer Lawrence" },//11
        new List<string> { "Uruguay",
                            "Italy",
                            "France",
                            "Brazil",
                            "Switzerland",
                            "Sweden",
                            "Chile",
                            "England",
                            "Mexico",
                            "West Germany",
                            "Argentina",
                            "Spain",
                            "United States",
                            "South Korea and Japan",
                            "Germany",
                            "South Africa",
                            "Qatar" },//12
        new List<string> { "Sir Alex Ferguson",
                            "José Mourinho",
                            "Carlo Ancelotti",
                            "Pep Guardiola",
                            "Zinedine Zidane",
                            "Jupp Heynckes",
                            "Ottmar Hitzfeld",
                            "Rafael Benítez",
                            "Louis van Gaal",
                            "Diego Simeone" },//13
        new List<string> { "Eid al-Fitr",
                            "Eid al-Adha",
                            "Ramadan",
                            "Mawlid al-Nabi",
                            "Ashura",
                            "Laylat al-Qadr",
                            "Day of Arafah",},//14
        new List<string> { "Saudi Arabia",
                            "Pakistan",
                            "Indonesia",
                            "Turkey",
                            "Egypt",
                            "Bangladesh",
                            "Nigeria",
                            "Algeria",
                            "Morocco",
                            "Iraq",
                            "Afghanistan",
                            "Malaysia",
                            "Sudan",
                            "United Arab Emirates",
                            "Kuwait",
                            "Qatar",
                            "Jordan",
                            "Oman",
                            "Tunisia"},//15
        new List<string> { "Rolls-Royce",
                            "Bentley",
                            "Mercedes-Benz",
                            "BMW",
                            "Audi",
                            "Porsche",
                            "Lamborghini",
                            "Ferrari",
                            "Aston Martin" },//16
        new List<string> { "English",
                            "Spanish",
                            "Mandarin Chinese",
                            "Hindi",
                            "Arabic",
                            "Bengali",
                            "Portuguese",
                            "Russian",
                            "Japanese",
                            "German",
                            "French",
                            "Urdu",
                            "Swahili",
                            "Italian",
                            "Dutch",
                            "Korean",
                            "Turkish",
                            "Vietnamese",
                            "Polish",
                            "Thai" },//17
        new List<string> {"Musakhan",
                            "Maqluba",
                            "Falafel",
                            "Hummus",
                            "Taboon bread",
                            "Knafeh",
                            "Shawarma",
                            "Za'atar",
                            "Mutabbal",
                            "Fatayer",
                            "Waraq al-'Ayn",
                            "Arayes",
                            "Sfiha",
                            "Mujaddara",
                            "Sambousek",
                            "Kubbeh",
                            "Harees",
                            "Hummus ful",
                            "Ka'ak",
                            "Kanafeh" },//18
        new List<string> {  "Petra",
                            "Jerash",
                            "Amman Citadel ",
                            "Umm Qais ",
                            "Qasr Amra",
                            "Qasr al-Mushatta",
                            "Ajloun Castle ",
                            "Kerak Castle ",
                            "Mount Nebo",
                            "Madaba Mosaic Map",
                            "Umayyad Palace ",
                            "Baptism Site ",
                            "Desert Castles ",
                            "Shobak Castle (Montreal)",
                            "Wadi Rum ",
                            "Aqaba Fort",
                            "Roman Theater in Amman",
                            "Ajloun Forest Reserve",
                            "Dana Biosphere Reserve",
                            "Little Petra" },//19
    };
    public resizing resizing;
    public List<string> currentAnswers;
    void AddToggles(List<List<string>> answers, int index)
    {
        float XOffset = 0;
        float YOffset = 0;
        float contentWidth = 667f;
        float horizontalSpacing = 10f;
        float verticalSpacing = 60f;
        float toggleHeight = 0f;
        float toggleWidth = 0f;

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
    void Start()
    {
        ChooseRandomQuestion();
        Starttimer.interactable = false;
    }
    void Update()
    {
        Timer();
        if (qnumber.isactive)
        {
            RoundNumberfun();
        }
        if (TimeRemaining == 0)
            timer10s.Stop();
        RoundNumber.text = "#" + roundnumber.ToString();
    }
    private void Timer()
    {
        if (timerIsRunninng)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                UpdateTimerText();

            }
            else
            {
                TimeRemaining = 0f;
                timerIsRunninng = false;
                Debug.Log("Time's up!");
            }
        }
    }
    void RoundNumberfun()
    {
        if (roundnumber > qnumber.getQcounter())
        {
            roundnumber = qnumber.getQcounter();
            qnumber.isactive = false;
            if (chooseparts.IsAtEnd())
            {
                info.setinfo();
                SceneManager.LoadScene(3);
            }
            Invoke("loadascene", .11f);// load scene after 3s
        }
    }
    void loadascene()
    {
        this.gameObject.SetActive(false);
        allrounds.SetActive(false);
        chooseparts.NextPart();
    }
    public void StartTimer()// yalla
    {
        timer10s.Play();
        if (AuctionCounter != 0)
        {
            if (Player1 || Player2)
            {
                thetimer.SetActive(true);
                choosetheplayer.SetActive(false);
                right.enabled = true;
                faul.enabled = true;
                timerIsRunninng = true;
                //yalla = true;
                ansewrs.SetActive(true);
                TimeRemaining = 30f;
            }
            else
            {
                Debug.Log("try again");

            }
        }
    }
    void afterscore()
    {
        buttonColorwithoutclick(Correct1);
        buttonColorwithoutclick(Correct2);
        right.enabled = false;
        faul.enabled = false;
        AuctionCounter = 0;
        auction.text = AuctionCounter.ToString();
        StartCoroutine(ChangeQuestionAfterDelay(2.5f));
    }
    public void Right()
    {
        Starttimer.interactable = false;
        info.Right(Player1, Player2);
        TimeRemaining = 0;
        afterscore();
    }
    public void Faul()
    {
        Starttimer.interactable = false;
        info.Right(Player2, Player1);
        TimeRemaining = 0;
        afterscore();
    }
    IEnumerator ChangeQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Change the question text after 3 seconds
        roundnumber++;
        cleartoggles();
        ChooseRandomQuestion();
        ansewrs.SetActive(false);
        choosetheplayer.SetActive(true);
        thetimer.SetActive(false);
    }
    IEnumerator replaceQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        cleartoggles();
        ChooseRandomQuestion();
    }

    private void buttonColoronclick(Button button)
    {
        ColorBlock buttoncolor = button.colors;
        buttoncolor.normalColor = Color.red;
        button.colors = buttoncolor;
    }
    private void buttonColorwithoutclick(Button button)
    {
        ColorBlock buttoncolor = button.colors;
        buttoncolor.normalColor = Color.white;
        button.colors = buttoncolor;
    }
    public void correct1()
    {
        buttonColoronclick(Correct1);
        buttonColorwithoutclick(Correct2);
        Player1 = true;
        Player2 = false;
    }

    public void correct2()
    {
        buttonColoronclick(Correct2);
        buttonColorwithoutclick(Correct1);
        Player2 = true;
        Player1 = false;
    }
    public void Increase()
    {
        if (AuctionCounter < 40)
        {
            Starttimer.interactable = true;
            AuctionCounter++;
            auction.text = AuctionCounter.ToString();
        }
    }
    public void Decrease()
    {
        if (AuctionCounter > 0)
        {
            if (AuctionCounter == 1)
            {
                Starttimer.interactable = false;
            }
            AuctionCounter--;
            auction.text = AuctionCounter.ToString();
        }
    }
    
    public void Replace()
    {
        StartCoroutine(replaceQuestionAfterDelay(1.5f));
    }
    private void ChooseRandomQuestion()
    {
        CurrentIndex = Random.Range(0, questions.Count);
        Question.text = "Who can mention more " + questions[CurrentIndex];
        AddToggles(answers, CurrentIndex);
    }
    void UpdateTimerText()
    {
        int seconds = Mathf.RoundToInt(TimeRemaining);
        timer.text = seconds.ToString();
    }
    
}
