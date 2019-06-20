using Moq;
using Xunit;

namespace PasswordManager.Tests
{
    public class AppHostTests
    {
        [Fact]
        public void Displays_ApplicationName()
        {
            Mock<IDisplayConfiguration> displayConfigurationMock = new Mock<IDisplayConfiguration>();
            displayConfigurationMock.SetupProperty(configuration => configuration.AppDisplayName, "Test app name");
            Mock<IConsoleWriter> consoleWriterMock = new Mock<IConsoleWriter>();
            Mock<IConsoleReader> consoleReaderMock = new Mock<IConsoleReader>();
            AppHost appHost = new AppHost(displayConfigurationMock.Object, consoleWriterMock.Object, consoleReaderMock.Object);

            appHost.Run(null);

            consoleWriterMock.Verify(cw => cw.WriteLine(It.Is<string>((s => s == "Test app name"))));
        }
    }
}
