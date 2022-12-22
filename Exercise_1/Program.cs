TestingCreateOrderedTwoDimArray();

uint numberOfRows;
try
{
    numberOfRows = GetNumber("Enter number of rows: ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint numberOfColumns;
try
{
    numberOfColumns = GetNumber("Enter number of columns: ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

int[,] twoDimArray = new int[numberOfRows, numberOfColumns];
Fill2DArray(twoDimArray);
Print2DArray(twoDimArray);
Console.WriteLine();
int[,] orderedTwoDimArray = CreateOrderedTwoDimArray(twoDimArray);
Print2DArray(orderedTwoDimArray);



void TestingCreateOrderedTwoDimArray()
{
    Console.WriteLine("Testing of the \"TestingCreateOrderedTwoDimArray\" method has been launched... ");
    int[,] testTwoDimArray = { { 1, 5, 2, 6 }, { 7, 9, 8, 3 }, { 4, 9, 4, 5 } };
    int[,] expectedOrderedTwoDimArray = { { 6, 5, 2, 1 }, { 9, 8, 7, 3 }, { 9, 5, 4, 4 } };
    int[,] actualOrderedTwoDimArray = CreateOrderedTwoDimArray(testTwoDimArray);
    bool sequenceEqual = SequenceEqual(expectedOrderedTwoDimArray, actualOrderedTwoDimArray);
    if (sequenceEqual)
    {
        Console.WriteLine("Test completed successfully!");
    }
    else
    {
        Console.WriteLine("Error! Need to fix the method!");
    }
    Console.WriteLine();
}



bool SequenceEqual(int[,] expectedTwoDimArray, int[,] actualTwoDimArray)
{
    int count = 0;
    if (expectedTwoDimArray.GetLength(0) == actualTwoDimArray.GetLength(0)
    && expectedTwoDimArray.GetLength(1) == actualTwoDimArray.GetLength(1))
    {
        for (int i = 0; i < expectedTwoDimArray.GetLength(0); i++)
        {
            for (int j = 0; j < expectedTwoDimArray.GetLength(1); j++)
            {
                if (expectedTwoDimArray[i, j] == actualTwoDimArray[i, j])
                {
                    count++;
                }
            }
        }
    }
    if (count == (actualTwoDimArray.GetLength(0)) * actualTwoDimArray.GetLength(1))
    {
        return true;
    }
    else
    {
        return false;
    }
}



int[,] CreateOrderedTwoDimArray(int[,] array)
{
    int[,] orderedArray = array;
    for (int i = 0; i < orderedArray.GetLength(0); i++)
    {
        for (int j = 0; j < orderedArray.GetLength(1); j++)
        {
            for (int k = 0; k < orderedArray.GetLength(1) - 1; k++)
            {
                if (orderedArray[i, k] < orderedArray[i, k + 1])
                {
                    int temp = orderedArray[i, k + 1];
                    orderedArray[i, k + 1] = orderedArray[i, k];
                    orderedArray[i, k] = temp;
                }
            }
        }
    }
    return orderedArray;
}


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



void Fill2DArray(int [,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = random.Next(1, 10);
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