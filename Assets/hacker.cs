using UnityEngine;

public class hacker : MonoBehaviour
{
    int level;
    string menuhint = "type menu to get back to mainmenu";
    string[] pass_1= { "engineer", "graduate", "computer", "students" };
    string[] pass_2 = { "trending", "connect", "marketing", "privacy" };
    string[] pass_3 = { "assassins", "teamwork", "respawn", "battlefield"};
    string pass;
    enum screen {mainmenu,password,win};
    screen currentscreen = screen.mainmenu;

    // Start is called before the first frame update
    void Start()
    {
        showmenu();
    }

    void showmenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("HACKING...");
        Terminal.WriteLine("which server you want to hack? \n");
        Terminal.WriteLine("1.hack college server");
        Terminal.WriteLine("2.hack facebook");
        Terminal.WriteLine("3.hack CSGO game \n");
        Terminal.WriteLine("type exit to close the game");
        Terminal.WriteLine("enter your option to begin...");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showmenu();
            currentscreen = screen.mainmenu;
        }
        else if(input=="exit")
        {
            Terminal.WriteLine("if in web close the TAB");
            Application.Quit();
        }
        else if(currentscreen==screen.mainmenu)
        {
            runmainmenu(input);
        }
        else if(currentscreen==screen.password)
        {
            checkpassword(input);
        }
    }

    void runmainmenu(string input)
    {
        bool isvalidinput = (input == "1" || input == "2" || input == "3");
        if(isvalidinput)
        {
            level = int.Parse(input);
            startgame();
        }
        else
        {
            Terminal.WriteLine("enter a valid input");
            Terminal.WriteLine(menuhint);
        }
    }

    void startgame()
    {
        currentscreen = screen.password;
        Terminal.ClearScreen();
        Terminal.WriteLine("you have chosen level:" + level);
        askpassword();
    }
     void askpassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, pass_1.Length);
                pass = pass_1[index1];
                break;
            case 2:
                int index2 = Random.Range(0, pass_2.Length);
                pass = pass_2[index2];
                break;
            case 3:
                int index3 = Random.Range(0, pass_3.Length);
                pass = pass_3[index3];
                break;
        }
        Terminal.WriteLine("enter the password,HINT:" + pass.Anagram());
    }

    void checkpassword(string input)
    {
        if (input == pass)
        {
            winscreen();
        }
        else
        {
            Terminal.ClearScreen();
            askpassword();
        }
    }
     void winscreen()
    {
        currentscreen = screen.win;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuhint);
        Terminal.WriteLine("you have hacked into system");
        switch(level)
        {
            case 1:
                Terminal.WriteLine("\n grades changed");
                Terminal.WriteLine(@"
 ________
|   _  + |
|  /_\   |       
| /   \  |
|________|
");
                break;
            case 2:
                Terminal.WriteLine("\n privacy stolen");
                Terminal.WriteLine(@"
   _____  
  | 0 0 |
  \  *  /
   \###/
   HACKED 
");
                break;
            case 3:
                Terminal.WriteLine(" \n immortal power");
                Terminal.WriteLine(@"
 ________________
|________________| . . .   
|   |__(_| 
|___|
");
                break;
        }
    }

}
