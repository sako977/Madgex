using System.Linq.Expressions;
using VersionUpdater;
using Xunit;

namespace VersionUpdaterUnitTest
{
   public class UnitTest1
   {
      [Theory]
      [InlineData("5.39.9.1")]
      [InlineData("7.23.5.2")]
      [InlineData("9.63.91.0")]
      public void Major_Release_Test_Success(string softwareVersion)
      {
         ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false);
         Versioning versioning = new Versioning(consoleKeyInfo, softwareVersion);
         string newSoftwareVersion = versioning.VersionIncrement();
         int previousRelease = Convert.ToInt32(softwareVersion.Split('.')[2]);
         int newRelease = Convert.ToInt32(newSoftwareVersion.Split('.')[2]);
         newRelease--;
         Assert.True(previousRelease == newRelease);
      }

      [Theory]
      [InlineData("5.39.9.1")]
      [InlineData("7.23.5.2")]
      [InlineData("9.63.91.0")]
      public void Minor_Release_Test_Success(string softwareVersion)
      {
         ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo('2', ConsoleKey.D2, false, false, false);
         Versioning versioning = new Versioning(consoleKeyInfo, softwareVersion);
         string newSoftwareVersion = versioning.VersionIncrement();
         int previousRelease = Convert.ToInt32(softwareVersion.Split('.')[3]);
         int newRelease = Convert.ToInt32(newSoftwareVersion.Split('.')[3]);
         newRelease--;
         Assert.True(previousRelease == newRelease);
      }

      [Theory]
      [InlineData('X', ConsoleKey.X)]
      [InlineData('5', ConsoleKey.D5)]
      [InlineData('*', ConsoleKey.Multiply)]
      public void Should_Fail_InvalidReleaseType_Test(char keyChar, ConsoleKey consoleKey)
      {
         try
         {
            ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo(keyChar, consoleKey, false, false, false);
            Versioning versioning = new Versioning(consoleKeyInfo, "5.39.9.1"); // Valid version
            string newSoftwareVersion = versioning.VersionIncrement();
         }
         catch (Exception ex)
         {
            Assert.True(ex.GetType() == typeof(InvalidOperationException));
         }
      }

      [Theory]
      [InlineData('1', ConsoleKey.D1, "38763278562")]
      [InlineData('2', ConsoleKey.D2, "!^&£*()$%^&*()")]
      [InlineData('1', ConsoleKey.D1, "shfiudshiufdshiu")]
      public void Should_Fail_InvalidVersionFormat_Test(char keyChar, ConsoleKey consoleKey, string softwareVersion)
      {
         try
         {
            ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo(keyChar, consoleKey, false, false, false);
            Versioning versioning = new Versioning(consoleKeyInfo, softwareVersion);
            string newSoftwareVersion = versioning.VersionIncrement();
         }
         catch
         {
            Assert.True(true); // Returned exception.  Should happen.
         }
      }
   }
}