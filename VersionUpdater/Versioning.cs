namespace VersionUpdater
{
   public class Versioning
   {
      ConsoleKeyInfo consoleKeyInfo;
      string version;
      public Versioning(ConsoleKeyInfo consoleKeyInfo, string version)
      {
         this.consoleKeyInfo = consoleKeyInfo;
         this.version = version;
      }

      /// <summary>
      /// VersionIncrement - Determine the release type and increment version accordingly 
      /// </summary>
      /// <returns>new version</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public string VersionIncrement()
      {
         string[] releaseType = version.Split('.');

         if (consoleKeyInfo.Key == ConsoleKey.D1)
         {
            return Feature(releaseType);
         }
         else if (consoleKeyInfo.Key == ConsoleKey.D2)
         {
            return BugFix(releaseType);
         }

         throw new InvalidOperationException("Couldn't determine release type.");
      }
      /// <summary>
      /// Feature - major release.
      /// </summary>
      /// <param name="major"></param>
      /// <returns></returns>
      private string Feature(string[] major)
      {
         int intValue = Convert.ToInt32(major[2]);
         intValue++;
         major[2] = intValue.ToString();
         return string.Join('.', major);
      }

      /// <summary>
      /// BugFix - minor release.
      /// </summary>
      /// <param name="minor"></param>
      /// <returns></returns>
      private string BugFix(string[] minor)
      {
         int intValue = Convert.ToInt32(minor[3]);
         intValue++;
         minor[3] = intValue.ToString();
         return string.Join('.', minor);
      }
   }
}
