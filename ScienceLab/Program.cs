using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ScienceLab
{

    class Program
    {

        public static int NthNumberInFibonacci(int index)
        {


            int current = 1;
            int previous = 0;
            int sum = 0;

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(previous);
                sum = previous + current;
                previous = current;
                current = sum;
            }

            return sum;
        }

        static int diagonalDifference(int[][] a)
        {

            int suma = 0;
            int sumb = 0;
            int index = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                suma += a[i][index];
                index++;
            }

            for (int i = 0; i < a.GetLength(0); i++)
            {

                index--;
                sumb += a[i][index];
            }

            return Math.Abs(suma - sumb);
        }

        static void plusMinus(int[] arr)
        {

            float positiveNums = 0;
            float negativeNums = 0;
            float zeros = 0;

            foreach (int number in arr)
            {
                if (number > 0)
                {
                    positiveNums++;
                }
                else if (number < 0)
                {
                    negativeNums++;
                }
                else
                {
                    zeros++;
                }
            }

            Console.WriteLine(positiveNums / arr.Length);
            Console.WriteLine(negativeNums / arr.Length);
            Console.WriteLine(zeros / arr.Length);
        }

        static void staircase(int n)
        {
            string outputString = "";

            for (int i = 0; i < n; i++)
            {
                outputString = "";

                for (int j = i; j < n; j++)
                {
                    outputString += " ";
                }

                for (int j = 0; j <= i; j++)
                {
                    outputString += "#";
                }

                Console.WriteLine(outputString);
            }
        }

        static void miniMaxSum(int[] arr)
        {
            long[] sums = new long[arr.Length];
            int skipIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                long sum = 0;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != skipIndex)
                    {
                        sum += arr[j];
                    }
                }

                skipIndex++;
                sums[i] = sum;
            }

            bool swapping = true;
            int k = 0;
            long temp;

            while (swapping)
            {
                swapping = false;

                for (k = 0; k < sums.Length - 1; k++)
                {

                    if (sums[k] < sums[k + 1])
                    {

                        temp = sums[k];
                        sums[k] = sums[k + 1];
                        sums[k + 1] = temp;
                        swapping = true;
                    }
                }
            }

            long highest = sums[0];
            long lowest = sums[sums.Length - 1];
            Console.WriteLine(lowest + " " + highest);
        }

        static int birthdayCakeCandles(int n, int[] ar)
        {
            int sum = 0;

            int highest = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > highest)
                {
                    highest = ar[i];
                }
            }

            //bool swapping = true;
            //int k = 0;
            //int temp;

            //while (swapping)
            //{
            //    swapping = false;

            //    for (k = 0; k < ar.Length - 1; k++)
            //    {

            //        if (ar[k] < ar[k + 1])
            //        {

            //            temp = ar[k];
            //           ar[k] = ar[k + 1];
            //            ar[k + 1] = temp;
            //            swapping = true;
            //        }
            //    }
            //}

            //int highest = ar[0];

            for (int i = 0; i < ar.Length; i++)
            {

                if (ar[i] == highest)
                {
                    sum++;
                }
            }

            return sum;
        }

        static string timeConversion(string s)
        {
            string output = "";

            if (s.Contains("PM"))
            {

                string[] pmTime = s.Split(':');
                int militaryHour = Int32.Parse(pmTime[0]);
                if (militaryHour < 12)
                {
                    militaryHour += 12;
                }
                output += militaryHour.ToString() + ":" + pmTime[1] + ":" + pmTime[2];

                char[] pm = { 'P', 'M' };
                output = output.Trim(pm);
            }
            else
            {
                string[] amTime = s.Split(':');
                int regularHour = Int32.Parse(amTime[0]);

                if (regularHour == 12)
                {
                    regularHour = 0;
                }

                output += regularHour.ToString("D2") + ":" + amTime[1] + ":" + amTime[2];

                char[] am = { 'A', 'M' };
                output = output.Trim(am);
            }

            return output;
        }

        static int[] solve(int[] grades)
        {
            int[] returnedGrades = new int[grades.Length];

            int lowest = 35;
            int highest = 100;
            int increments = 5;
            int numberOfMultiples = ((highest - lowest) / increments) + 1;

            int[] multiplesArray = new int[numberOfMultiples];

            for (int i = 0; i < numberOfMultiples; i++)
            {
                multiplesArray[i] = lowest + (i * increments);
            }

            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] > 35)
                {
                    int nextHighestNumber = 0;

                    for (int j = 0; j < multiplesArray.Length - 1; j++)
                    {
                        if (grades[i] > multiplesArray[j])
                        {
                            nextHighestNumber = multiplesArray[j + 1];
                        }
                    }

                    if ((nextHighestNumber - grades[i]) < 3)
                    {
                        returnedGrades[i] = nextHighestNumber;
                    }
                    else
                    {
                        returnedGrades[i] = grades[i];
                    }
                }
                else
                {
                    returnedGrades[i] = grades[i];
                }
            }

            return returnedGrades;

        }

        static void countApplesAndOranges(int houseX1, int houseX2, int appleTreeX, int orangeTreeX, int[] appleDistances, int[] orangeDistances)
        {
            int numberOfApplesOnHouse = 0;
            int numberOfOrangesOnHouse = 0;

            for (int i = 0; i < appleDistances.Length; i++)
            {
                int newAppleDistance = appleTreeX + appleDistances[i];
                if (newAppleDistance >= houseX1 && newAppleDistance <= houseX2) {
                    numberOfApplesOnHouse++;
                }
            }

            for (int i = 0; i < orangeDistances.Length; i++)
            {
                var newOrangeDistance = orangeTreeX + orangeDistances[i];
                if (newOrangeDistance <= houseX2 && newOrangeDistance >= houseX1) {
                    numberOfOrangesOnHouse++;
                }

            }
            Console.WriteLine(numberOfApplesOnHouse);
            Console.WriteLine(numberOfOrangesOnHouse);
        }

        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            string output = "NO";
            bool autoskip = false;
            if (((v1 > v2) && (x1 > x2)) || ((v2 > v1) && (x2 > x1)))
            {
                autoskip = true;
            }

            if (!autoskip)
            {
                bool jumping = true;
                while (jumping)
                {
                    x1 += v1;
                    x2 += v2;

                    if (x1 < 0 || x2 < 0)
                    {
                        jumping = false;
                    }

                    else if (x1 == x2)
                    {
                        output = "YES";
                        jumping = false;
                    }
                }
            }

            return output;
        }

        static int[] breakingRecords(int[] score)
        {
            int recordHigh = score[0];
            int recordLow = score[0];

            int highScores = 0;
            int lowScores = 0;

            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] > recordHigh)
                {
                    recordHigh = score[i];
                    highScores++;
                }
                else if (score[i] < recordLow)
                {
                    recordLow = score[i];
                    lowScores++;
                }
            }

            int[] output = { highScores, lowScores };

            return output;
        }

        static int solve(int n, int[] candyBar, int pieceTotalValue, int piecesInSequence)
        {
            int output = 0;

            for (int i = 0; i <= candyBar.Length - piecesInSequence; i++)
            {
                int currentSequenceTotal = 0;
                for (int j = 0; j < piecesInSequence; j++)
                {
                    currentSequenceTotal += candyBar[i + j];
                }

                if (currentSequenceTotal == pieceTotalValue)
                {
                    output++;
                }
            }

            return output;
        }

        static int migratoryBirds(int n, int[] ar)
        {
            int output = 0;

            Dictionary<int, int> populations = new Dictionary<int, int>();
            for (int i = 1; i < 6; i++)
            {
                populations.Add(i, 0);
            }

            int tempint = 0;
            foreach (int number in ar)
            {

                tempint = populations[number];
                tempint++;

                populations[number] = tempint;

            }

            tempint = 0;
            for (int i = 1; i < populations.Count + 1; i++)
            {
                if (populations[i] > tempint)
                {
                    tempint = populations[i];
                    output = i;
                }
            }

            return output;
        }

        static string solve(int year)
        {
            string output = "";

            string yearString = year.ToString();
            string monthString = "09.";
            string dayString = "13.";


            if ((year <= 1917 && year % 4 == 0) || (year > 1918 && (
                                                        (year % 400 == 0) ||
                                                        (year % 4 == 0 && year % 100 != 0)))) {

                dayString = "12.";
            }
            else if (year == 1918)
            {
                dayString = "26.";
            }

            output = dayString + monthString + yearString;

            return output;
        }

        static string bonAppetit(int n, int k, int b, int[] ar)
        {
            string output = "";

            int annaBill = b;
            int completeBill = 0;
            int actuallBill = 0;

            for (int i = 0; i < n; i++)
            {
                completeBill += ar[i];

            }

            completeBill = completeBill / 2;

            actuallBill = completeBill - (ar[k] / 2);

            if (annaBill == actuallBill)
            {
                output = "Bon Appetit";
            }
            else
            {
                output = (annaBill - actuallBill).ToString();
            }

            return output;

        }

        static int sockMerchant(int n, int[] ar)
        {
            int output = 0;

            Dictionary<int, int> socksByColor = new Dictionary<int, int>();

            for (int i = 0; i < ar.Length; i++)
            {
                if (!socksByColor.ContainsKey(ar[i]))
                {
                    socksByColor.Add(ar[i], 1);

                }
                else
                {
                    socksByColor[ar[i]]++;
                }

            }

            foreach (KeyValuePair<int, int> color in socksByColor)
            {
                //output += (int)Math.Floor((decimal)(color.Value / 2));
                output += color.Value / 2;
            }

            return output;
        }

        static int solve(int n, int p)
        {
            int output = 0;

            int startingPoint = 0;

            if (p > (float)n / 2)
            {
                startingPoint = n;
            }

            if (startingPoint == 0)
            {
                for (int i = 1; i < p; i++)
                {
                    if (i % 2 != 0)
                    {
                        output++;
                    }
                }
            }
            else
            {
                for (int i = n; i > p; i--)
                {
                    if (i % 2 == 0)
                    {
                        output++;
                    }
                }
            }

            return output;
        }

        static int countingValleys(int n, string s)
        {
            char[] upsAndDowns = s.ToCharArray();
            int height = 0;
            int numberOfValleys = 0;

            for (int i = 0; i < upsAndDowns.Length; i++)
            {
                if (upsAndDowns[i] == 'U')
                {
                    height++;
                    if (height == 0)
                    {
                        numberOfValleys++;
                    }
                }
                else
                {
                    height--;
                }
            }

            return numberOfValleys;
        }

        static int getMoneySpent(int[] keyboards, int[] drives, int s)
        {

            int mostExpensiveCombo = 0;

            for (int i = 0; i < keyboards.Length; i++)
            {
                for (int j = 0; j < drives.Length; j++)
                {
                    if (keyboards[i] + drives[j] > mostExpensiveCombo && keyboards[i] + drives[j] <= s)
                    {
                        mostExpensiveCombo = keyboards[i] + drives[j];
                    }
                }
            }

            if (mostExpensiveCombo == 0)
            {
                mostExpensiveCombo = -1;
            }
            return mostExpensiveCombo;
        }

        static string catAndMouse(int x, int y, int z)
        {
            string output;

            int catADistance = Math.Abs(x - z);
            int catBDistance = Math.Abs(y - z);

            if (catADistance < catBDistance)
            {
                output = "Cat A";
            }
            else if (catBDistance < catADistance)
            {
                output = "Cat B";
            }
            else
            {
                output = "Mouse C";
            }

            return output;
        }

        static int pickingNumbers(int[] a)
        {
            int output = 0;
            List<int> integers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                integers.Add(0);
            }

            for (int i = 0; i < a.Length; i++)
            {
                int occurance = a[i];
                integers[occurance]++;
            }

            for (int i = 0; i < integers.Count - 1; i++)
            {
                int pair = integers[i] + integers[i + 1];
                if (pair > output)
                {
                    output = pair;
                }
            }

            return output;
        }

        static int pickingNumbers2(int[] a)
        {
            List<int> map = Enumerable.Repeat(0, 100).ToList();
            for (int i = 0; i < a.Length; i++)
            {
                var key = a[i];
                map[key]++;
            }

            int maxCount = 0;
            for (int i = 0; i < map.Count - 1; i++)
            {
                var count = map[i] + map[i + 1];
                if (count > maxCount)
                    maxCount = count;
            }

            return maxCount;
        }
        static int[] climbing(int[] scores, int[] alice) {

            List<int> scoresByRank = new List<int>();
            scoresByRank.Add(scores[0]);

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < scores[i - 1])
                {
                    scoresByRank.Add(scores[i]);
                }
            }

            List<int> output = new List<int>();
            int rankIndex = scoresByRank.Count - 1;
            for (int level = 0; level < alice.Length; level++)
            {
                while (rankIndex >= 0 && alice[level] >= scoresByRank[rankIndex])
                {
                    rankIndex--;
                }

                output.Add(rankIndex + 2);
            }
            return output.ToArray();
        }

        static int[] climbing2(int[] scores, int[] alice, int n, int m)
        {
            List<int> s = new List<int>();
            s.Add(scores[0]);
            for (int i = 1; i < n; i++)
                if (scores[i] < scores[i - 1])
                    s.Add(scores[i]);
            int k = s.Count - 1;
            for (int i = 0; i < m; i++)
            {
                while (k >= 0 && alice[i] >= s[k])
                    k--;
                alice[i] = k + 2;
            }
            return alice;
        }

        static int[] climbingLeaderboard(int[] scores, int[] aliceScores)
        {

            List<int> scoresByRank = new List<int>(); //for ranks
            scoresByRank.Add(scores[0]);
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < scores[i - 1])
                {
                    scoresByRank.Add(scores[i]);
                }
            }
            List<int> aliceRanks = new List<int>();
            int rankToBeat = scoresByRank.Count - 1;
            int achievedRank = scoresByRank.Count + 1;
            for (int level = 0; level < aliceScores.Length; level++)
            {
                for (int currentRank = rankToBeat; currentRank > 0; currentRank--)
                {
                    if (aliceScores[level] >= scoresByRank[currentRank])
                    {
                        achievedRank = rankToBeat;
                        rankToBeat = currentRank - 1;

                        if (rankToBeat <= 1)
                        {
                            rankToBeat = 1;
                        }
                    }
                    else
                    {
                        currentRank = 0;
                    }
                }

                if (achievedRank == 1)
                {
                    aliceRanks.Add(achievedRank);
                }
                else
                {
                    aliceRanks.Add(achievedRank + 1);
                }

            }

            return aliceRanks.ToArray();
        }

        static int hurdleRace(int k, int[] height)
        {
            int output = 0;

            int highest = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > highest)
                {
                    highest = height[i];
                }
            }

            if (highest > k)
            {
                output = highest - k;
            }

            return output;
        }
        static int designerPdfViewer(int[] h, string word)
        {
            int output = 0;
            char[] wordToChars = word.ToArray();

            int highest = 0;
            for (int i = 0; i < wordToChars.Length; i++)
            {
                int charValue = char.ToUpper(wordToChars[i]) - 65;

                if (h[charValue] > highest)
                {
                    highest = h[charValue];
                }

            }

            output = highest * word.Length;

            return output;

        }

        static int utopianTree(int n)
        {
            int output = 1;

            if (n == 0) { }
            else
            {
                for (int i = 1; i < n + 1; i++)
                {
                    if (i % 2 != 0)
                    {
                        output *= 2;
                    }
                    else if (i % 2 == 0)
                    {
                        output += 1;
                    }
                }
            }

            return output;
        }


        static string angryProfessor(int k, int[] a)
        {
            string output = "YES";

            int lateStudentLimit = k;
            int onTimeStudents = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] <= 0)
                {
                    onTimeStudents++;
                }
            }

            if (lateStudentLimit <= onTimeStudents)
            {
                output = "NO";
            }

            return output;
        }

        static int viralAdvertising(int n)
        {
            int output = 0;
            int viewers = 5;

            for (int i = 0; i < n; i++)
            {
                viewers = (int)Math.Floor((decimal)viewers / 2);
                output += viewers;
                viewers *= 3;
            }

            return output;
        }

        static int saveThePrisoner(int prisoners, int snacks, int startingPosition)
        {
            if (snacks > prisoners)
            {
                int snackMod = (snacks % prisoners) - 1;

                if (snackMod + startingPosition > prisoners)
                {
                    int difference = prisoners - startingPosition;
                    startingPosition = snackMod - difference;
                }
                else if (snackMod == -1)
                {
                    if (startingPosition == prisoners && startingPosition != 1)
                    {
                        startingPosition--;
                    }
                    else if (startingPosition == 1)
                    {
                        startingPosition = prisoners;
                    }
                    else
                    {
                        startingPosition--;
                    }
                }
                else
                {
                    startingPosition = startingPosition + snackMod;
                }
            }
            else
            {
                if (snacks == prisoners && startingPosition == prisoners) {

                    startingPosition--;
                }
                else if (snacks + startingPosition - 1 > prisoners)
                {
                    int difference = prisoners - startingPosition; //edited this for case #3 (was adding an extra 1
                    startingPosition = snacks - difference - 1;
                }
                else
                {
                    startingPosition += snacks - 1;
                }
            }

            return startingPosition;
        }

        static void yourSolution(string[][] input)
        {
            int arrayIndex = 0;
            int maxArrayIndex = input.GetLength(0) - 1;
            int wordIndex = 0;
            int wordMax = input[arrayIndex].Length - 1;

            string output = "";

            bool testing = true;
            while (testing)
            {

                if (arrayIndex > maxArrayIndex)
                {

                    if (wordIndex == wordMax)
                    {
                        string newOutput = output + input[arrayIndex][wordIndex];
                        Console.WriteLine(newOutput);

                        maxArrayIndex--;
                        wordIndex = 0;
                        arrayIndex = 0;
                    }
                    else
                    {
                        string newOutput = output + input[arrayIndex][wordIndex];

                        Console.WriteLine(newOutput);
                        wordIndex++;
                    }
                }
                else
                {

                    output += input[arrayIndex][wordIndex];
                    arrayIndex++;
                }

                if (maxArrayIndex == 0)
                {

                    testing = false;
                }
            }
        }

        static void solutionTest(string[][] input)
        {
            int combinations = 1;
            for (int i = 0; i < input.GetLength(0); i++)
            {
                combinations *= input[i].Length;
            }

            List<string> output = new List<string>();
            for (int c = 0; c < combinations - 1; c++)
            {
                int t = c;

                for (int i = 0; i < input.GetLength(0) - 1; i++)
                {
                    int d = t % input[i].Length;
                    t = t / input[i].Length;
                    output.Add(input[i][d]);
                }

                Console.WriteLine(output);
            }
            Console.WriteLine("");
        }

        static int[] circularArrayRotation(int[] originalArray, int rotations, int[] queries)
        {
            int[] output = new int[queries.Length];

            int lengthOfOriginalArray = originalArray.Length;
            int rotationsMod = rotations % lengthOfOriginalArray;

            int[] newArray = new int[originalArray.Length];

            if (rotationsMod == 0)
            {
                newArray = originalArray;
            }
            else
            {
                int rotationsModDifference = originalArray.Length - rotationsMod;

                int[] firstHalf = new int[rotationsModDifference];

                for (int i = 0; i < rotationsModDifference; i++)
                {
                    firstHalf[i] = originalArray[i];
                }

                int[] secondHalf = new int[rotationsMod];

                for (int i = 0; i < rotationsMod; i++)
                {
                    secondHalf[i] = originalArray[rotationsModDifference + i];
                }

                newArray = secondHalf.Concat(firstHalf).ToArray();
            }

            for (int i = 0; i < queries.Length; i++)
            {
                int query = queries[i];
                output[i] = newArray[query];
            }

            return output;
        }

        static int[] permutationEquation(int[] p)
        {
            List<int> output = new List<int>();

            for (int x = 1; x < p.Length + 1; x++)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    if (x == p[i])
                    {
                        int y = i + 1;

                        for (int j = 0; j < p.Length; j++)
                        {
                            if (y == p[j])
                            {
                                output.Add(j + 1);
                            }
                        }
                    }
                }
            }

            return output.ToArray();
        }

        static int jumpingOnClouds(int[] c, int k)
        {
            int remainingEnergy = 100;

            for (int i = 0; i < c.Length; i += k)
            {
                if (c[i] == 1)
                {
                    remainingEnergy -= 3;
                }
                else
                {
                    remainingEnergy--;
                }

            }

            return remainingEnergy;
        }

        static void annoyingChallenge(string[][] words)
        {
            int[] indexes = new int[words.Length];

            while (true)
            {
                PrintOut(words, indexes);
                bool returnedToStart = Increment(words, indexes);
                if (returnedToStart)
                {
                    break;
                }
            }
        }

        static void annoyingChallenge2(string[][] words)
        {

            annoyingRecursion(words, "", 0);
        }

        static void annoyingRecursion(string[][] words, string prefix, int index)
        {
            if (index >= words.Length)
            {
                Console.WriteLine(prefix);
                return;
            }
            for (int i = 0; i < words[index].Length; ++i)
            {
                string word = words[index][i];
                string prefix2 = prefix;
                if (prefix.Length > 0)
                {
                    prefix2 = prefix2 + " ";
                }

                prefix2 = prefix2 + word;
                annoyingRecursion(words, prefix2, index + 1);
            }
        }

        static void PrintOut(string[][] words, int[] indexes)
        {
            string word = "";
            for (int i = 0; i < words.Length; ++i)
            {
                int index = indexes[i];
                word += words[i][index] + " ";

                if (i + 1 < words.Length)
                {
                    Console.WriteLine("");
                }
            }
            Console.WriteLine(word);
        }

        static bool Increment(string[][] words, int[] indexes)
        {
            int i = indexes.Length - 1;

            while (true)
            {

                if (i < 0)
                {
                    return true;
                }
                ++indexes[i];

                if (indexes[i] >= words[i].Length)
                {
                    indexes[i] = 0;
                    --i;
                }
                else
                {
                    return false;
                }
            }
        }

        static void AnnoyingChallengeFinal(string[][] array)
        {
            string output = "";

            List<int> indexCounters = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                indexCounters.Add(0);
            }

            while (true)
            {
                if (indexCounters[0] == array[0].Length)
                {
                    break;
                }
                else
                {
                    output = "";

                    for (int i = 0; i < array.Length; i++)
                    {
                        output += array[i][indexCounters[i]] + " ";
                    }

                    indexCounters[array.Length - 1]++;

                    for (int i = indexCounters.Count - 1; i > 0; i--)
                    {
                        if (indexCounters[i] == array[i].Length)
                        {
                            indexCounters[i - 1]++;
                            indexCounters[i] = 0;
                        }
                    }

                    Console.WriteLine(output);
                }
            }
        }

        static int findDigits(int n)
        {
            int output = 0;

            string number = n.ToString();
            char[] numberChars = number.ToCharArray();
            List<int> digits = new List<int>();

            for (int i = 0; i < numberChars.Length; i++)
            {
                digits.Add((int)Char.GetNumericValue(numberChars[i]));
            }

            for (int i = 0; i < digits.Count; i++)
            {
                int currentDigit = digits[i];


                if (currentDigit != 0 && n % currentDigit == 0)
                {
                    output++;
                }
            }

            return output;
        }

        static void extraLongFactorials(int n)
        {
            BigInteger bigInteger = n;

            int currentIndex = n;
            while (currentIndex > 1)
            {
                currentIndex--;
                bigInteger *= currentIndex;
            }

            Console.WriteLine(bigInteger);
        }

        static string appendAndDelete(string s, string t, int k)
        {
            string output = "No";

            if (s.Length + t.Length <= k)
            {
                output = "Yes";
            }
            else
            {
                int index = 0;

                for (; index < s.Length && index < t.Length; index++)
                {
                    if (s[index] != t[index])
                    {
                        break;
                    }
                }

                int operations = (s.Length - index) + (t.Length - index);

                if (operations <= k && (k - operations) % 2 == 0)
                {
                    output = "Yes";
                }
            }


            return output;
        }

        static int squares(int a, int b)
        {
            int numberOfSquarInts = 0;

            decimal squareRootA = (decimal)Math.Sqrt(a);
            decimal squareRootB = (decimal)Math.Sqrt(b);

            int ceilingA = (int)Math.Ceiling(squareRootA);
            int floorB = (int)Math.Floor(squareRootB);

            numberOfSquarInts = floorB - ceilingA + 1;

            return numberOfSquarInts;
        }

        static void FindPrimes()
        {
            for (int i = 0; i < 100; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        Console.WriteLine("{0} is not prime", i);
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine("{0} is prime", i);
                }
            }


        }

        static void FindSecondLargest(List<int[]> listOfArrays)
        {
            int largest = 1;
            int secondLargest = 0;

            for(int i = 0; i < listOfArrays.Count; i++)
            {

                int[] currentArray = listOfArrays[i];

                for(int j = 0; j < currentArray.Length; j++)
                {
                    if(currentArray[j] > largest)
                    {
                        secondLargest = largest;
                        largest = currentArray[j];
                    }
                }
            }

            Console.WriteLine("{0} is the largest. {1} is the second largest.", largest, secondLargest);
        }

        static void FindLargestSum(int[] array)
        {
            int largest = array[0];
            int currentSum = array[0];
            int previousNumber = array[0];

            for(int i  = 1; i < array.Length; i++)
            {
                 if(array[i] == previousNumber + 1)
                {
                    currentSum += array[i];
                    previousNumber = array[i];

                    if(currentSum > largest)
                    {
                        largest = currentSum;
                    }
                }
                else
                {
                    currentSum = array[i];
                    previousNumber = array[i];
                }
            }

            Console.WriteLine("{0} is the largest sum", largest);
        }

        static void CountLettersInString(string letters)
        {
            string output = "";
            int counter = 1;

            char[] characters = letters.ToCharArray();

            for(int i = 0; i < characters.Length -1 ; i++)
            {
                if(characters[i] == characters[i +1])
                {
                    counter++;
                }
                else
                {
                    output += (characters[i].ToString() + counter);
                    counter = 1;
                }
                if(i == characters.Length -2)
                {
                    output += characters[i + 1].ToString() + counter;
                }
            }

            Console.WriteLine(output);
        }

        private static void FindFirstNonRepeatingCharacter(string word)
        {
            char[] letters = word.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                bool hasADuplication = false;
                for (int j = i + 1; j < letters.Length; j++)
                {

                    if (letters[i] == letters[j])
                    {
                        hasADuplication = true;
                        break;
                    }
                }

                if (!hasADuplication)
                {
                    Console.WriteLine(letters[i].ToString() + " was the first non repeating character");
                    break;
                }
            }

        }

        static void IsThisARectangle(int[][] points)
        {
            Dictionary<int, int> xycoordinates = new Dictionary<int, int>();
            string output = "Is not a rectangle";

            foreach(int[] point in points)
            {
                if(!xycoordinates.ContainsKey(point[0]))
                {
                    xycoordinates.Add(point[0], 0);
                }
                else
                {
                    xycoordinates[point[0]]++;
                }
                
                if(!xycoordinates.ContainsKey(point[1]))
                {
                    xycoordinates.Add(point[1], 0);
                }
                else
                {
                    xycoordinates[point[1]]++;
                }
            }

            if(xycoordinates.Count == 2)
            {
                output = "Is a Rectangle";

                foreach(KeyValuePair<int, int> counter in xycoordinates)
                {
                    if(counter.Value != 3)
                    {
                        output = "Is not a rectangle";
                        break;
                    }
                }
            }

            Console.WriteLine(output);
        }

        static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            int output = 0;
            if(y1 > y2)
            {
                output = 10000;
            }
            else if(m1 > m2 && y1 == y2)
            {
                output = (m1 - m2) * 500;
            }
            else if(d1 > d2 && m1 == m2 && y1 == y2)
            {
                output = (d1 - d2) * 15;
            }
           
            return output;

        }

        static void cutTheSticks(int[] arr)
        {
            List<int> sticks = arr.ToList<int>();

            while(sticks.Count > 0)
            {
                int shortest = sticks[0];
                for(int i = 1; i < sticks.Count; i++)
                {
                    if(sticks[i] < shortest)
                    {
                        shortest = sticks[i];
                    }
                }

                Console.WriteLine(sticks.Count);
                for (int i = sticks.Count -1; i >= 0; i--)
                {
                    sticks[i] -= shortest;

                    if(sticks[i] <= 0)
                    {
                        sticks.Remove(sticks[i]);
                    }
                }
                if(sticks.Count == 1)
                {
                    Console.WriteLine(1);
                    break;
                }
            }
        }

        static int nonDivisibleSubset(int k, int[] arr)
        {

            int output = 0;

            int[] remainders = new int[k];

            for(int i  = 0; i < arr.Length; i++)
            {
                remainders[arr[i] % k]++;
            }

            for (int i = 0; i <= (k / 2); ++i)
            {
                if (i == 0 || i + i == k)
                {
                    if (remainders[i] > 0)
                    {
                        output = output + 1;
                    }
                }
                else
                {
                    if (remainders[i] > remainders[k - i])
                    {
                        output += remainders[i];
                    }
                    else
                    {
                        output += remainders[k - i];
                    }
                }
            }

            return output;
        }

        static void MakeSubSets(int[] arr)
        {
            for (int subSetCounter = 0; ; subSetCounter++)
            {
                string output = "{";

                List<int> ints = new List<int>();
                for(int i  = 0; i < arr.Length; i++)
                {
                    if((subSetCounter & ( 1 << i)) != 0)
                    {
                        ints.Add(arr[i]);
                    }
                }

                for(int i = 0; i < ints.Count; i++)
                {
                    output += ints[i] + ", ";
                }

                if(subSetCounter > 0 && ints.Count == 0)
                {
                    Console.WriteLine(output + "}");
                    break;
                }

                Console.WriteLine(output + "}");
            }
         
        }

        static long repeatedString(string s, long n)
        {
            long output = 0;
            char[] stringCharacters = s.ToCharArray();

            long numberOfAs = 0;

            for (int i = 0; i < stringCharacters.Length; i++)
            {
                if (stringCharacters[i] == 'a')
                {
                    numberOfAs++;
                }
            }

            if (n > stringCharacters.Length)
            {
                long numberOfChunks = n / stringCharacters.Length;
                output += numberOfAs * numberOfChunks;

                numberOfAs = 0;

                long remainingLetters = n % stringCharacters.Length;
                for (int i = 0; i < remainingLetters; i++)
                {
                    if (stringCharacters[i] == 'a')
                    {
                        numberOfAs++;
                    }
                }

                output += numberOfAs;
            }
            else
            {
                numberOfAs = 0;

                long remainingLetters = n % stringCharacters.Length;
                for (int i = 0; i < remainingLetters; i++)
                {
                    if (stringCharacters[i] == 'a')
                    {
                        numberOfAs++;
                    }
                }

                output += numberOfAs;
            }

            return output;
        }

        static int jumpingOnClouds(int[] c)
        {
            int output = 0;

            for(int i = 0; i < c.Length -1; i++)
            {
                if(c[i+1] == 1)
                {
                    i++;
                }
                else if (i+2 < c.Length && c[i + 2] != 1)
                {
                    i++;
                }
                output++;
            }

            return output;
        }

        static int equalizeArray(int[] arr)
        {
            int output = 0;

            Dictionary<int, int> values = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!values.ContainsKey(arr[i]))
                {

                    values.Add(arr[i], 1);
                }
                else
                {
                    values[arr[i]]++;
                }

            }

            int largest = 0;
            int index = 0;

            foreach (KeyValuePair<int, int> KVPair in values)
            {
                if (KVPair.Value > largest)
                {
                    largest = KVPair.Value;
                    index = KVPair.Key;
                }
            }

            foreach (KeyValuePair<int, int> KVPair in values)
            {
                if(index != KVPair.Key)
                {
                    output += KVPair.Value;
                }
            }

            return output;
        }

        public class Position{

            public int row;
            public int column;

            public Position(int row, int column) { this.row = row; this.column = column; }
        }

        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            int output = 0;

            List<Position> potentialObstacles = new List<Position>();

            //bounds up, down, left right
            Position up = new Position(n, c_q);
            Position down = new Position(1, c_q);
            Position left = new Position(r_q, 1);
            Position right = new Position(r_q, n);

            int rowcounter = r_q;
            int columncounter = c_q;
            //bounds diag
            for (columncounter = c_q ; ; columncounter--)
            {
                if(columncounter == 1 || rowcounter == n)
                {
                    break;
                }
                rowcounter++;
            }

            Position upleft = new Position(rowcounter, columncounter);

            rowcounter = r_q;
            for (columncounter = c_q; ; columncounter++)
            {
                if (columncounter == n || rowcounter == n)
                {
                    break;
                }
                rowcounter++;
            }

            Position upright = new Position(rowcounter, columncounter);

            rowcounter = r_q;
            for (columncounter = c_q; ; columncounter--)
            {
                if (columncounter == 1 || rowcounter == 1)
                {
                    break;
                }
                rowcounter--;
            }

            Position downleft = new Position(rowcounter, columncounter);

            rowcounter = r_q;
            for (columncounter = c_q; ; columncounter++)
            {
                if (columncounter == n || rowcounter == 1)
                {
                    break;
                }
                rowcounter--;
            }

            Position downright = new Position(rowcounter, columncounter);


            for (int i = 0; i < obstacles.Length; i++)
            {
                if(obstacles[i][0] == r_q)
                {
                    Position obstacle = new Position(r_q, obstacles[i][1]);
                    potentialObstacles.Add(obstacle);
                }
                else if(obstacles[i][1] == c_q)
                {
                    Position obstacle = new Position(obstacles[i][0], c_q);
                    potentialObstacles.Add(obstacle);
                }
                else
                {
                    int columndistance = Math.Abs(obstacles[i][1] - c_q);
                    int rowdistance = Math.Abs(obstacles[i][0] - r_q);
                    if(columndistance == rowdistance)
                    {
                        Position obstacle = new Position(obstacles[i][0], obstacles[i][1]);
                        potentialObstacles.Add(obstacle);
                    }
                }
            }

            for(int i = 0; i < potentialObstacles.Count; i++)
            {
                if (potentialObstacles[i].row == r_q)
                {
                    int distance = potentialObstacles[i].column - c_q;

                    //obstacle was on the right
                    if (distance > 0 && potentialObstacles[i].column <= right.column)
                    {
                        right.column = potentialObstacles[i].column -1;
                    }
                    //obstacle was on the left
                    else if(distance < 0 && potentialObstacles[i].column >= left.column)
                    {
                        left.column = potentialObstacles[i].column +1;
                    }
                }
                else if(potentialObstacles[i].column == c_q)
                {
                    int distance = potentialObstacles[i].row - r_q;

                    //obstacle was above
                    if (distance > 0 && potentialObstacles[i].row <= up.row)
                    {
                        up.row = potentialObstacles[i].row -1;
                    }
                    //obstacle was below
                    else if (distance < 0 && potentialObstacles[i].row >= down.row)
                    {
                        down.row = potentialObstacles[i].row +1;
                    }
                }
                else
                {
                    int updowndirection = potentialObstacles[i].row - r_q;
                    int leftrightdirection = potentialObstacles[i].column - c_q;

                    if(updowndirection > 0)
                    {
                        if(leftrightdirection < 0)
                        {
                            if(potentialObstacles[i].column >=  upleft.column)
                            {
                                upleft.column = potentialObstacles[i].column +1;
                            }
                        }
                        else
                        {
                            if(potentialObstacles[i].column <= upright.column)
                            {

                                upright.column = potentialObstacles[i].column -1;
                            }
                        }
                    }
                    else {

                        if (leftrightdirection < 0)
                        {
                            if (potentialObstacles[i].column >= downleft.column)
                            {
                                downleft.column = potentialObstacles[i].column +1;
                            }
                        }
                        else
                        {
                            if (potentialObstacles[i].column <= downright.column)
                            {
                                downright.column = potentialObstacles[i].column -1;
                            }
                        }
                    }
                }
            }
      
            output += Math.Abs(left.column - c_q);
            output += Math.Abs(upleft.column - c_q);
            output += Math.Abs(up.row - r_q);
            output += Math.Abs(upright.column - c_q);
            output += Math.Abs(right.column - c_q);
            output += Math.Abs(downright.column - c_q);
            output += Math.Abs(down.row - r_q);
            output += Math.Abs(downleft.column - c_q);

            return output;

        }


        static int[] acmTeam(string[] teamMembers)
        {
            int[] output = { 0, 0 };
            int maxknownTopics = 0;

            Dictionary<int, List<int>> teamDictionary = new Dictionary<int, List<int>>();

            for (int i = 0; i < teamMembers.Length; i++)
            {
                List<int> ints = new List<int>();

                char[] topics = teamMembers[i].ToCharArray();

                for (int j = 0; j < topics.Length; j++)
                {
                    ints.Add((int)Char.GetNumericValue(topics[j]));
                }

                teamDictionary.Add(i, ints);
            }

            Dictionary<int, int> maxNumberCombos = new Dictionary<int, int>();

            for (int i = 0; i < teamDictionary.Count; i++)
            {
                
                for(int j = i + 1; j <= teamDictionary.Count - 1; j++)
                {
                    int topicCounter = 0;
                    int numberOfTopics = teamDictionary[i].Count;

                    for(int k = 0; k < numberOfTopics; k++)
                    {
                        if((teamDictionary[i][k] | teamDictionary[j][k]) != 0)
                        {
                            topicCounter++;
                        }

                        if (topicCounter >= maxknownTopics)
                        {
                            maxknownTopics = topicCounter;

                            if (!maxNumberCombos.ContainsKey(maxknownTopics))
                            {
                                maxNumberCombos.Add(maxknownTopics, 1);
                            }
                            else
                            {
                                maxNumberCombos[maxknownTopics]++;
                            }
                        }
                    }
                }
            }

            foreach(KeyValuePair<int, int> pairs in maxNumberCombos)
            {
                if(pairs.Key == maxknownTopics)
                {
                    output[1] = pairs.Value;
                }
            }

            output[0] = maxknownTopics;

            return output;
        }

        static BigInteger taumBday(long blackItem, long whiteItem, long blackItemCost, long whiteItemCost, long conversionCost)
        {
            BigInteger output = 0;

            if((blackItem * blackItemCost) > (blackItem * whiteItemCost) + (blackItem * conversionCost))
            {
                output += blackItem * whiteItemCost;
                output += blackItem * conversionCost;
                output += whiteItem * whiteItemCost;
            }
            else if((whiteItem * whiteItemCost) > (whiteItem * blackItemCost) + (whiteItem * conversionCost))
            {
                output += whiteItem * blackItemCost;
                output += whiteItem * conversionCost;
                output += blackItem * blackItemCost;
            }
            else
            {
                output += whiteItem * whiteItemCost;
                output += blackItem * blackItemCost;
            }

            return output;
        }

        static string organizingContainers(long[][] container)
        {
            string output = "Possible";

            //after digging around in teh discussions I learned that the container sizes aren't equal as the problem details imply
            //this adds an extra step. 
            //old; 1) tally type sizes 2) determine if type sizes are equal. if not-> impossible
            //new; 1) tally type sizes 2) tally container sizes 3) determine if type sizes equal container sizes . if not -> impossible

            //count all the types sizes and container sizes
            long[] typeCounters = new long[container[0].Length];
            long[] containerSizes = new long[container[0].Length];

            for (int i = 0; i < container.Length; i++)
            {
                for (int j = 0; j < container[0].Length; j++)
                {
                    typeCounters[j] += container[i][j];
                }
            }
            //this could probably be done in the loop above. doing it here for clarity/debugging if necessary
            for(int i = 0; i < container.Length; i++)
            {
                for(int j = 0; j < container[0].Length; j++)
                {
                    containerSizes[i] += container[i][j];
                }
            }
            Array.Sort(typeCounters);
            Array.Sort(containerSizes);
            //see if the container size and corresponding type size are equal
            for (int i = 0; i < container.Length; i++)
            {
                if (typeCounters[i] != containerSizes[i])
                {
                    return "Impossible";
                }
            }

            return output;
        }

        static string encryption(string s)
        {
            string output ="";

            //get rid of the spaces in original string
            string sMinusSpaces = s.Replace(" ", string.Empty);
            //math described in problem statement
            double sqrtS = Math.Sqrt(sMinusSpaces.Length);
            int rows = (int)Math.Floor((decimal)sqrtS);
            int columns = (int)Math.Ceiling((decimal)sqrtS);

            List<string> subStrings = new List<string>();

            //break the string into substrings 
            //use an external number to hold our place and extract letters as we iterate
            int iterator = 0;
            for(int i = 0; i <= rows; i++)
            {
                string subString = "";

                for (int j = 0; j < columns; j++)
                {
                    if (iterator < sMinusSpaces.Length)
                    {
                        subString += sMinusSpaces[iterator];
                        iterator++;
                    }
                    else
                    {
                        break;
                    }
                    
                }

                subStrings.Add(subString);
            }

            //go through our substrings and start copying letters to our output string
            // iterator is reset and used again to grab the appropriate letter from each substring
            //think going through each row and selecting one character from that row's string.
            iterator = 0;
            for(int i  = 0; i <= rows; i++)
            {
                string encryptedSubString = "";

                for(int j = 0; j <= rows; j++)
                {
                    char[] subString = subStrings[j].ToCharArray();

                    if (iterator < subStrings[j].Length)
                    {
                        encryptedSubString += subString[iterator];
                    }
                }

                iterator++;
                output += encryptedSubString + " ";
            }


            return output;
        }

        static string biggerIsGreater(string w)
        {

            //break the string into a character array
            char[] characterArray = w.ToCharArray();

            //loop through the character array backwards and find a pair of characters where the 2nd is greater than teh 1st
            // i.e abbaba -> 2nd from last 'b' is greater than the 'a' to it's left
            int i = w.Length - 1;
            while (i > 0 && characterArray[i - 1] >= characterArray[i])
            {
                i--;
            }

            if(i <= 0)
            {
                return "no answer";
            }

            int j = characterArray.Length -1;
            while (characterArray[j] <= characterArray[i - 1])
            {
                j--;
            }

            char swapper = characterArray[i - 1];
            characterArray[i - 1] = characterArray[j];
            characterArray[j] = swapper;

            j = characterArray.Length - 1;

            //this is the part i didn't understand fully and ended up hacking to make j=0 and j = i -1 cases work properly. this is about 1/10th the code and effort
            while(i < j)
            {
                swapper = characterArray[i];
                characterArray[i] = characterArray[j];
                characterArray[j] = swapper;

                i++;
                j--;
            }

            string newOutput = "";
            for(int k = 0; k < characterArray.Length; k++)
            {
                newOutput += characterArray[k].ToString();
            }

            if(newOutput != w)
            {
                return newOutput;
            }
            else
            {
                return "no answer";
            }
        }

        static List<int> kaprekarNumbers(int p, int q)
        {
            List<int> output = new List<int>();

            if(p == 1)
            {
                output.Add(1);
            }

            for(int i = p; i <= q; i++)
            {
                //square i
                long sqrOfi = (long)i * (long)i;

                //convert the square into a string
                string sqrOfiAsString = sqrOfi.ToString();

                //get the length o fthe resulting string
                int stringLength = sqrOfiAsString.Length;

                if(stringLength >= 2)
                {
                    int midwayPoint = (stringLength / 2);

                    //chop it into halves
                    string leftHalf = sqrOfiAsString.Substring(0, midwayPoint);
                    string rightHalf = sqrOfiAsString.Substring(midwayPoint, stringLength - midwayPoint);

                    //convert those two halves back into doubles
                    double leftNumber = double.Parse(leftHalf);
                    double rightNumber = double.Parse(rightHalf);

                    //add them to see if they equal i
                    if (rightNumber + leftNumber == i)
                    {
                        output.Add(i);
                    }
                }
            }
               

            return output;
        }

        static int beautifulTriplets(int d, int[] arr)
        {
            int output = 0;
            List<int[]> nums = new List<int[]>();
            int i = arr.Length;
            while (i > 0)
            {
                i--;

                for(int j = i -1; j >= 0; j--)
                {
                    if(arr[i] - arr[j] == d)
                    {

                        for(int k = j - 1; k >= 0; k--)
                        {
                            if(arr[j] - arr[k] == d)
                            {
                                int[] array = { arr[i], arr[j], arr[k]};
                                nums.Add(array);
                                output++;
                            }
                        }
                    }
                }
            }

            return output;
        }

        static int minimumDistances(int[] a)
        {
            int shortestDistance = a.Length;
            int i = 0;

            while(i < a.Length)
            {
                int j = i + 1;
                while(j < a.Length)
                {
                    if(a[i] == a[j])
                    {
                        int distance = Math.Abs(i - j);

                        if(distance < shortestDistance)
                        {
                            shortestDistance = distance;
                            break;
                        }
                    }

                    j++;
                }

                i++;
            }

            if(shortestDistance == a.Length)
            {
                shortestDistance = -1;
            }

            return shortestDistance;
        }

        static string timeInWords(int h, int m)
        {
            string output = "";

            Dictionary<int, string> wordsForHours = new Dictionary<int, string>();
            wordsForHours.Add(1, "one");
            wordsForHours.Add(2, "two");
            wordsForHours.Add(3, "three");
            wordsForHours.Add(4, "four");
            wordsForHours.Add(5, "five");
            wordsForHours.Add(6, "six");
            wordsForHours.Add(7, "seven");
            wordsForHours.Add(8, "eight");
            wordsForHours.Add(9, "nine");
            wordsForHours.Add(10, "ten");
            wordsForHours.Add(11, "eleven");
            wordsForHours.Add(12, "twelve");
            wordsForHours.Add(13, "thirteen");
            wordsForHours.Add(14, "fourteen");
            wordsForHours.Add(15, "quarter");
            wordsForHours.Add(16, "sixteen");
            wordsForHours.Add(17, "seventeen");
            wordsForHours.Add(18, "eighteen");
            wordsForHours.Add(19, "nineteen");
            wordsForHours.Add(20, "twenty");
            wordsForHours.Add(30, "half");

            if (m == 0)
            {
                return wordsForHours[h] + " o' clock";
            }


            string timeMod = "";

            if(m <= 30)
            {
                timeMod = " past ";
            }
            else
            {
                timeMod = " to ";
                h++;
                if (h == 13) h = 1;
                m = 60 - m;
            }

           
            if (m == 1 || m == 59)
            {
                output += wordsForHours[m] + " minute" + timeMod + wordsForHours[h];
            }
            else if (m >= 2 && m <= 14)
            {
                output += wordsForHours[m] + " minutes" + timeMod + wordsForHours[h];
            }
            else if (m == 15 || m == 45)
            {
                output += wordsForHours[m] + timeMod + wordsForHours[h];
            }
            else if (m == 30)
            {
                output += wordsForHours[m] + timeMod + wordsForHours[h];
            }
            else
            {
                int remainder = m % 10;
                int difference = m - remainder;
                output += wordsForHours[difference] + " " + wordsForHours[remainder] + " minutes" + timeMod + wordsForHours[h];
            }

            return output;
        }

        private static void permutations(string[][] words)
        {
            string output = "";

            List<int> counters = new List<int>();

            for(int i  = 0; i < words.Length; i++)
            {
                counters.Add(0);
            }

            int firstPlaceCounter = counters[words.Length - 1];
            int firstPlaceCounterMaxValue = words[0].Length;

            while (firstPlaceCounter != firstPlaceCounterMaxValue)
            {
                output = "";

                for(int i = 0; i < words.Length; i++)
                {
                    int counterValue = counters[i];
                    output += words[i][counterValue] + " ";
                }

                counters[words.Length - 1]++;

                for(int i = counters.Count -1; i > 0; i--)
                {
                    if(counters[i] >= words[i].Length)
                    {
                        counters[i] = 0;
                        counters[i - 1]++;
                    }
                }

                firstPlaceCounter = counters[0];
                Console.WriteLine(output);
            }
        }

        static int chocolateFeast(int monies, int candyCost, int wrappersPerFreebie)
        {
            int output = 0;

            bool canBuyACandy = true;

            int candiesEaten = 0;
            int candyWrappers = 0;

            while (canBuyACandy)
            {
                if (monies >= candyCost)
                {
                    monies -= candyCost;
                    candiesEaten++;
                    candyWrappers++;

                    if (candyWrappers == wrappersPerFreebie)
                    {
                        candiesEaten++;
                        candyWrappers = 1;
                    }
                }
                else
                {
                    canBuyACandy = false;
                }
               
            }

            output = candiesEaten;

            return output;
        }

        static int[] serviceLane(int t, int[] widths, int[][] cases)
        {
            int[] output = new int[t];

            for(int i = 0; i < cases.Length; i++)
            {
                int start = cases[i][0];
                int end = cases[i][1];

                int minWidth = widths[start];

                for (int j = start; j < end +1; j++)
                {
                    if(minWidth > widths[j])
                    {
                        minWidth = widths[j];
                    }
                }

                output[i] = minWidth;
            }

            return output;
        }

        static void Main(String[] args)
        {

            var cases = Convert.ToInt32(Console.ReadLine());
            for (var ii = 0; ii < cases; ii++)
            {
                var stones = Convert.ToInt32(Console.ReadLine()) - 1;
                var one = Convert.ToInt32(Console.ReadLine());
                var two = Convert.ToInt32(Console.ReadLine());
                var a = Math.Min(one, two);
                var b = Math.Max(one, two);
                var current = a * stones;
                var max = b * stones;
                var difference = b - a;
                if (a == b)
                {
                    Console.WriteLine(current);
                }
                else
                {
                    var ansString = new StringBuilder();
                    while (current <= max)
                    {
                        ansString.Append(current.ToString() + " ");
                        current += difference;
                    }
                    Console.WriteLine(ansString);
                }
            }
        

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int t = Convert.ToInt32(tokens_n[1]);
        //string[] width_temp = Console.ReadLine().Split(' ');
        //int[] width = Array.ConvertAll(width_temp, Int32.Parse);
        //int[][] cases = new int[t][];
        //for (int cases_i = 0; cases_i < t; cases_i++)
        //{
        //    string[] cases_temp = Console.ReadLine().Split(' ');
        //    cases[cases_i] = Array.ConvertAll(cases_temp, Int32.Parse);
        //}
        //int[] result = serviceLane(t, width, cases);
        //Console.WriteLine(String.Join("\n", result));


        //int t = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < t; a0++)
        //{
        //    string[] tokens_n = Console.ReadLine().Split(' ');
        //    int n = Convert.ToInt32(tokens_n[0]);
        //    int c = Convert.ToInt32(tokens_n[1]);
        //    int m = Convert.ToInt32(tokens_n[2]);
        //    int result = chocolateFeast(n, c, m);
        //    Console.WriteLine(result);
        //}
        //string[][] words = { new string[] { "small", "large", "tiny", "huge" },
        //    new string[] { "smelly", "gross" },
        //    new string[] { "thing", "object", "doodad" } };

        //permutations(words);

        //int h = Convert.ToInt32(Console.ReadLine());
        //int m = Convert.ToInt32(Console.ReadLine());
        //string result = timeInWords(h, m);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] a_temp = Console.ReadLine().Split(' ');
        //int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        //int result = minimumDistances(a);
        //Console.WriteLine(result);

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int d = Convert.ToInt32(tokens_n[1]);
        //string[] arr_temp = Console.ReadLine().Split(' ');
        //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        //int result = beautifulTriplets(d, arr);
        //Console.WriteLine(result);

        //int p = Convert.ToInt32(Console.ReadLine());
        //int q = Convert.ToInt32(Console.ReadLine());
        //List<int> result = kaprekarNumbers(p, q);

        //if (result.Count == 0)
        //{
        //    Console.WriteLine("INVALID RANGE");
        //}
        //else
        //{
        //    Console.WriteLine(String.Join(" ", result));
        //}

        //int T = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < T; a0++)
        //{
        //    string w = Console.ReadLine();
        //    string result = biggerIsGreater(w);
        //    Console.WriteLine(result);
        //}

        //string s = Console.ReadLine();
        //string result = encryption(s);
        //Console.WriteLine(result);


        //int q = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < q; a0++)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());
        //    int[][] container = new int[n][];
        //    for (int container_i = 0; container_i < n; container_i++)
        //    {
        //        string[] container_temp = Console.ReadLine().Split(' ');
        //        container[container_i] = Array.ConvertAll(container_temp, Int32.Parse);
        //    }
        //    string result = organizingContainers(container);
        //    Console.WriteLine(result);
        //}

        //string[] input = LoadInputFromFile("C:\\Users\\Mike\\Documents\\hundredthousand.txt");
        //int n = Convert.ToInt32(input[0]);
        //long[][] container = new long[n][];
        //for (int container_i = 0; container_i < n; container_i++)
        //{
        //    string[] container_temp = input[container_i+1].Split(' ');
        //    container[container_i] = Array.ConvertAll(container_temp, long.Parse);
        //}
        //string result = organizingContainers(container);


        //int t = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < t; a0++)
        //{
        //    string[] tokens_b = Console.ReadLine().Split(' ');
        //    long b = Convert.ToInt32(tokens_b[0]);
        //    long w = Convert.ToInt32(tokens_b[1]);
        //    string[] tokens_x = Console.ReadLine().Split(' ');
        //    long x = Convert.ToInt32(tokens_x[0]);
        //    long y = Convert.ToInt32(tokens_x[1]);
        //    long z = Convert.ToInt32(tokens_x[2]);
        //    BigInteger result = taumBday(b, w, x, y, z);
        //    Console.WriteLine(result);
        //}

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int m = Convert.ToInt32(tokens_n[1]);
        //string[] topic = new string[n];
        //for (int topic_i = 0; topic_i < n; topic_i++)
        //{
        //    topic[topic_i] = Console.ReadLine();
        //}
        //int[] result = acmTeam(topic);
        //Console.WriteLine(String.Join("\n", result));

        //string[] input = LoadInputFromFile("C:\\Users\\Mike\\Documents\\hundredthousand.txt");
        ////string[] tokens_n = Console.ReadLine().Split(' ');

        //string[] tokens_n = input[0].Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int k = Convert.ToInt32(tokens_n[1]);

        ////string[] tokens_r_q = Console.ReadLine().Split(' ');
        //string[] tokens_r_q = input[1].Split(' ');

        //int r_q = Convert.ToInt32(tokens_r_q[0]);
        //int c_q = Convert.ToInt32(tokens_r_q[1]);

        //int[][] obstacles = new int[k][];
        //for (int obstacles_i = 0; obstacles_i < k; obstacles_i++)
        //{
        //    string[] obstacles_temp = input[obstacles_i +2].Split(' ');
        //    //string[] obstacles_temp = Console.ReadLine().Split(' ');
        //    obstacles[obstacles_i] = Array.ConvertAll(obstacles_temp, Int32.Parse);
        //}
        //int result = queensAttack(n, k, r_q, c_q, obstacles);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] c_temp = Console.ReadLine().Split(' ');
        //int[] c = Array.ConvertAll(c_temp, Int32.Parse);
        //int result = jumpingOnClouds(c);
        //Console.WriteLine(result);

        //string[] input = LoadInputFromFile("C:\\Users\\Mike\\Documents\\hundredthousand.txt");
        //string s = input[0];
        //long n = long.Parse(input[1]);
        //string s = Console.ReadLine();
        //long n = Convert.ToInt64(Console.ReadLine());
        //long result = repeatedString(s, n);
        //Console.WriteLine(result);

        //int[] array = { 1, 2, 3, 4 };

        //MakeSubSets(array);

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int k = Convert.ToInt32(tokens_n[1]);
        //string[] arr_temp = Console.ReadLine().Split(' ');
        //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        //int result = nonDivisibleSubset(k, arr);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] arr_temp = Console.ReadLine().Split(' ');
        //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        //cutTheSticks(arr);

        //string[] tokens_d1 = Console.ReadLine().Split(' ');
        //int d1 = Convert.ToInt32(tokens_d1[0]);
        //int m1 = Convert.ToInt32(tokens_d1[1]);
        //int y1 = Convert.ToInt32(tokens_d1[2]);
        //string[] tokens_d2 = Console.ReadLine().Split(' ');
        //int d2 = Convert.ToInt32(tokens_d2[0]);
        //int m2 = Convert.ToInt32(tokens_d2[1]);
        //int y2 = Convert.ToInt32(tokens_d2[2]);
        //int result = libraryFine(d1, m1, y1, d2, m2, y2);
        //Console.WriteLine(result);

        //int[][] points = new int[][] { new int[] { 1, 5 }, new int[] { 1, 5 }, new int[] { 0, 0 }, new int[] { 5, 0 } };

        //IsThisARectangle(points);

        //string word = "elevision";

        //FindFirstNonRepeatingCharacter(word);
        //string letters = "aaaaaqqqqwwwewtrr";

        //CountLettersInString(letters);

        //int[] array = { 12, 13, 14, 23, 12, 56, 57, 856, 566, 432, 35 };

        //FindLargestSum(array);

        //int[] array1 = { 24, 21, 55, 2, 32, 1224, 52, 3333, 51, 2325, 60 };
        //int[] array2 = { 632, 343, 777, 212, 7, 54, 343, 777, 8, 99, 3432, 343 };

        //List<int[]> listOfArrays = new List<int[]>();
        //listOfArrays.Add(array1);
        //listOfArrays.Add(array2);

        //FindSecondLargest(listOfArrays);
        // FindPrimes();

        //int q = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < q; a0++)
        //{
        //    string[] tokens_a = Console.ReadLine().Split(' ');
        //    int a = Convert.ToInt32(tokens_a[0]);
        //    int b = Convert.ToInt32(tokens_a[1]);
        //    int result = squares(a, b);
        //    Console.WriteLine(result);
        //}

        //string s = Console.ReadLine();
        //string t = Console.ReadLine();
        //int k = Convert.ToInt32(Console.ReadLine());
        //string result = appendAndDelete(s, t, k);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //extraLongFactorials(n);

        //int t = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < t; a0++)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());
        //    int result = findDigits(n);
        //    Console.WriteLine(result);
        //}

        //string[][] array = new string[][] {

        //    new string[] { "josh", "tracy", "stan" },
        //    new string[] { "fights", "meets", "notices", "avoids" },
        //    new string[] { "monsters", "aliens", "zombies" } };

        //AnnoyingChallengeFinal(array);

        //annoyingChallenge2(array);

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int k = Convert.ToInt32(tokens_n[1]);
        //string[] c_temp = Console.ReadLine().Split(' ');
        //int[] c = Array.ConvertAll(c_temp, Int32.Parse);
        //int result = jumpingOnClouds(c, k);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] p_temp = Console.ReadLine().Split(' ');
        //int[] p = Array.ConvertAll(p_temp, Int32.Parse);
        //int[] result = permutationEquation(p);
        //Console.WriteLine(String.Join("\n", result));

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int k = Convert.ToInt32(tokens_n[1]);
        //int q = Convert.ToInt32(tokens_n[2]);
        //string[] a_temp = Console.ReadLine().Split(' ');
        //int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        //int[] m = new int[q];
        //for (int m_i = 0; m_i < q; m_i++)
        //{
        //    m[m_i] = Convert.ToInt32(Console.ReadLine());
        //}
        //int[] result = circularArrayRotation(a, k, m);
        //Console.WriteLine(String.Join("\n", result));

        //string[][] testInput = new string[][]{
        //new string[] {"quick", "lazy"}, new string[] {"brown", "black", "grey"}, new string[] {"fox", "dog"} };

        //solutionTest(testInput);

        //int t = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < t; a0++)
        //{
        //    string[] tokens_n = Console.ReadLine().Split(' ');
        //    int n = Convert.ToInt32(tokens_n[0]);
        //    int m = Convert.ToInt32(tokens_n[1]);
        //    int s = Convert.ToInt32(tokens_n[2]);
        //    int result = saveThePrisoner(n, m, s);
        //    Console.WriteLine(result);
        //}

        //int n = Convert.ToInt32(Console.ReadLine());
        //int result = viralAdvertising(n);
        //Console.WriteLine(result);

        //int t = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < t; a0++)
        //{
        //    string[] tokens_n = Console.ReadLine().Split(' ');
        //    int n = Convert.ToInt32(tokens_n[0]);
        //    int k = Convert.ToInt32(tokens_n[1]);
        //    string[] a_temp = Console.ReadLine().Split(' ');
        //    int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        //    string result = angryProfessor(k, a);
        //    Console.WriteLine(result);
        //}

        //int t = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < t; a0++)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());
        //    int result = utopianTree(n);
        //    Console.WriteLine(result);
        //}

        //string[] h_temp = Console.ReadLine().Split(' ');
        //int[] h = Array.ConvertAll(h_temp, Int32.Parse);
        //string word = Console.ReadLine();
        //int result = designerPdfViewer(h, word);
        //Console.WriteLine(result);

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int k = Convert.ToInt32(tokens_n[1]);
        //string[] height_temp = Console.ReadLine().Split(' ');
        //int[] height = Array.ConvertAll(height_temp, Int32.Parse);
        //int result = hurdleRace(k, height);
        //Console.WriteLine(result);

        //string[] fromFile = LoadInputFromFile("C:\\Users\\Mike\\Documents\\hundredthousand.txt");
        //int n = Convert.ToInt32(fromFile[0]);
        //string[] intFromFile = fromFile[1].Split(' ');
        //int m = Convert.ToInt32(fromFile[2]);
        //string[] aliceScores = fromFile[3].Split(' ');

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] scores_temp = Console.ReadLine().Split(' ');
        //int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);

        //int[] scores = Array.ConvertAll(intFromFile, Int32.Parse);

        //int m = Convert.ToInt32(Console.ReadLine());
        //string[] alice_temp = Console.ReadLine().Split(' ');
        //int[] alice = Array.ConvertAll(alice_temp, Int32.Parse);

        //int[] alice = Array.ConvertAll(aliceScores, Int32.Parse);
        //int[] result = climbing(scores, alice);
        //int[] result2 = climbing2(scores, alice, n, m);
        // Console.WriteLine(String.Join("\n", result));

        //string[] fromFile = LoadInputFromFile("C:\\Users\\Mike\\Documents\\hundredthousand.txt");
        //string[] intsFromFile = fromFile[1].Split(' ');
        //int[] a = Array.ConvertAll(intsFromFile, Int32.Parse);
        ////int n = Convert.ToInt32(Console.ReadLine());
        ////string[] a_temp = Console.ReadLine().Split(' ');
        ////int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        //int result = pickingNumbers(a);
        //Console.WriteLine(result);

        //int q = Convert.ToInt32(Console.ReadLine());
        //for (int a0 = 0; a0 < q; a0++)
        //{
        //    string[] tokens_x = Console.ReadLine().Split(' ');
        //    int x = Convert.ToInt32(tokens_x[0]);
        //    int y = Convert.ToInt32(tokens_x[1]);
        //    int z = Convert.ToInt32(tokens_x[2]);
        //    string result = catAndMouse(x, y, z);
        //    Console.WriteLine(String.Join(" ", result));
        //}

        // string[] tokens_s = Console.ReadLine().Split(' ');
        // int s = Convert.ToInt32(tokens_s[0]);
        // int n = Convert.ToInt32(tokens_s[1]);
        // int m = Convert.ToInt32(tokens_s[2]);
        // string[] keyboards_temp = Console.ReadLine().Split(' ');
        //int[] keyboards = Array.ConvertAll(keyboards_temp, Int32.Parse);      
        // string[] drives_temp = Console.ReadLine().Split(' ');
        // int[] drives = Array.ConvertAll(drives_temp, Int32.Parse);
        // //  The maximum amount of money she can spend on a keyboard and USB drive, or -1 if she can't purchase both items
        // int moneySpent = getMoneySpent(keyboards, drives, s);
        // Console.WriteLine(moneySpent);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string s = Console.ReadLine();
        //int result = countingValleys(n, s);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //int p = Convert.ToInt32(Console.ReadLine());
        //int result = solve(n, p);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] ar_temp = Console.ReadLine().Split(' ');
        //int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
        //int result = sockMerchant(n, ar);
        //Console.WriteLine(result);

        //string[] tokens_n = Console.ReadLine().Split(' ');
        //int n = Convert.ToInt32(tokens_n[0]);
        //int k = Convert.ToInt32(tokens_n[1]);
        //string[] ar_temp = Console.ReadLine().Split(' ');
        //int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
        //int b = Convert.ToInt32(Console.ReadLine());
        //string result = bonAppetit(n, k, b, ar);
        //Console.WriteLine(result);

        //int year = Convert.ToInt32(Console.ReadLine());
        //string result = solve(year);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] ar_temp = Console.ReadLine().Split(' ');
        //int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
        //int result = migratoryBirds(n, ar);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] s_temp = Console.ReadLine().Split(' ');
        //int[] s = Array.ConvertAll(s_temp, Int32.Parse);
        //string[] tokens_d = Console.ReadLine().Split(' ');
        //int d = Convert.ToInt32(tokens_d[0]);
        //int m = Convert.ToInt32(tokens_d[1]);
        //int result = solve(n, s, d, m);
        //Console.WriteLine(result);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] score_temp = Console.ReadLine().Split(' ');
        //int[] score = Array.ConvertAll(score_temp, Int32.Parse);
        //int[] result = breakingRecords(score);
        //Console.WriteLine(String.Join(" ", result));

        //string[] tokens_x1 = Console.ReadLine().Split(' ');
        //int x1 = Convert.ToInt32(tokens_x1[0]);
        //int v1 = Convert.ToInt32(tokens_x1[1]);
        //int x2 = Convert.ToInt32(tokens_x1[2]);
        //int v2 = Convert.ToInt32(tokens_x1[3]);
        //string result = kangaroo(x1, v1, x2, v2);
        //Console.WriteLine(result);

        //string[] tokens_s = Console.ReadLine().Split(' ');
        //int s = Convert.ToInt32(tokens_s[0]);
        //int t = Convert.ToInt32(tokens_s[1]);
        //string[] tokens_a = Console.ReadLine().Split(' ');
        //int a = Convert.ToInt32(tokens_a[0]);
        //int b = Convert.ToInt32(tokens_a[1]);
        //string[] tokens_m = Console.ReadLine().Split(' ');
        //int m = Convert.ToInt32(tokens_m[0]);
        //int n = Convert.ToInt32(tokens_m[1]);
        //string[] apple_temp = Console.ReadLine().Split(' ');
        //int[] apple = Array.ConvertAll(apple_temp, Int32.Parse);
        //string[] orange_temp = Console.ReadLine().Split(' ');
        //int[] orange = Array.ConvertAll(orange_temp, Int32.Parse);
        //countApplesAndOranges(s, t, a, b, apple, orange);

        //int n = Convert.ToInt32(Console.ReadLine());
        //int[] grades = new int[n];
        //for (int grades_i = 0; grades_i < n; grades_i++)
        //{
        //    grades[grades_i] = Convert.ToInt32(Console.ReadLine());
        //}

        //string[] gradeStrings = LoadInputFromFile("C:\\Users\\Mike\\Documents\\hundredthousand.txt");
        //int[] grades = new int[gradeStrings.Length];
        //for (int i = 0; i < gradeStrings.Length; i++)
        //{
        //    grades[i] = Int32.Parse(gradeStrings[i]);
        //}

        //int[] result = solve(grades);
        //Console.WriteLine(String.Join("\n", result));

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] ar_temp = Console.ReadLine().Split(' ');
        //int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
        //int result = birthdayCakeCandles(100000, ar);
        //Console.WriteLine(result);

        //string[] arr_temp = Console.ReadLine().Split(' ');
        //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        //miniMaxSum(arr);

        //int n = Convert.ToInt32(Console.ReadLine());
        //staircase(n);

        //int n = Convert.ToInt32(Console.ReadLine());
        //string[] arr_temp = Console.ReadLine().Split(' ');
        //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        //plusMinus(arr);


        //int n = Convert.ToInt32(Console.ReadLine());
        //int[][] a = new int[n][];
        //for (int a_i = 0; a_i < n; a_i++)
        //{
        //    string[] a_temp = Console.ReadLine().Split(' ');
        //    a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
        //}

        //int result = diagonalDifference(a);
        //Console.WriteLine(result);

        //int[,] array2D = new int[,] { { 1, 2, 3  }, { 4, 5, 6 }, { 7, 8, 9 } };
        //int sum = 0;
        //int index = array2D.GetLength(1);
        //for (int i = 0; i < array2D.GetLength(0); i++)
        //{

        //    index--;
        //    sum += array2D[i, index];
        //}
        //for(int i = 0; i < array2D.GetLength(0); i++)
        //{
        //    sum += array2D[i, index];
        //    index++;
        //}

        //Console.WriteLine(sum);
        //NthNumberInFibonacci(9);
        //Question1 q1 = new Question1();

        //q1.RunQuestion();

        //tutorialCase tut = new tutorialCase();
        //tut.RunCase();

        //TestStructure structure = new TestStructure();

        //ModifyAStruc(ref structure);


        //int num = (int)thing.test;
        //int num2 = (int)thing.things;

        //System.Console.WriteLine(num);
        //System.Console.WriteLine(num2);
        //System.Console.WriteLine("hello");
        //TestObject testObject = new TestObject(firstArgument: "hello",
        //                                       secondArgument: "world",
        //                                       thirdArgument: 42
        //                                      );
        //System.Console.WriteLine(testObject.string1 + testObject.string2 + testObject.int1);


        //Bitmap loadedImage = (Bitmap)Image.FromFile(@"C:\test.png", true);

        //int x, y;
        //List<Color> pixels = new List<Color>();

        //for (x = 0; x < loadedImage.Width; x++)
        //{
        //    for (y = 0; y < loadedImage.Height; y++)
        //    {
        //        Color pixelColor = loadedImage.GetPixel(x, y);
        //        pixels.Add(pixelColor);
        //    }
        //}

        //Bitmap savedImage = new Bitmap(100,100);

        //for (x = 0; x < loadedImage.Width; x++){

        //    for (y = 0; y < loadedImage.Height; y++)
        //    {

        //        int pixelAlpha = loadedImage.GetPixel(x, y).A;

        //        if (pixelAlpha != 0)
        //        {

        //            //turn the red pixel purple
        //            Color currentPixel = loadedImage.GetPixel(x, y);

        //            int red = currentPixel.R;
        //            int blue = currentPixel.B;
        //            int green = currentPixel.G;

        //            red -= (int)(red * .55f);
        //            if (red < 0) red = 0;

        //            green += (int)(green * .2f);
        //            if (green > 255) green = 255;

        //            blue += (int)(blue * .4f);
        //            if(blue > 255) blue = 255;

        //            Color modifiedPixel = Color.FromArgb(pixelAlpha, red, green, blue);

        //            savedImage.SetPixel(x, y, modifiedPixel);
        //        }
        //    }
        //}

        //savedImage.Save(@"C:\output.bmp", System.Drawing.Imaging.ImageFormat.Png);
        //System.Console.WriteLine("Number of pixels: {0}", pixels.Count);


        //int testBits = 24;
        //testBits = testBits << 1;
        //System.Console.WriteLine(testBits);
        //testBits = testBits >> 5;
        //System.Console.WriteLine(testBits);
        //System.Console.WriteLine(testBits);

        //int a = 1;
        //int b = 0;
        //int c = 4;

        //int sum = a + b + c;

        //int mask = 7;
        //int thingsToCheck = 5;

        //if ((sum & mask) == thingsToCheck)
        //{
        //    System.Console.WriteLine("successfully masked");
        //}



        //using (TestObject testObj = new TestObject())
        //{
        //    System.Console.WriteLine("inside the using block");
        //    testObj.testMethod(9153706984145682944, "check");
        //}

        Console.ReadKey();
        }

        //Structs are not reference types. if you want the method to maintain changes to the object outside scope then you need to pass by reference.
        private static void ModifyAStruc(ref TestStructure structure)
        {
            structure.int1 = 2;
        }

       // LoadInputFromFile("C:\\Users\\Mike\\Documents\\hundredthousand.txt");
        private static string[] LoadInputFromFile(string filePath)
        {

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                return lines;

            }
            else
            {
                Console.WriteLine("could not find file at: " + filePath);
                return null;
            }
        }
    }
}
