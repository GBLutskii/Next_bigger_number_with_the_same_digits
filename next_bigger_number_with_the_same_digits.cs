using System;
using System.Collections.Generic;

public class Kata
{
    public static long NextBiggerNumber(long givenNumber)
    {
        List<int> restDigits = new List<int>();
        List<int> handledDigits = new List<int>();
        int tempDigit, stopDigit, nextBiggerDigit, index;
        long result = 0;

        if (givenNumber < 10) { result = -1; }
        else
        {
            while (givenNumber > 0) // creating a list of digits from given number
            {
                restDigits.Add(Convert.ToInt32(givenNumber % 10));
                givenNumber = (givenNumber - givenNumber % 10) / 10;
            }

            tempDigit = restDigits[0];
            handledDigits.Add(tempDigit);

            // since we have to find not ANY bigger number but the next one bigger number, from my point of view the way is to find 
            // higher rank digit with less value (ex.: value of hundreds is less than value of dozens). At the same time I have to 
            // check is such a number exists at all (ex.: number 54321 doesn't have bigger brother with the same digits).
            for (int i = 1; i < restDigits.Count; i++)
            {
                handledDigits.Add(restDigits[i]);
                if (restDigits[i] < tempDigit) { break; }
                else if (restDigits[i] >= tempDigit && i < restDigits.Count - 1) { tempDigit = restDigits[i]; }
                else if (restDigits[i] >= tempDigit && i == restDigits.Count - 1) { result = -1; }
            }
        }

        if (result != -1) // after I got desired digit I have to switch it with the next one in line of ascending values
        {
            for (int i = 0; i < handledDigits.Count; i++) { restDigits.Remove(handledDigits[i]); }
            stopDigit = handledDigits[handledDigits.Count - 1];
            handledDigits.Sort();

            index = handledDigits.IndexOf(stopDigit) + 1;
            nextBiggerDigit = handledDigits[index];
            while (nextBiggerDigit == stopDigit) { index++; nextBiggerDigit = handledDigits[index]; }

            handledDigits.Remove(nextBiggerDigit);
            restDigits.Reverse();
            // then assemble all the digits into a new number 
            result = Convert.ToInt64(string.Join("", restDigits) + nextBiggerDigit.ToString() + string.Join("", handledDigits));
        }

        return result;
    }
}