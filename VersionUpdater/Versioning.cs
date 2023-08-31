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
      private string Feature(string[] major)
      {
         int intValue = Convert.ToInt32(major[2]);
         intValue++;
         major[2] = intValue.ToString();
         return string.Join('.', major);
      }

      private string BugFix(string[] minor)
      {
         int intValue = Convert.ToInt32(minor[3]);
         intValue++;
         minor[3] = intValue.ToString();
         return string.Join('.', minor);
      }
   }
}
