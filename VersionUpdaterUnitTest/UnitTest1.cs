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
   }
}