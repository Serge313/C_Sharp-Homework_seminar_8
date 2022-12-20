int[,] twoDimensionalArray = {{1, 5, 2, 6}, {7, 9, 8, 3}, {4, 9, 4, 5}};
Print2DArray(twoDimensionalArray);
Console.WriteLine();
int[,] orderedArray = CreateOrderedArray(twoDimensionalArray);
Print2DArray(orderedArray);

int[,] CreateOrderedArray(int[,] array)
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
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}