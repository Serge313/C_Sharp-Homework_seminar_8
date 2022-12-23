TestingProductOfMatrices();

uint firstTwoDimArrayNumberOfRows;
try
{
    firstTwoDimArrayNumberOfRows = GetNumber("Enter first array's number of rows: ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint firstTwoDimArrayNumberOfColumns;
try
{
    firstTwoDimArrayNumberOfColumns = GetNumber("Enter first array's number of columns: ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}


uint secondTwoDimArrayNumberOfRows = firstTwoDimArrayNumberOfColumns;

uint secondTwoDimArrayNumberOfColumns;
try
{
    secondTwoDimArrayNumberOfColumns = GetNumber("Enter second array's number of columns: ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

int[,] firstTwoDimArray = new int[firstTwoDimArrayNumberOfRows, firstTwoDimArrayNumberOfColumns];
Fill2DArray(firstTwoDimArray);
Print2DArray(firstTwoDimArray);

int[,] secondTwoDimArray = new int [secondTwoDimArrayNumberOfRows, secondTwoDimArrayNumberOfColumns];
Fill2DArray(secondTwoDimArray);
Print2DArray(secondTwoDimArray);

int[,] productOfTwoDimArrays = ProductOfMatrices(firstTwoDimArray, secondTwoDimArray);
Print2DArray(productOfTwoDimArrays);



void TestingProductOfMatrices()
{
    Console.WriteLine("Testing of the \"ProductOfMatrices\" method has been launched... ");
    int[,] testArray1 = {{2, 4}, {3, 2}};
    int[,] testArray2 = {{3, 4}, {3, 3}};
    int[,] expected = {{18, 20}, {15, 18}};
    int[,] actual = ProductOfMatrices(testArray1, testArray2);
    bool sequenceEqual = SequenceEqual(expected, actual);
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



int[,] ProductOfMatrices(int[,] array1, int[,] array2)
{
    int[,] productOfTwoDimArrays = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array2.GetLength(0); k++)
            {
                productOfTwoDimArrays[i, j] += array1[i, k] * array2[k, j];
            }
        }
    }
    return productOfTwoDimArrays;
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