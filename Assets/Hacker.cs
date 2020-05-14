// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game configuration data
    const string menuHint = "Type 'menu' to return to start.";
    string[] level1Passwords = { "grades", "students", "curriculum", "honors", "teachers", "attendance" };
    string[] level2Passwords = { "hoses", "fire", "dalmatian", "firehydrant", "extinguisher", "rescue" };
    string[] level3Passwords = { "prisoner", "isolation", "fence", "sentence", "confinement", "punishment" }; 

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        print(level1Passwords[0]);
         ShowMainMenu();
    }

    void ShowMainMenu() {

        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What do you want to hack into?");
        Terminal.WriteLine("Press 1 for the local school");
        Terminal.WriteLine("Press 2 for the fire station");
        Terminal.WriteLine("Press 3 for the county jail");
        Terminal.WriteLine("Please select:");
    }


    void OnUserInput(string input) 
    {

        if (input =="menu") //we can always go direct to main menu
        {
            ShowMainMenu();
        } 
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        
        
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level Mr.Bond!");
        }
        else 
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
        
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
       SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
         switch(level)
        {
            case 1:
                password = level1Passwords[ Random.Range (0, level1Passwords.Length) ];
                break;
            case 2:
                password = level2Passwords[ Random.Range (0, level2Passwords.Length) ];
                break;
            case 3:
                password = level3Passwords[ Random.Range (0, level3Passwords.Length) ];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    } 

    void CheckPassword(string input)
    {
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
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
            Terminal.WriteLine("Have a book!");
            Terminal.WriteLine(@"
    ___________
   /          / /
  /          / /
 /_________ / /        
(__________( /
"           );
            break;

            case 2:
            Terminal.WriteLine("Have a firetruck!");
            Terminal.WriteLine(@"
________________________
\__\_\_\_\_\_\_\_\_\_\__\
   _|__|       |=|=|=|   |
  |0 \ /  12             |
  |_( )__________( )_( )_|
"           );
            break;

            case 3:
            Terminal.WriteLine("Have some handcuffs!");
            Terminal.WriteLine(@"
  ____      _____
//    \\~~~//    \\
\\____//```\\____//
"           );
            break;
        
        default:
            Debug.LogError("Invalid level");
            break;
        }
    
    }

}
