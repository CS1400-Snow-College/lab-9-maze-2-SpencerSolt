//Spencer Solt, 11/5/25, Lab 9 - Maze #2
Console.WriteLine("The goal is to move around using the arrow keys to get to the end of the maze '#' after collecting 10 coins '^' to open the gate '|' and avoiding the bad guys '%'. There are gems '$' for bonus points.");

//Loads the contents of the file to be saved on a variable to be printed
string[] mapRows = File.ReadAllLines("C:/Users/spenc/Desktop/Labs/lab-9-maze-2-SpencerSolt/map.txt");

//Keeps the description of the program and doesn't start the stopwatch until the user is done reading
Console.Write("Press any key to continue ");
Console.ReadKey(true);

//Clears the screen then displays the maze
Console.Clear();
for (int i = 0; i < mapRows.Count(); i++)
    Console.WriteLine(mapRows[i]);

//Movement control method, the parameter stops the user from typing text
ConsoleKey TryMove(ConsoleKey button, int mazeHeight, int mazeLength)
{
    //Compares the user input to move the cursor in the correct direction
    if (button is ConsoleKey.DownArrow && Console.CursorTop < Console.BufferHeight && Console.CursorTop < mazeHeight)
        Console.CursorTop++;
    else if (button is ConsoleKey.UpArrow && Console.CursorTop > 0)
        Console.CursorTop--;
    else if (button is ConsoleKey.LeftArrow && Console.CursorLeft > 0)
        Console.CursorLeft--;
    else if (button is ConsoleKey.RightArrow && Console.CursorLeft < Console.BufferWidth && Console.CursorLeft < mazeLength)
        Console.CursorLeft++;
    //Returns the user input so the 'do-while' loop can check it
    return button;
}

//Puts the cursor in the correct starting position
Console.SetCursorPosition(0, 0);

//Enumerable so the while loop can check the user input for ConsoleKey.Escape
ConsoleKey key;

//Variables for maze height and width
int mazeBottom = mapRows.Count() - 1;
int mazeRight = mapRows[Console.CursorTop].Length - 1;

//Variable for the lose to exit the loop
bool lose = false;

//Variable for the score
int score = 0;

//Variables to detect what direction the bad guys should be moving (False:Left  True:Right)
/*bool badGuyTopDirection = true;
bool badGuyBottomDirection = false;
int badGuyTopSpot = 14;
int badGuyBottomSpot = 37;
string badGuyTop;
string badGuyBottom;*/

//Loop to keep the program running until the escape key is pressed
do
{
    //Decides what direction/position the badguys go 
    /*if (badGuyTopDirection == true)
    {
        badGuyTopSpot++;
        badGuyTop = mapRows[5].Substring(badGuyTopSpot, badGuyTopSpot) + "%" + mapRows[5].Substring(badGuyTopSpot + 1, badGuyTopSpot - 1);
        mapRows[5] = badGuyTop;
        if (badGuyTopSpot == 42)
            badGuyTopDirection = false;
    }
    else
    {
        badGuyTopSpot--;
        badGuyTop = mapRows[5].Substring(badGuyTopSpot - 1, badGuyTopSpot - 1) + "%" + mapRows[5].Substring(badGuyTopSpot, badGuyTopSpot);
        mapRows[5] = badGuyTop;
        if (badGuyTopSpot == 10)
            badGuyTopDirection = true;
    }
    if (badGuyBottomDirection == true)
    {
        badGuyBottomSpot++;
        badGuyBottom = mapRows[15].Substring(badGuyBottomSpot, badGuyBottomSpot) + "%" + mapRows[15].Substring(badGuyBottomSpot + 1, badGuyBottomSpot-1);
        mapRows[15] = badGuyBottom;
        if (badGuyBottomSpot == 42)
            badGuyBottomDirection = false;
    }
    else
    {
        badGuyBottomSpot--;
        badGuyBottom = mapRows[15].Substring(badGuyBottomSpot - 1, badGuyBottomSpot - 1) + "%" + mapRows[15].Substring(badGuyBottomSpot, badGuyBottomSpot);
        mapRows[15] = badGuyBottom;
        if (badGuyBottomSpot == 10)
            badGuyBottomDirection = true;
    }
*/

    //Score for collecting coins
    if (mapRows[Console.CursorTop].Substring(Console.CursorLeft, 1).Contains("^"))
    {
        //Add a way to remove the coins
        score = score + 100;
    }

    //Score for collecting gems
    else if (mapRows[Console.CursorTop].Substring(Console.CursorLeft, 1).Contains("$"))
    {
        //Add a way to remove the gems
        score = score + 200;
    }

    //Removes the gate if score reaches 1000
    if (score >= 1000)
    {
        //Add a way to delete the gate
    }
    
    //Changes the lose condition to true when the current cell contains '%' and gets the time to complete the maze
    if (mapRows[Console.CursorTop].Substring(Console.CursorLeft, 1).Contains("%"))
    {
        lose = true;
        break;
    }
    key = TryMove(Console.ReadKey(true).Key, mazeBottom, mazeRight);
}
while (key != ConsoleKey.Escape || lose == true);
Console.Clear();
if (lose == true)
    Console.WriteLine("You Lose");

Console.WriteLine($"Your Score: {score}");