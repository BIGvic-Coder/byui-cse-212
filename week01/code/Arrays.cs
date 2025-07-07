public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of type double and size 'length'
        // 2. Use a for loop from 0 to length - 1
        // 3. For each index i, assign array[i] = number * (i + 1)
        // 4. Return the array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3,
    /// the result will be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Find the total count of the list (data.Count)
        // 2. Use GetRange to get the last 'amount' elements from the end of the list
        // 3. Remove those 'amount' elements from the end
        // 4. Insert that range at the beginning using InsertRange(0, ...)
        
        int count = data.Count;
        List<int> tail = data.GetRange(count - amount, amount);
        data.RemoveRange(count - amount, amount);
        data.InsertRange(0, tail);
    }
}
