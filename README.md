PawfectCareLtd - Project Setup Instructions
===========================================

Follow these steps to properly set up and run the PawfectCareLtd project using Visual Studio 2022 and SQL Server Management Studio (SSMS).

-----------------------------------
1. Clone the Project in Visual Studio 2022 (Link: https://github.com/Nahida-22/PetCareManagement) 
-----------------------------------
- Open Visual Studio 2022.
- Clone the project repository using Git or open the folder containing the solution files.
Link: https://github.com/Nahida-22/PetCareManagement
-----------------------------------
2. Open the Solution
-----------------------------------
- In Visual Studio, navigate to the **Solution Explorer.
  (If it's not visible, go to the menu: View > Solution Explorer, or press Ctrl+Alt+L).
- Locate and double-click the `PawfectCareLtd.sln` file.
- You should now see three folders:
  - PawfectCareLimited (WinForms)
  - PawfectCareLtd
  - Testing

-----------------------------------
3. Configure the SQL Server Connection
-----------------------------------
- Open SQL Server Management Studio (SSMS).
- In the Connect to Server window:
  - Set the Server Type to: Database Engine.
  - Take note of the Server Name EXACTLY as shown (pay attention to capitalization, spaces, or symbols).
  - Click Connect (keep SSMS open).

-----------------------------------
4. Update the Connection String in appSettings
-----------------------------------
- Back in Visual Studio:
  - Open the `PawfectCareLtd` folder from Solution Explorer.
  - Open the file `appSettings.Development.json`.
- Locate the connection string and update it to use your SSMS server name:

  Example:
"ConnectionStrings": { "DefaultConnection": "Data Source=YOUR_SERVER_NAME;Initial Catalog=PawfectCareDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;" }


Replace `YOUR_SERVER_NAME` with your actual SSMS server name.

-----------------------------------
5. Install Required NuGet Packages
-----------------------------------
- Go to: Tools > NuGet Package Manager > **Package Manager Console**.
- Run the following command to install all required packages:

1. Install-Package EFCore.BulkExtensions -Version 8.0.0
2. Install-Package Microsoft.AspNetCore.Components.WebAssembly -Version 8.0.0
3. Install-Package Microsoft.EntityFrameworkCore -Version 9.0.4 
4. Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 9.0.4 
5. Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 9.0.2 
6. Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.2
7. Install-Package Microsoft.SqlServer.Server -Version 1.0.0 
8. Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 8.0.7 
9. Install-Package Moq -Version 4.20.72
10. Install-Package Newtonsoft.Json -Version 13.0.3 
11. Install-Package Swashbuckle.AspNetCore -Version 6.6.2 
12. Install-Package Microsoft.NET.Test.Sdk -Version 17.12.0 
13. Install-Package MSTest -Version 3.6.4


-----------------------------------
6. Apply the Initial Database Migrations
-----------------------------------
- In the Package Manager Console, run the following command:


-----------------------------------
7. Configure Startup Projects
-----------------------------------
- In the Solution Explorer:
  - Right-click on the solution `Solution 'PawfectCareLtd' (3 of 3 projects)`.
  - Click Properties.
  - Under **Common Properties > Startup Project**, select **Multiple startup projects**.
  - Set the following:
    - `PawfectCareLtd` => Action: Start
    - `PawfectCareLimited` (WinForms) => Action: Start
  - Click Apply, then OK.

-----------------------------------
8. Run the Application
-----------------------------------
- Navigate to the `Program.cs` file inside the `PawfectCareLtd` folder.
- Click Run (Start Debugging).
- Wait until the Command Prompt (CMD) finishes executing.
- Once complete, Swagger should open automatically in your web browser.
- You can now begin using the WinForms interface.

Link to our video in better resolution:[ https://livemdxac-my.sharepoint.com/:v:/r/personal/nr681_live_mdx_ac_uk/Documents/Video-%20PawfectCareLtd/YouCut_20250416_162820695.mp4?csf=1&web=1&nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0NvcHkifX0&e=P6Uhvb](https://livemdxac-my.sharepoint.com/:f:/g/personal/nr681_live_mdx_ac_uk/EjRP0DSN1NRCqvtqfkRzKoYBvbrwC76deSLBERj6HBf4ZA?e=sdkWNu)
