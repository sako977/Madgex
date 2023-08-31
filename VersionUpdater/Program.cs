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
            ProcessLogic(); // Exit only on success or user exit. 
         }
      }

      private static void ProcessLogic()
      {
         Console.WriteLine("Select release type:\n" +
         "1. Feature\n" +
         "2. Bug Fix");

         ConsoleKeyInfo keyInfo = Console.ReadKey();

         Console.WriteLine("\nEnter an absolute file path or press 'Enter' to grab version info form 'ProductInfo.cs' file.");

         string? softwareVersion = Console.ReadLine();
         if (string.IsNullOrWhiteSpace(softwareVersion))
         {
            Console.WriteLine("\nLooking for 'ProductInfo.cs' in current directory.");
            softwareVersion = File.ReadAllText(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ProductInfo.cs")).TrimEnd();
         }

         Versioning versioning = new Versioning(keyInfo, softwareVersion);
         versioning.VersionIncrement();
      }
   }
}