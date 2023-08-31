namespace VersionUpdater
{
   internal class Program
   {
      static void Main(string[] args)
      {
         try
         {
            ProcessLogic();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            ProcessLogic(); // Allow one more chance. 
         }
      }

      /// <summary>
      /// ProcessLogic - Everything happens inside the method related to versioning.
      /// </summary>
      private static void ProcessLogic()
      {
         Console.WriteLine("Select release type:\n" +
         "1. Feature\n" +
         "2. Bug Fix");

         ConsoleKeyInfo keyInfo = Console.ReadKey();

         Console.WriteLine("\nEnter an absolute file path or press 'Enter' to grab version info form 'ProductInfo.cs' file from current directory.");

         string softwareVersion;
         string? filePath = Console.ReadLine();
         if (string.IsNullOrWhiteSpace(filePath))
         {
            Console.WriteLine("\nLooking for 'ProductInfo.cs' in current directory.");
            filePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ProductInfo.cs");
            softwareVersion = File.ReadAllText(filePath).TrimEnd();
         }
         else
         {
            softwareVersion = File.ReadAllText(filePath).TrimEnd();
         }

         // Pass on key information and softwareversion to 'Versioning'  object
         Versioning versioning = new Versioning(keyInfo, softwareVersion);
         softwareVersion = versioning.VersionIncrement();

         // Finally update the software version
         File.WriteAllText(filePath, softwareVersion);
      }
   }
}