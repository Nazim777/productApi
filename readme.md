1. install entity framework
dotnet tool install --global dotnet-ef --version 7.0.0
2. add package entity framework design
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
or we can install package from nuget package manager
click -> f1
3. verify instalation
dotnet ef
4.  Enter scaffold command 
dotnet ef dbcontext scaffold "Server=DESKTOP-QUDMRGS\SQLEXPRESS;Database=testdb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
5. install sql server entity framework
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0
6. retore the package
dotnet restore
