

internal class L1_2_Practice
{
        public static void Run()
        {
        Console.WriteLine("Practice 1");
        string Name = "Hariom";
        int Age = 21;
        string Course = "B.Tech CSE";
        int Semester = 5;
        double Percentage = 70.21;
        bool IsStudent = true;
        char Grade = 'A';

        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Course: {Course}");
        Console.WriteLine($"Semester: {Semester}");
        Console.WriteLine($"Percentage: {Percentage}");
        Console.WriteLine($"IsStudent: {IsStudent}");
        Console.WriteLine($"Grade: {Grade}");

        Console.WriteLine("Practice 2");
        //string ProductName = "Laptop";
        //Console.WriteLine("Enter Product Name: ");
        //ProductName = Console.ReadLine();
        //Console.WriteLine($"Product Name: {ProductName}");
        //int productPrice = 0;
        //Console.WriteLine("Enter Product Price: ");
        //productPrice = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine($"Product Price: {productPrice}");
        //int productQuantity = 0;        
        //Console.WriteLine("Enter Quantity: ");
        //productQuantity = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine($"Product Quantity: {productQuantity}");
        //bool isAvailable = false;
        //Console.WriteLine("Is Product Available (true/false): ");
        //isAvailable = Convert.ToBoolean(Console.ReadLine());
        //Console.WriteLine($"Is Product Available: {isAvailable}");
        //char productGrade = 'A';
        //Console.WriteLine($"Product Grade: {productGrade}");


        Console.WriteLine("Practice 3");

        var ProductId = 101;
        var productName = "Laptop"; 
        var ProductPrice = 50000.00;
        var ProductWeight = 2.55m;
        var IsAvailable = true;
        Console.WriteLine((ProductId));
        Console.WriteLine((productName));
        Console.WriteLine((ProductPrice));
        Console.WriteLine((ProductWeight));
        Console.WriteLine((IsAvailable));
        Console.WriteLine(ProductId.GetType().FullName); // Output: System.Int32
        Console.WriteLine(productName.GetType().FullName); // Output: System.String
        Console.WriteLine(ProductPrice.GetType().FullName); // Output: System.Double
        Console.WriteLine(ProductWeight.GetType().FullName); // Output: System.Decimal
        Console.WriteLine(IsAvailable.GetType().FullName); // Output: System.Boolean


        Console.WriteLine("Practice 4");
        const double Pi = 3.14159;
        const decimal gst_rate = 0.18m;
        const string CollegeName = "ABC College";
        Console.WriteLine(Pi);
        Console.WriteLine(gst_rate);
        Console.WriteLine(CollegeName);

    }
}
