using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    ScoreManager ScoreReferance;


    [SerializeField]
    Font myFont;

    string previousPage = null; // maybe change
    public bool inGame = false; //maybe change

    //need to start using this
    //Dropdown[] PlayerDropdowns = new Dropdown[4] { 1, 2, 3, 4 };

    #region Levels
    [Header("Levels")]
    [SerializeField]
    GameObject LevelOne;
    [SerializeField]
    GameObject LevelTwo;
    #endregion

    #region UI Pages
    [Header("Menus")]
    [SerializeField]
    GameObject MENU_home;
    [SerializeField]
    GameObject MENU_play;
    [SerializeField]
    GameObject MENU_gameSettings;
    [SerializeField]
    GameObject MENU_settings;
    [SerializeField]
    GameObject MENU_inGame;
    [SerializeField]
    GameObject MENU_pause;
    [SerializeField]
    GameObject MENU_yesNo;
    [SerializeField]
    GameObject MENU_editNames;
    [SerializeField]
    GameObject MENU_controls;
    [SerializeField]
    GameObject MENU_victory;
    [SerializeField]
    GameObject MENU_leaderboard;
    #endregion

    #region Input Fields
    [Header("NameInputField")]
    [SerializeField]
    Text TXT_inputName;
    [SerializeField]
    Text TXT_inputTitle;
    #endregion

    #region Players
    //Players
    [Header("PlayerDropdowns in play menu")]
    [SerializeField]
    Dropdown DD_playerOneName;
    [SerializeField]
    Dropdown DD_playerTwoName;
    [SerializeField]
    Dropdown DD_playerThreeName;
    [SerializeField]
    Dropdown DD_playerFourName;
    

    [SerializeField]
    GameObject GO_PM_PlayerThree;
    [SerializeField]
    GameObject GO_PM_PlayerFour;
    #endregion

    #region Ingame play display
    //ingame player display
    [Header("In Game Display Names")]
    [SerializeField]
    Text TXT_IG_playerOneNameDisplay;
    [SerializeField]
    Text TXT_IG_playerTwoNameDisplay;
    [SerializeField]
    Text TXT_IG_playerThreeNameDisplay;
    [SerializeField]
    Text TXT_IG_playerFourNameDisplay;
    [SerializeField]
    Text TXT_IG_timer;
    int timeLeft;
    #endregion

    #region Settings
    [Header("Settings")]
    [SerializeField]
    Slider SL_brightness;
    [SerializeField]
    Slider SL_AudioMaster;
    [SerializeField]
    Slider SL_AudioEffects;
    [SerializeField]
    Slider SL_AudioMusic;
    float AudioMultiplier;
    [SerializeField]
    Camera MenuCamera;
    #endregion

    #region Game Settings
    [Header("Game Settings")]
    [SerializeField]
    Slider SL_amountOfMess;
    [SerializeField]
    Slider SL_DangerFrequency;
    [SerializeField]
    Slider SL_NumberOfPlayers;
    [SerializeField] // need to load lights into array
    Light[] Lights_Ingame;

    [Header("Music")] // need to add switch for music
    [SerializeField]
    AudioSource AS_CameraMusic; 
    [SerializeField]
    AudioSource AS_IngameMusic; // need to add ingame music

    [Header("SFX")]
    [SerializeField]
    AudioSource[] SFX_Ingame; //need to load sounds into array

    int SelectedLevel = 1;
    #endregion

    #region Gets Elements For UI
    private Text[] GetTexts;
    private Button[] GetButtons;
    private Dropdown[] GetDropdowns;
    private Slider[] GetSliders;
    #endregion

    #region LeaderBoards
    [Header("Leaderboard")]
    [SerializeField]
    Text First;
    [SerializeField]
    Text Second;
    [SerializeField]
    Text Third;
    #endregion

    

    // Start is called before the first frame update
    void Start()
    {
        //assigns the scorereferance to the scoremanager script
        ScoreReferance = GetComponent<ScoreManager>();
        //sets all menus to visable so that code below can find elements
        MENU_home.SetActive(true);
        MENU_play.SetActive(true);
        MENU_gameSettings.SetActive(true);
        MENU_settings.SetActive(true);
        MENU_inGame.SetActive(true);
        MENU_pause.SetActive(true);
        MENU_yesNo.SetActive(true);
        MENU_editNames.SetActive(true);
        MENU_controls.SetActive(true);
        MENU_leaderboard.SetActive(true);
        MENU_victory.SetActive(true);

        //load names into the drop downs
        LoadNames(DD_playerOneName);
        LoadNames(DD_playerTwoName);
        LoadNames(DD_playerThreeName);
        LoadNames(DD_playerFourName);

        //add listeners to drop downs
        DD_playerOneName.onValueChanged.AddListener(delegate { DropdownHandler(DD_playerOneName);});
        DD_playerTwoName.onValueChanged.AddListener(delegate { DropdownHandler(DD_playerTwoName);});
        DD_playerThreeName.onValueChanged.AddListener(delegate { DropdownHandler(DD_playerThreeName);});
        DD_playerFourName.onValueChanged.AddListener(delegate { DropdownHandler(DD_playerFourName);});

        //adds listeners to sliders
        SL_brightness.onValueChanged.AddListener(delegate { BrightnessUpdate(); });
        SL_AudioMaster.onValueChanged.AddListener(delegate { AudioMasterUpdate(); });
        SL_AudioEffects.onValueChanged.AddListener(delegate { AudioSFXUpdate(); });
        SL_AudioMusic.onValueChanged.AddListener(delegate { AudioMusicUpdate(); });

        SL_NumberOfPlayers.onValueChanged.AddListener(delegate {NumberOfPlayersUpdate(); });

        //get lights in game

        Lights_Ingame = Light.FindObjectsOfType<Light>();

        //Set Fonts color
        GetTexts = Text.FindObjectsOfType<Text>();
        foreach (Text textElement in GetTexts)
        {
            textElement.font = myFont;
            textElement.color = Color.black;
        }
        //Set buttons color
        GetButtons = Text.FindObjectsOfType<Button>();
        foreach (Button buttonElement in GetButtons)
        {
            buttonElement.image.color = new Color(0.6f, 1, 1);
        }
        //set dropdowns color
        GetDropdowns = Text.FindObjectsOfType<Dropdown>();
        foreach (Dropdown dropdownElement in GetDropdowns)
        {
            dropdownElement.image.color = new Color(0.6f, 1, 1);
        }
        //set sliders color
        GetSliders = Text.FindObjectsOfType<Slider>();
        foreach (Slider sliderElement in GetSliders)
        {
            sliderElement.image.color = new Color(0.6f, 1, 1);
        }

        //hides menus other than the home 
        MENU_home.SetActive(true);
        MENU_play.SetActive(false);
        MENU_gameSettings.SetActive(false);
        MENU_settings.SetActive(false);
        MENU_inGame.SetActive(false);
        MENU_pause.SetActive(false);
        MENU_yesNo.SetActive(false);
        MENU_editNames.SetActive(false);
        MENU_controls.SetActive(false);
        MENU_leaderboard.SetActive(false);
        MENU_victory.SetActive(false);

        AudioMasterUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        //check if esc is pressed while ingame
        if (inGame == true)
        {
            if (Input.GetKeyDown("escape"))
            {
                //show pause menu
                MENU_pause.SetActive(true);
                inGame = false;
                MENU_inGame.GetComponent<CanvasGroup>().alpha = 0.5f;
            }
            //get the time left
            timeLeft = int.Parse(TXT_IG_timer.text.ToString());
            //if timer hits 0 show victory screen
            if (timeLeft <= 0)
            {
                inGame = false;
                MENU_inGame.SetActive(false);
                MENU_victory.SetActive(true);
            }
        }

        


    }

    #region Buttons / Pages

    public void HM_Play()
    {
        MENU_home.SetActive(false);
        MENU_play.SetActive(true);
    }
    public void HM_GameSettings()
    {
        previousPage = "HomeMenu";
        MENU_home.SetActive(false);
        MENU_gameSettings.SetActive(true);
    }
    public void HM_Settings()
    {
        previousPage = "HomeMenu";
        MENU_home.SetActive(false);
        MENU_settings.SetActive(true);
    }
    public void HM_Leaderboard()
    {
        MENU_home.SetActive(false);
        MENU_leaderboard.SetActive(true);
    }
    public void HM_Exit()
    {
        Application.Quit();
        Debug.Log("Exit button pressed");
    }

    //PlayMenu

    public void PM_Play()
    {
        //sets in game names to selected dropdown selection
        TXT_IG_playerOneNameDisplay.text = DD_playerOneName.options[DD_playerOneName.value].text;
        TXT_IG_playerTwoNameDisplay.text = DD_playerTwoName.options[DD_playerTwoName.value].text;
        TXT_IG_playerThreeNameDisplay.text = DD_playerThreeName.options[DD_playerThreeName.value].text;
        TXT_IG_playerFourNameDisplay.text = DD_playerFourName.options[DD_playerFourName.value].text;
        NumberOfPlayersUpdate();

        MENU_play.SetActive(false);
        MenuCamera.enabled = false;
        MenuCamera.GetComponent<AudioListener>().enabled = false;
        inGame = true;
        if (SelectedLevel == 1)
        {
            LevelOne.SetActive(true);
        }
        if (SelectedLevel == 2)
        {
            LevelTwo.SetActive(true);
        }
        else LevelOne.SetActive(true);
        MENU_inGame.GetComponent<CanvasGroup>().alpha = 1;
        MENU_inGame.SetActive(true);
    }
    public void PM_LevelToggle()
    {
        if (SelectedLevel == 1)
        {
            SelectedLevel = 2;
        }
        else
        {
            SelectedLevel = 1;
        }
    }
    public void PM_GameSettings()
    {
        previousPage = "PlayMenu";
        MENU_play.SetActive(false);
        MENU_gameSettings.SetActive(true);
    }
    public void PM_EditNames()
    {
        MENU_play.SetActive(false);
        MENU_editNames.SetActive(true);
    }
    public void PM_Controls()
    {
        MENU_play.SetActive(false);
        MENU_controls.SetActive(true);
    }
    public void PM_Back()
    {
        MENU_play.SetActive(false);
        MENU_home.SetActive(true);
    }

    //GameSettings

    public void GS_Back()
    {
        if (previousPage == "HomeMenu")
        {
            MENU_gameSettings.SetActive(false);
            MENU_home.SetActive(true);
        }
        else if (previousPage == "PlayMenu")
        {
            MENU_gameSettings.SetActive(false);
            MENU_play.SetActive(true);
        }
        else if (previousPage == "InGame")
        {
            MENU_gameSettings.SetActive(false);
            MENU_inGame.SetActive(true);
            MENU_pause.SetActive(true);
        }


    }

    //Settings

    public void S_Back()
    {
        if(previousPage == "InGame")
        {
            MENU_settings.SetActive(false);
            MENU_pause.SetActive(true);

        }
        if (previousPage == "HomeMenu")
        {
            MENU_settings.SetActive(false);
            MENU_home.SetActive(true);
        }
        
    }

    //Pause / Ingame

    public void IG_Resume()
    {
        MENU_pause.SetActive(false);
        MENU_inGame.GetComponent<CanvasGroup>().alpha = 1;
        inGame = true;
    }
    public void IG_GameSettings()
    {
        previousPage = "InGame";
        MENU_pause.SetActive(false);
        MENU_gameSettings.SetActive(true);
    }
    public void IG_Settings()
    {
        previousPage = "InGame";
        MENU_pause.SetActive(false);
        MENU_settings.SetActive(true);
    }
    public void IG_Home()
    {
        MENU_yesNo.SetActive(true);
        MENU_pause.SetActive(false);
    }

    //Yes or no

    public void Yn_Yes()
    {
        MENU_yesNo.SetActive(false);
        MENU_inGame.SetActive(false);
        MENU_home.SetActive(true);
        MenuCamera.enabled = true;
        MenuCamera.GetComponent<AudioListener>().enabled = true;
        LevelOne.SetActive(false);
        LevelTwo.SetActive(false);
    }
    public void Yn_No()
    {
        MENU_yesNo.SetActive(false);
        MENU_pause.SetActive(true);
    }

    //EditNames

    public void EN_Add()
    {
        //load names from txt document into a string
        //split the string at , into array
        string Str_playNameFile = File.ReadAllText("Assets/Chris/PlayerNames/PlayerNames.txt");
        string[] Str_playerNames = Str_playNameFile.Split(',');

        bool found = false;

        //checks each string in array
        foreach (string Str_playerName in Str_playerNames)
        {
            //if seached name is in array found is true
            if(TXT_inputName.text == Str_playerName)
            {
                found = true;
            }
        }
        //if not found in array
        //add the inputed name into the text doc after the original string
        //adding a , at the end
        if (found == false)
        {
            File.WriteAllText("Assets/Chris/PlayerNames/PlayerNames.txt", Str_playNameFile + TXT_inputName.text + ",");
            TXT_inputTitle.text = "Name : " + TXT_inputName.text + " has been added";
        }
        //if name is found
        //give prompt that name couldnt be added
        if (found == true)
        {
            TXT_inputTitle.text = "Unable to add : " + TXT_inputName.text + " please input a new name that is not in use";
        }

        //load all of the dropdowns with new values
        LoadNames(DD_playerOneName);
        LoadNames(DD_playerTwoName);
        LoadNames(DD_playerThreeName);
        LoadNames(DD_playerFourName);

    }
    public void EN_Remove()
    {
        //get values from txt doc and save in array
        string Str_playNameFile = File.ReadAllText("Assets/Chris/PlayerNames/PlayerNames.txt");
        string[] Str_playerNames = Str_playNameFile.Split(',');

        //load arr with txt doc values
        ArrayList arr = new ArrayList(50);
        foreach (string Str_playerName in Str_playerNames)
        {
            arr.Add(Str_playerName);
        }

        bool successful = false;
        //check for the seached value in the array
        foreach (string Str_playerName in Str_playerNames)
        {
            //if found remove the name from the ArrayList
            //load the values in the ArrayList back into a string array
            //splitting values with ,
            //write the string into a the PlayerNames .txt
            if (TXT_inputName.text == Str_playerName)
            {
                arr.Remove(TXT_inputName.text);

                string[] newFileNames = new string[arr.Count];
                arr.CopyTo(newFileNames);

                string newFile = string.Join(",", newFileNames);
                File.WriteAllText("Assets/Chris/PlayerNames/PlayerNames.txt", newFile);

                TXT_inputTitle.text = TXT_inputName.text + " has been removed";
                successful = true;
            }

        }
        //if unable to find value display prompt
        if (successful == false)
        {
            TXT_inputTitle.text = "Unable to remove : " + TXT_inputName.text + " please input a new name";
        }

        //load all of the dropdowns with new values
        LoadNames(DD_playerOneName);
        LoadNames(DD_playerTwoName);
        LoadNames(DD_playerThreeName);
        LoadNames(DD_playerFourName);
    }
    public void EN_Back()
    {
        MENU_editNames.SetActive(false);
        MENU_play.SetActive(true);
    }
    
    //Controls

    public void CTR_Back()
    {
        MENU_controls.SetActive(false);
        MENU_play.SetActive(true);
    }

    //Victory
    public void V_Home()
    {
        MENU_home.SetActive(true);
        MENU_victory.SetActive(false);
        MenuCamera.enabled = true;
        MenuCamera.GetComponent<AudioListener>().enabled = true;
        LevelOne.SetActive(false);
        LevelTwo.SetActive(false);
    }
    public void UpdateScores()
    {
        //load all active players scores
        //if end score is greater than score
        //update score
        //write new numbers to txt file
    }   //Need to do

    //Leaderboard

    public void LoadLeaderboard()
    {

        //load player names
        //remove last 3 digits of all playernames
        //sort them
        //get top three and set texts to their values


    }    //Need to do
    //Victory
    public void L_Back()
    {
        MENU_leaderboard.SetActive(false);
        MENU_home.SetActive(true);
    }
    #endregion


    //LoadNames Dropdowns

    public void LoadNames(Dropdown Dd_PlayerName)
    {
        // load the names needed for the dropdown into an array splitting at ,
        string Str_playNameFile = File.ReadAllText("Assets/Chris/PlayerNames/PlayerNames.txt");
        string[] Str_playerNames = Str_playNameFile.Split(',');
        
        Dd_PlayerName.options.Clear();

        //set the first option in the dd to the playername defult removing the first few char of dd_
        Dd_PlayerName.options.Add(new Dropdown.OptionData(Dd_PlayerName.ToString().Remove(0,3)));

        //load the names saved into the dropdown list after the preset
        foreach (string Str_playerName in Str_playerNames)
        {
            Dd_PlayerName.options.Add(new Dropdown.OptionData(Str_playerName));
        }

        //add edit names option to end of list
        Dd_PlayerName.options.Add(new Dropdown.OptionData("EditNames"));

        //refresh the values in the dropdown that has been updated
        Dd_PlayerName.RefreshShownValue();
    }
    private void DropdownHandler(Dropdown Dd_target)
    {
        //checks value in dropdown
        if (Dd_target.options[Dd_target.value].text == "EditNames")
        {
            Dd_target.value = 0;
            MENU_play.SetActive(false);
            MENU_editNames.SetActive(true);
            
        }

        if (Dd_target.options[Dd_target.value].text == "")
        {
            Dd_target.value = 0;
        }

        //refresh the dropdown values when updated
        Dd_target.RefreshShownValue();
    }

    //Settings sliders / update on value change

    public void BrightnessUpdate()
    {
        //set all of the lights saved in the array to the brightness sliders value
        foreach(Light light in Lights_Ingame)
        {
            light.intensity = SL_brightness.value;
        }
    }
    public void AudioMasterUpdate()
    {
        //set the audio master multiplier
        AudioMultiplier = SL_AudioMaster.value;
        AudioMultiplier = AudioMultiplier / 2;
        //update the audio sliders with the new multiplier
        AudioSFXUpdate();
        AudioMusicUpdate();
    }
    public void AudioSFXUpdate()
    {
        //adjust the audio volume for all sfx in the scene
        foreach (AudioSource audio in SFX_Ingame)
        {
             audio.volume = SL_AudioEffects.value * AudioMultiplier;
        }
    }
    public void AudioMusicUpdate()
    {
        AS_CameraMusic.volume = SL_AudioMusic.value * AudioMultiplier;
        //IngameMusic.volume = SL_AudioMusic.value * AudioMultiplier;
    }

    //Game settings sliders / update on value change

    private void NumberOfPlayersUpdate()
    { 
        //update the players depending on the max player slider value

        if (SL_NumberOfPlayers.value == 2)
        {
            GO_PM_PlayerThree.SetActive(false);
            TXT_IG_playerThreeNameDisplay.gameObject.SetActive(false);
            GO_PM_PlayerFour.SetActive(false);
            TXT_IG_playerFourNameDisplay.gameObject.SetActive(false);
        }

        if (SL_NumberOfPlayers.value == 3)
        {
            GO_PM_PlayerThree.SetActive(true);
            GO_PM_PlayerFour.SetActive(false);
            TXT_IG_playerFourNameDisplay.gameObject.SetActive(false);
        }

        if (SL_NumberOfPlayers.value == 4)
        {
            GO_PM_PlayerThree.SetActive(true);
            GO_PM_PlayerFour.SetActive(true);
        }
    }


}