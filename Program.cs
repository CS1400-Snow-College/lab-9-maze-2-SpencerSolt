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