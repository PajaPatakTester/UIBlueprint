using Framework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class TestBase
    {
        private Stopwatch _stopwatch = new Stopwatch();

        [BeforeScenario]
        public void Init()
        {
            _stopwatch.Restart();
            Driver.Initialize();
        }

        [AfterScenario]
        public void Cleanup()
        {
            _stopwatch.Stop();


            if (!TestCompletedWithoutErrors())
            {
                TakeScreenshot();
            }

            Driver.Cleanup();
        }
        private void TakeScreenshot()
        {
            var screenshot = Driver.TakeScreenshot(TestContext.CurrentContext.Test.Name);
            if (screenshot != null) TestContext.AddTestAttachment(screenshot);
        }

        public bool TestCompletedWithoutErrors()
        {
            return TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Inconclusive) ||
                   TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success);
        }
    }
}