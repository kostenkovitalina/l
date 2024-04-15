using System;

partial class MainClass
{
    static void ExecuteVariant_Vitalina(string[] args)
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Block 1: Variant 9");
        Console.WriteLine("2. Block 2: Variant 2a");
        Console.WriteLine("3. Block 2: Variant 2b");
        Console.WriteLine("4. Block 3: Variant 12");
        Console.WriteLine("5. Block 4: Variant 15");
        Console.Write("Enter your choice: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Run Block 1: Variant 9 ");
                MainClassVariant9.RunVariant9(args);
                break;
            case 2:
                Console.WriteLine("Run  Block 2: Variant 2a ");
                MainClassVariant2A.RunVariant2A();
                break;
            case 3:
                Console.WriteLine("Run  Block 2: Variant 2b ");
                MainClassVariant2B.RunVariant2B(args);
                break;        
            case 4:
                Console.WriteLine("Run Block 3: Variant 12 ");
                MainClassVariant12.RunVariant12(args);
                break;
            case 5:
                Console.WriteLine("Run Block 4: Variant 15 ");
                MainClassVariant15.RunVariant15();
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter 1, 2, 3, 4 or 5.");
                Console.ReadKey();
                break;
        }
    }
}
