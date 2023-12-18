using UnityEngine;
using UnityEngine.UI;

public class Hacker : MonoBehaviour
{
    public Text menuText;
    enum Screen { MainMenu, Password, Win };
    int level;
    Screen currentScreen;
    string password;
    string[] level1passwords = { "brave", "human", "sugar", "skirt", "light", "pencil" };
    string[] level2passwords = { "screen", "online", "report", "client", "fireman", "machine" };
    string[] level3passwords = { "traditional", "security", "president", "prevent", "system", "assault" };
    string[] level27passwords = { "undefined", "censored", "project", "reality", "organization", "facility" };
    string[] level94passwords = { "computer", "terminal", "hacker", "password", "guess", "keyboard" };
    void Start()
    {        
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        menuText.gameObject.SetActive(false);
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome, what do you want to do today?\n\n" +
            "Hack to someone's personal computer(1)" +
            "\nHack to random companies computer(2)" +
            "\nHack to secret governmental computer(3)" +
            "Type guide for the some information" +
            "\n\nEnter your select:");
    }
    void ShowGuide()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("To back to menu type 'menu'\n" +
            "To close the game type 'exit'\n" +
            "To clear screen type 'clear'\n" +
            "There is two secret level,\nif you find them you can play them\n\n" +
            "Hope you enjoy");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();            
        }
        else if (input == "clear")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Screen Cleared");
        }
        else if (input == "exit" || input == "quit")
        {
            Terminal.WriteLine("Out");
            Application.Quit();
        }        
        else if (currentScreen == Screen.Password)
        {
            menuText.gameObject.SetActive(true);
            RunPasswordAsk(input);
        }        
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3" || input == "27" || input == "94");
        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }        
        else if (input == "guide")
        {
            menuText.gameObject.SetActive(true);
            ShowGuide();
        }
        else
        {
            Terminal.WriteLine("There is no level for this number");
        }
    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            case 27:
                Terminal.WriteLine("Welcome to the area51\nWell protected place\n\n");
                password = level27passwords[Random.Range(0, level27passwords.Length)];
                break;
            case 94:
                Terminal.WriteLine("Hello master,\nYou hacked the game eventually\n\n");
                password = level94passwords[Random.Range(0, level94passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number!");
                break;
        }
    }
    void AskForPassword()
    {
        menuText.gameObject.SetActive(true);
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
    }
    void RunPasswordAsk(string input)
    {
        menuText.gameObject.SetActive(true);
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowWinReward();
    }

    void ShowWinReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Personal Computer's user crying now...");
                Terminal.WriteLine(@"
    /------@------\
    |     You     |
    |   Hacked    |
    |    Loser    |
    |  ^-^    :p  |
    \_____________/
          ||
         ----
");
                break;
            case 2:
                Terminal.WriteLine("You force the company bankrupt...");
                Terminal.WriteLine(@"
     _________________
   ||Soory we're close||              
   ||_|_|_|_|_|_|_|_|_||
   ||_|_|_|_|_|_|_|_|_||
   ||_|_|_|_|_|_|_|_|_||
   ||_|_|_|_|_|_|_|_|_||
   \________(_)________/
");
                break;
            case 3:
                Terminal.WriteLine("Government fall down, people shocked");
                Terminal.WriteLine(@"
     _____________________________
    |Flash News: Dear citizens(TV)|
    |our government collapsed,    |
    |their dirty secrets revealed |
    |as we know they run out the  |
    |country.Hope that we'll be ok|
    -------------------------------
    ||||||||||||||-@-||||||||||||||
"               );
                break;
            case 27:
                Terminal.WriteLine(@"You made it, congrats to you
but police found you
when you stole some alien info
 _______      _______  
/  ___  \----/  ___  \  
\ |___| /----\ |___| /
 \_____/      \_____/
"               );
                break;
            case 94:
                Terminal.WriteLine(@"Game beaten, thanks to you.
You were hero for today!
Your friend throw a party.
         ____     \\\///
       //    \\    \\//
      // KING \\    ||
     //        \\   ||
    ((__________))  ||
"               );
                break;
        }
    }
}
