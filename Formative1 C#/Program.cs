using System;
using System.Xml.Serialization;
// Morrgage Calculator
class MortgageCalculatoring
{ 
    //main methos of the class
    public static void Main(string[] args)
    {

        bool exit = false ;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" This is your morgage calculator speaking ");
        Console.ResetColor();
        Console.WriteLine();

        while (!exit)
        {
            Console.WriteLine(" please pick a choice ");
            Console.WriteLine("1. Display your monthly replayment amount ");
            Console.WriteLine("2. All intrest paid over the life of the loan ");
            Console.WriteLine("3. amount paid over the life of the loan (principle + intrest ) ");
            Console.WriteLine("4. Amortization schedule ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5. exit ");
            Console.ResetColor();
            Console.WriteLine();

            int decision;
            // ERROR HANDLING FOR USER INPUT
            if ( !int.TryParse(Console.ReadLine(), out decision))
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine(" unsuccessful input. Please enter the numbers presented");
                Console.ResetColor();
                continue;


            }
            // Switvh case for choosing the input from the user
            switch(decision)
            {
                case 1:
                    CalcMonthlyRepayment();
                    break;
                case 2:
                    calculateTotalInterestPaid();
                    break;
                case 3:
                    CalculateTotalAmountpaid();
                    break;  
                case 4:
                    AmortizationSchedule();
                    break;
                case 5:
                    
                    
                    exit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" option has been rejected, Please enter correct option");
                    Console.ResetColor();
                    break;

            }

        }
    }
    // Method for calculating mothod repayment 
    private static void CalcMonthlyRepayment()
    {
        Console.WriteLine(" please enter that loan buddy");
        double loanAmount;
        if (!double.TryParse(Console.ReadLine(), out loanAmount) || loanAmount < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Very wrong intrest rate . Enter a NON-NEGATIVE number  ");
            Console.ResetColor();
            return;
        }
        
        Console.WriteLine(" Enter annual intrest rate");
        double yearlyIntrestRate;
        if (!double.TryParse(Console.ReadLine(),out yearlyIntrestRate) || yearlyIntrestRate <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a NON-NEGATIVE NUMBER ");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Enter the loan term (in years):");
        int LTearmYears;

        // error handling loan amount input 
        if (!int.TryParse(Console.ReadLine(),out  LTearmYears) || LTearmYears <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE  number ");
            Console.ResetColor();
            Console.ResetColor();
            return;

        }

        double monthlyIntRate = yearlyIntrestRate / 12 / 100;
        int totalMonths = LTearmYears * 12;

        double monthlypayments =loanAmount * ( monthlyIntRate * Math.Pow(1 + monthlyIntRate,totalMonths) )/ (Math.Pow(1 + monthlyIntRate, totalMonths) -1);
        
        // Show the monthly repayment amount 
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" This is your monthly repayment amount : R" + Math.Round(monthlypayments,2));
        Console.ResetColor();
        Console.WriteLine();

    }
    // method for calculating total paid interest over the life of the loan
    private static void calculateTotalInterestPaid()
    {
        Console.WriteLine(" please enter that loan buddy");
        double loanAmount;
        if (!double.TryParse(Console.ReadLine(), out loanAmount) || loanAmount < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE Number ");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(" Enter annual intrest rate buddy");
        double yearlyIntrestRate;

        // error handling for the annual interest rate 
        if (!double.TryParse(Console.ReadLine(), out yearlyIntrestRate) || yearlyIntrestRate <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE Number ");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Enter the loan term (in years):");
        int LTearmYears;
        // error handling loan amount input 
        if (!int.TryParse(Console.ReadLine(), out LTearmYears) || LTearmYears <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVENumber  ");
            Console.ResetColor();
            return;

        }
        // Calculate monthly interest rate and total months
        double monthlyIntRate = yearlyIntrestRate / 12 / 100;
        int totalMonths = LTearmYears * 12;

        // Initialize variables for total interest and remaining balance
        double totalInterests = 0;
        double leftBalance = loanAmount;

        // Loop through each month and calculate interest
        for (int i = 0; i < totalMonths; i++)
        {

            double monthlyInterest = leftBalance * monthlyIntRate;
            totalInterests += monthlyInterest;
            leftBalance -= (loanAmount * monthlyInterest - (monthlyInterest * loanAmount * monthlyIntRate));
        }

        // Display the paid intrdt over the life of the loan
        Console.WriteLine(" This is your TOTAL amount of paid interest over the life of the loan: R" + Math.Round(totalInterests,2));
        Console.WriteLine();
    }
    private static void CalculateTotalAmountpaid()
    {

        Console.WriteLine(" please enter that loan buddy");
        double loanAmount;

        // error handling loan amount input 
        if (!double.TryParse(Console.ReadLine(), out loanAmount) || loanAmount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red ;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE Number ");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(" Enter annual intrest rate buddy");
        double yearlyIntrestRate;
        // error handling for the annual interest rate 
        if (!double.TryParse(Console.ReadLine(), out yearlyIntrestRate) || yearlyIntrestRate <= 0)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE Number ");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Enter the loan term (in years):");
        int LTearmYears;

        // error handling loan amount input 
        if (!int.TryParse(Console.ReadLine(), out LTearmYears) || LTearmYears <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE Number  ");
            Console.ResetColor();
            Console.WriteLine();
            return;

        }
        // Calculate monthly interest rate and total months
        double monthlyIntRate = yearlyIntrestRate / 12 / 100;
        int totalMonths = LTearmYears * 12;

        double monthlyPayment = loanAmount * (monthlyIntRate * Math.Pow(1 + monthlyIntRate, totalMonths)) / (Math.Pow( 1 + monthlyIntRate, totalMonths)-1);
        double aquiredAmounPaid = monthlyPayment * totalMonths;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Total amount paid over the life of the laon (principal + interest): R" + Math.Round(aquiredAmounPaid, 2));
        Console.ResetColor();
        Console.WriteLine();


    }
   // Method for generating amortization schedule
    private static void AmortizationSchedule()
    {


        Console.WriteLine(" please enter that loan buddy");
        double loanAmount;

        // error handling loan amount input 
        if (!double.TryParse(Console.ReadLine(), out loanAmount) || loanAmount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE Number ");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(" Enter annual intrest rate buddy");
        double yearlyIntrestRate;
        if (!double.TryParse(Console.ReadLine(), out yearlyIntrestRate) || yearlyIntrestRate <= 0)
        {
            // Show error message for wrong input
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected . Please enter a POSITIVE Number ");
            Console.ResetColor();
            return;
        }
        // Error handling for the loan input 
        Console.WriteLine("Enter the loan term (in years):");
        int LTearmYears;
        if (!int.TryParse(Console.ReadLine(), out LTearmYears) || LTearmYears <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Input rejected. Please enter a POSITIVE Number ");
            Console.ResetColor();
            Console.WriteLine();
            return;

        }

        // User is promted to enter the dat ee
        Console.WriteLine(" Enter the start date of the loan (yyyy-MM-dd): ");
        DateTime startDate;
        if (!DateTime.TryParse(Console.ReadLine(), out startDate))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Invalid input. Please enter a valid date in the format yyyy-MM-dd.");
            Console.ResetColor();
            return;
        }

        // Calculate end date of the loan
        DateTime endDate = startDate.AddYears(LTearmYears);

        // Calculate monthly interest rate and total months
        double monthlyIntRate = yearlyIntrestRate / 12 / 100;
        int totalMonths = LTearmYears * 12;

        double monthlyPayment = loanAmount * (monthlyIntRate * Math.Pow(1 + monthlyIntRate, totalMonths)) / (Math.Pow(1 + monthlyIntRate, totalMonths) - 1);


        // Show the header of the amoritization Schedule
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------");
        Console.WriteLine(" Amortization Schedule ");
        Console.WriteLine("------------------------------------");
        Console.ResetColor();
        Console.WriteLine();    

        // Loan Start date 

        Console.WriteLine($"Loan Start Date: {startDate.ToShortDateString()}");
        Console.ForegroundColor= ConsoleColor.Red;    
        Console.WriteLine($"Loan End Date: {endDate.ToShortDateString()}");
        Console.ResetColor();

        Console.WriteLine(" Month\t Principle\t Interest\t Remaining Balance ");

        double leftBalance = loanAmount;

        for (int i = 1; i <= totalMonths; i++)
        {
            double monthlyInterest = leftBalance * monthlyIntRate;
            double princPay = monthlyPayment -monthlyInterest;
            leftBalance=leftBalance -princPay;

            Console.WriteLine($"{i}\tR{Math.Round(princPay,2)}\t\tR{Math.Round(monthlyInterest,2)}\t\t R{Math.Round(leftBalance)}");
            
        }

    }


   

}