using System;
using System.IO;
using System.Text;

namespace GildedRose
{
    [TestClass]
    public class ApprovalTest : VerifyBase
    {
        [TestMethod]
        public Task ThirtyDays()
        {
            
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            return Verify(output);
        }
    }
}
