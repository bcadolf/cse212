using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        /* Plan: 
        1. create an array of double with the capacity of 'length'
        2. use a for loop to interate from 0 to length
        3. multiply the number by the index + 1 
        4. return array
        */
        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }


        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        /* Plan:
        1. set count and normalized amount variables
        2. use GetRange to get the first and last 'amounts' in the list
        3. clear the original list and add the ending 'amount' first the the beginning 'amount' second
        */

        int count = data.Count;

        int amountNorm = amount % count;

        List<int> endToFront = data.GetRange(count - amountNorm, amountNorm);
        List<int> frontToEnd = data.GetRange(0, count - amountNorm);

        data.Clear();
        data.AddRange(endToFront);
        data.AddRange(frontToEnd);
    }
}
