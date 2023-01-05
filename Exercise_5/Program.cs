int[,] fourOnFourArray = new int[4, 4];
Fill2DArray(fourOnFourArray);
Print2DArray(fourOnFourArray);


void Print2DArray(int[,] array)
{
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}


void Fill2DArray(int[,] array)
{
    int startNumber = 1;
    int i = 0;
    int j = 0;
    for (j = 0; j < 3; j++)
    {
        array[i, j] = startNumber;
        startNumber++;
    }
    for (i = 0; i < 3; i++)
    {
        array[i, j] = startNumber;
        startNumber++;
    }
    for (j = 3; j > 0; j--)
    {
        array[i, j] = startNumber;
        startNumber++;
    }
    for (i = 3; i > 1; i--)
    {
        array[i, j] = startNumber;
        startNumber++;
    }
    for (j = 0; j < 2; j++)
    {
        array[i, j] = startNumber;
        startNumber++;
    }
    for (i = 1; i < 2; i++)
    {
        array[i, j] = startNumber;
        startNumber++;
    }
    for (j = 2; j > 0; j--)
    {
        array[i, j] = startNumber;
        startNumber++;
    }
}