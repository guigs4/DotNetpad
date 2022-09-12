using Engine.ViewModels;
using Xunit;

namespace TestEngine
{
    public class DataSessionTests
    {
        [Fact]
        public void DataSession_ShouldHaveAValidTabCollection()
        {
            var DataSession = new DataSessionVM();
            DataSession.AddEmptyTab(0);
            Assert.True(DataSession.OpenTabs.Any());
        }


    }
}
