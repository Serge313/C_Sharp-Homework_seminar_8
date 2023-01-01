uint numberOfRows;
try
{
    numberOfRows = GetNumber("Enter number of rows: ");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint numberOfColumns;
try
{
    numberOfColumns = GetNumber("Enter number of columns: ");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint numberOfTubes;
try
{
    numberOfTubes = GetNumber("Enter number of tubes: ");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

int[,,] threeDimArray = new int[numberOfRows, numberOfColumns, numberOfTubes];
Fill3DArray(threeDimArray);
Print3DArray(threeDimArray);
Sort3DArray(threeDimArray);
Print3DArray(threeDimArray);



void Print3DArray(int[,,] array)
{
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.WriteLine($"{array[i, j, k]} ({i}, {j}, {k}) ");
            }
        }
    }
}



void Sort3DArray(int[,,] array)
{
    int countEquals = 0;
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                for (int x = 0; x < array.GetLength(0); x++)
                {
                    for (int y = 0; y < array.GetLength(1); y++)
                    {
                        for (int z = 0; z < array.GetLength(2); z++)
                        {
                            int tmp = array[i, j, k];
                            if (array[x, y, z] == tmp)
                            {
                                countEquals += 1;
                                if (countEquals > 1)
                                {
                                    array[x, y, z] = random.Next(10,100);
                                }
                            }
                        }
                    }
                }
                countEquals = 0;
            }
        }
    }
}



void Fill3DArray(int[,,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = random.Next(10, 100);
            }
        }
    }
}



uint GetNumber(string message)
{
    Console.Write(message);
    bool isParsed = uint.TryParse(Console.ReadLine(), out uint number);
    if (isParsed && number > 1)
    {
        return number;
    }
    else
    {
        throw new FormatException("Invalid value entered!");
    }
}