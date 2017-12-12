using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 1 - Problem 1
            string inputCode = "36743676522426214741687639282183216978128565594112364817283598621384839756628424146779311928318383597235968644687665159591573413233616717112157752469191845757712928347624726438516211153946892241449523148419426259291788938621886334734497823163281389389853675932246734153563861233894952657625868415432316155487242813798425779743561987563734944962846865263722712768674838244444385768568489842989878163655771847362656153372265945464128668412439248966939398765446171855144544285463517258749813731314365947372548811434646381595273172982466142248474238762554858654679415418693478512641864168398722199638775667744977941183772494538685398862344164521446115925528534491788728448668455349588972443295391385389551783289417349823383324748411689198219329996666752251815562522759374542652969147696419669914534586732436912798519697722586795746371697338416716842214313393228587413399534716394984183943123375517819622837972796431166264646432893478557659387795573234889141897313158457637142238315327877493994933514112645586351127139429281675912366669475931711974332271368287413985682374943195886455927839573986464555141679291998645936683639162588375974549467767623463935561847869527383395278248952314792112113126231246742753119748113828843917812547224498319849947517745625844819175973986843636628414965664466582172419197227695368492433353199233558872319529626825788288176275546566474824257336863977574347328469153319428883748696399544974133392589823343773897313173336568883385364166336362398636684459886283964242249228938383219255513996468586953519638111599935229115228837559242752925943653623682985576323929415445443378189472782454958232341986626791182861644112974418239286486722654442144851173538756859647218768134572858331849543266169672745221391659363674921469481143686952478771714585793322926824623482923579986434741714167134346384551362664177865452895348948953472328966995731169672573555621939584872187999325322327893336736611929752613241935211664248961527687778371971259654541239471766714469122213793348414477789271187324629397292446879752673";
            var d1p1 = DayOne.InverseCaptcha(inputCode);
            Console.WriteLine("Day 1, problem 1:" + d1p1);

            // Day 1 - Problem 2
            var d1p2 = DayOne.HalfwayCaptcha(inputCode);
            Console.WriteLine("Day 1, problem 2:" + d1p2);

            // Day 2 - Problem 1 & 2
            List<int[]> d2input = ReadDayTwoInput();
            int d2p1output = 0, d2p2output = 0;

            foreach (int[] row in d2input)
            {
                d2p1output += DayTwo.CheckSum(row);
                d2p2output += DayTwo.WholeDivisor(row);
            }
            Console.WriteLine("Day 2, problem 1:" + d2p1output);
            Console.WriteLine("Day 2, problem 2:" + d2p2output);

            // Day 3 - Problem 1
            int d3p1output = DayThree.SpiralDistance(312051);
            Console.WriteLine("Day 3, problem 1:" + d3p1output);

            // Day 4 - Problem 1
            List<string> d4input = ReadDayFourInput();
            int d4p1output = 0, d4p2output = 0;
            foreach(string passphrase in d4input)
            {
                if (DayFour.IsPassphraseValid(passphrase)) d4p1output++;
                if (DayFour.IsPassphraseValidComplex(passphrase)) d4p2output++;
            }
            Console.WriteLine("Day 4, problem 1:" + d4p1output);
            Console.WriteLine("Day 4, problem 2:" + d4p2output);

            // Day 5
            List<int> d5input = ReadDayFiveInput();
            int d5p1output = DayFive.JumpsToEscapeMaze(ReadDayFiveInput().ToArray());
            var d5p2output = DayFive.JumpsToEscapeComplexMaze(ReadDayFiveInput().ToArray());
            Console.WriteLine("Day 5, problem 1:" + d5p1output);
            Console.WriteLine("Day 5, problem 2:" + d5p2output);

            // Day 6
            int[] d6input = new int[] { 4, 1, 15, 12, 0, 9, 9, 5, 5, 8, 7, 3, 14, 5, 12, 3 };
            int d6p1output = DaySix.Redistribute(d6input, out int d6p2output);
            Console.WriteLine("Day 6, problem 1:" + d6p1output);
            Console.WriteLine("Day 6, problem 2:" + d6p2output);

            // Day 7
            var d7input = ReadDaySevenInput();
            Console.WriteLine("Day 7, problem 1: " + DaySeven.GetBase(d7input));
            Console.WriteLine("Day 7, problem 2: " + DaySeven.FindProblemWeight(d7input, DaySeven.GetBase(d7input)));

            // Day 8
            var d8input = ReadDayEightInput();
            Console.WriteLine("Day 8, problem 1: " + DayEight.LargestAfterInstructions(d8input, out int d8p2output));
            Console.WriteLine("Day 8, problem 2: " + d8p2output);

            // Day 9
            var d9input = ReadDayNineInput();
            Console.WriteLine("Day 9, problem 1: " + DayNine.GroupScore(d9input, out int d9p2output));
            Console.WriteLine("Day 9, problem 2: " + d9p2output);

            // Day 10
            var d10lengths = new int[] { 197, 97, 204, 108, 1, 29, 5, 71, 0, 50, 2, 255, 248, 78, 254, 63 };
            var d10input = new int[256];
            for (int i = 0; i < 256; i++) d10input[i] = i;
            Console.WriteLine("Day 10, problem 1: " + DayTen.KnotHash(d10lengths, d10input));

            Console.ReadLine();
        }

        static List<int[]> ReadDayTwoInput()
        {
            List<int[]> output = new List<int[]>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\B06551A\Documents\GitHub\advent-of-code\Problems\Input Files\DayTwoInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    // List<int> numbers = new List<int>();
                    // Split string by tabs
                    char[] delimiters = new char[] { '\t' };
                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    int[] numbers = new int[parts.Length];

                    for (int i = 0; i < parts.Length; i++)
                    {
                        numbers[i] = int.Parse(parts[i]);
                    }

                    output.Add(numbers);
                }
            }

            return output;
        }

        static List<string> ReadDayFourInput()
        {
            List<string> output = new List<string>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\B06551A\Documents\GitHub\advent-of-code\Problems\Input Files\DayFourInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    output.Add(line);
                }
            }
            return output;
        }

        static List<int> ReadDayFiveInput()
        {
            List<int> output = new List<int>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\B06551A\Documents\GitHub\advent-of-code\Problems\Input Files\DayFiveInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    output.Add(Convert.ToInt32(line));
                }
            }
            return output;
        }

        static List<Tuple<string, List<string>>> ReadDaySevenInput()
        {
            var output = new List<Tuple<string, List<string>>>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\B06551A\Documents\GitHub\advent-of-code\Problems\Input Files\DaySevenInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    char[] delimiters = { ' ', ',', '-', '>', '(', ')' };
                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    var tuple = new Tuple<string, List<string>>(parts[0], new List<string>());
                    for (int i = 1; i < parts.Length; i++)
                    {
                        tuple.Item2.Add(parts[i]);
                    }
                    output.Add(tuple);
                }
            }

            return output;
        }
        static List<string> ReadDayEightInput()
        {
            List<string> output = new List<string>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\B06551A\Documents\GitHub\advent-of-code\Problems\Input Files\DayEightInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    output.Add(line);
                }
            }
            return output;
        }
        static string ReadDayNineInput()
        {
            string output = "";
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\B06551A\Documents\GitHub\advent-of-code\Problems\Input Files\DayNineInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    output += line;
                }
            }
            return output;
        }
    }
}
