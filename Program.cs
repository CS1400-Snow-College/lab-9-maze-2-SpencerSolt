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
ConsoleKey TryMove(ConsoleKey button)
{
    //Compares the user input to move the cursor in the correct direction
    if (button is ConsoleKey.DownArrow)
        Console.CursorTop++;
    else if (button is ConsoleKey.UpArrow)
        Console.CursorTop--;
    else if (button is ConsoleKey.LeftArrow)
        Console.CursorLeft--;
    else if (button is ConsoleKey.RightArrow)
        Console.CursorLeft++;
    //Returns the user input so the 'do-while' loop can check it
    return button;
}

//Puts the cursor in the correct starting position
Console.SetCursorPosition(0, 0);

//Enumerable so the while loop can check the user input for ConsoleKey.Escape
ConsoleKey key;

//Loop to keep the program running until the escape key is pressed
do
{
    key = TryMove(Console.ReadKey(true).Key);
}
while (key != ConsoleKey.Escape);