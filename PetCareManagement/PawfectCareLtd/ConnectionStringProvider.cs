// Import dependencies.
using Microsoft.Data.SqlClient; // Import SQL Server data provider.
using Microsoft.EntityFrameworkCore; // Import the entity framework for databases related operation.


namespace PawfectCareLtd // Define the namespace for the application.
{
    // Class responsible for the getting the database connection.
    public class ConnectionStringProvider
    {


        // Public method to get the connection string.
        public static string ConnectionString(string[] args)
        {
            try
            {
                // Call the method to determine which connection string to use.
                return GetUserChoice(args);

            }
            catch (Exception e) // Catch any expection that may happens.
            {
                Console.WriteLine(e.Message); // Output the error message.
                return null; // Return null to prevent errors.
            }
        }


        // Method to determine which connection string to use.
        private static string GetUserChoice(string[] args)
        {
            try
            {
                Console.Write("Do you want use Default Connection? (Y/N): "); // Prompt the user to enter which default string they want to use.
                string userChoice = ValidateYesOrNoInput(); // Validates the user input and store it.

                // Checks if the user choose to use if default connection.
                if (userChoice == "TRUE")
                {
                    return GetConnectionDetails(args); // Get the default connection string.
                }
                else
                {
                    return GetUserConnectionDetails(args); // Get the custom connection string
                }

            }
            catch (Exception e) // Catch any expection that may happens.
            {
                Console.WriteLine(e.Message); // Output the error message.
                return null; // Return null to prevent errors.
            }
        }


        // Method to retrive the default connection string.
        private static string GetConnectionDetails(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args); // Create a builder instance.
                string connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Retrive the default connections string.

                // Check if the default connection string is able to connect to SSMS.
                if (TestDatabaseConnection(connectionString))
                {
                    return connectionString; // Return the valid default connection string.
                }
                else
                {
                    // Error message and tell user to if they want to retry with the custom connection string.
                    Console.WriteLine("Fail to connect to SQL Server Management System.");
                    Console.Write("Do want to retry by entering a custom connection string (Y/N): ");

                    // If the user choose to do not retry.
                    if (ValidateYesOrNoInput() == "FALSE")
                    {
                        return null; // Return null to prevent errors.
                    }
                    else
                    {
                        return GetUserConnectionDetails(args); // Get the custom connection string.
                    }
                }
            }
            catch (Exception e) // Catch any expection that may happens.
            {
                Console.WriteLine(e.Message); // Output the error message.
                return null; // Return null to prevent errors.
            }
        }


        // Method to retrive the custom connection string.
        private static string GetUserConnectionDetails(string[] args)
        {
            try
            {
                Console.WriteLine("Enter your SQL Server Management System detail:"); // Prompt the user to enter the custom connection stringfor the SSMS connection.

                // Data source for the custom connection string.
                Console.Write("Data Source (Server Name): "); // Prompt the user to enter the data source.
                string dataSource = ValidateForNonEmptyInput(); // Validates the user input and store it.

                // Data source for the custom connection string.
                Console.Write("Integrated Security (Y/N): "); // Prompt the user to enter the integrated security.
                string integratedSecurity = ValidateYesOrNoInput(); // Validates the user input and store it.

                // Data source for the custom connection string.
                Console.Write("Encrypt (Y/N): "); // Prompt the user to enter the encrypt.
                string encrypt = ValidateYesOrNoInput(); // Validates the user input and store it.

                // Data source for the custom connection string.
                Console.Write("Trust Server Certificate (Y/N): "); // Prompt the user to enter the trust server certificate.
                string trusServerCertificate = ValidateYesOrNoInput(); // Validates the user input and store it.

                // Create the custom connection string.
                string connectionString = $"Data Source={dataSource};Database=PawfectCareDB;Integrated Security={integratedSecurity};Encrypt={encrypt};Trust Server Certificate={trusServerCertificate};";

                // Check if the custom connection string is able to connect to SSMS.
                if (TestDatabaseConnection(connectionString))
                {
                    return connectionString; // Return the valid custom connection string.

                }
                else
                {
                    // Error message and tell user to if they want to retry with the default connection string.
                    Console.WriteLine("Fail to connect to SQL Server Management System.");
                    Console.Write("Do want to retry by using the default connection (Y/N): ");

                    // If the user choose to do not retry.
                    if (ValidateYesOrNoInput() == "FALSE")
                    {
                        return null; // Return null to prevent errors.
                    }
                    else
                    {
                        return GetConnectionDetails(args); // Check the default connection string.
                    }
                }
            }
            catch (Exception e) // Catch any expection that may happens.
            {
                Console.WriteLine(e.Message); // Output the error message.
                return null; // Return null to prevent errors.
            }
        }


        // Method to valida yes or no input.
        private static string ValidateYesOrNoInput()
        {
            try
            {
                while (true)
                {

                    // Read and store a formated version of the user input.
                    string userChoice = Console.ReadLine().Trim().ToUpper();

                    // Checked if the input is valid. 
                    if (userChoice == "Y" || userChoice == "N")
                    {
                        return ConvertYesOrNoToBool(userChoice); // Convert the input to a boolean string.
                    }

                    // Prompt user to enter their input if a wrong input has been inputed.
                    Console.Write("Input is invalide. Input only Y or N: ");
                }

            }
            catch (Exception e) // Catch any expection that may happens.
            {
                Console.WriteLine(e.Message); // Output the error message.
                return null; // Return null to prevent errors.
            }

        }


        // Method to validate non empty user input.
        private static string ValidateForNonEmptyInput()
        {
            try
            {
                while (true)
                {
                    // Read and store a formated version of the user input.
                    string userInput = Console.ReadLine().Trim().ToUpper();

                    // Checked if the input is not empty. 
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        return userInput; // Return the a valid input.
                    }

                    // Prompt user to enter their input if a wrong input has been inputed.
                    Console.WriteLine("Input cannot be empty. Try again.");
                }
            }
            catch (Exception e) // Catch any expection that may happens.
            {
                Console.WriteLine(e.Message); // Output the error message.
                return null; // Return null to prevent errors.
            }

        }


        // Method to convert y or n to a boolean string like.
        private static string ConvertYesOrNoToBool(string charInput)
        {
            return charInput == "Y" ? "TRUE" : "FALSE"; // Return 'TRUE' if 'Y' and 'FALSE' if 'N'.
        }


        // Method to test the connection string to the database..
        private static bool TestDatabaseConnection(string connectionString)
        {
            try
            {
                using var connection = new SqlConnection(connectionString); // Create an SQL connection.
                connection.Open(); // Try to open the SQL connection.
                Console.WriteLine("Able to connect to SQL."); // Output a messages show that SQL connection has been sucessful.
                return true; // Return true if SQL connection has been a success.
            }
            catch
            {
                Console.WriteLine("Not able to connect to SQL."); // Output a messages show that SQL connection has been unsucessful.
                return false; // Return false if SQL connection has been unsuccessful.
            }
        }
    }
}