TestingFindSmallestSumOfNumbersInRow();

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

uint numberOfColumns = (numberOfRows - 1);

int[,] twoDimArray = new int[numberOfRows, numberOfColumns];
Fill2DArray(twoDimArray);
Print2DArray(twoDimArray);
int minRow = FindSmallestSumOfNumbersInRow(twoDimArray);
Console.WriteLine();
Console.WriteLine($"{minRow} row.");



void TestingFindSmallestSumOfNumbersInRow()
{
    Console.WriteLine("Testing of the \"TestingFindSmallestSumOfNumbersInRow\" method has been launched... ");
    int[,] testTwoDimArray = new int[,] {{5, 9, 2, 3}, {8, 4, 2, 4}, {1, 4, 7, 2}, {5, 2, 6, 7}};
    int expected = 3;
    int actual = FindSmallestSumOfNumbersInRow(testTwoDimArray);
    bool isEqual = expected == actual;
    if (isEqual)
    {
        Console.WriteLine("Test completed successfully!");
    }
    else
    {
        Console.WriteLine("Error! Need to fix the method!");
    }
    Console.WriteLine();
}



int FindSmallestSumOfNumbersInRow(int[,] twoDimArray)
{
    int sum = 0;
    int minSum = int.MaxValue;
    int count = 0;
    int minRow = 0;
    for (int i = 0; i < twoDimArray.GetLength(0); i++)
    {
        for (int j = 0; j < twoDimArray.GetLength(1); j++)
        {
            sum += twoDimArray[i, j];
        }
        count++;
        if (minSum >= sum)
        {
            minSum = sum;
            minRow = count;
        }
        sum = 0;
    }
    return minRow;
}



void Print2DArray(int [,] array)
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