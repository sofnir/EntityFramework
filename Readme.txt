Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

Db first simple example:
Scaffold-DbContext "Server=DESKTOP-GUK2RJ2;Database=DatabaseFirstSimpleExample;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Code first:
Install-Package Microsoft.EntityFrameworkCore.Design
Add-Migration Initial
Update-Database