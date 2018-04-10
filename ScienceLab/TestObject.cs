namespace ScienceLab
{

    public class TestObject : System.IDisposable
    {

        public string string1;
        public string string2;
        public int int1;

        public TestObject(string firstArgument = "nothing", string secondArgument ="nothing", int thirdArgument = 0)
        {

            string1 = firstArgument;
            string2 = secondArgument;
            int1 = thirdArgument;
        }

        ~TestObject()
        {

            System.Console.WriteLine("inside the destructor");
        }


        /// <summary>
        /// A test method. returns a number
        /// </summary>
        /// <param name="AnotherNumber">A 64 bit integer</param>
        /// <param name="SomeString"> some random string</param>
        public System.Int64 testMethod(System.Int64 ANumber, string SomeString)
        {

            System.Console.WriteLine(SomeString + "\n");

            System.Console.WriteLine(ANumber.ToString("X"));

            return 0;

        }

        public void Dispose()
        {
            System.Console.WriteLine("inside the dispose method");
        }
        /// <summary>
        /// Finds sections of silence in a sound stream.
        /// </summary>
        /// <param name="file">Filename for the sound stream.</param>
        /// <param name="block">The block of time of a sample to get the level (peak amplitude), default is 20 miliseconds.</param>
        /// <param name="silence">The silence time to split by default is 2000 miliseconds (2 seconds).</param>
        /// <param name="minGap">The minimum time for the splits, default is 480000 miliseconds (8 mins).</param>
        /// <param name="bgWorker">The BackgroundWorker to report progress.</param>
        /// <returns>List of sound files</returns>
    }
}
