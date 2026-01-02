# corebankingtest

## Login Flow
- User enters username and password
- Application validates credentials against SQL Server
- Only active users (IsActive = 1) are allowed to log in
- User role is loaded after successful login

## Notes
- Connection string is stored in App.config
- Database files are not included in the repository
- Built with C# WinForms and SQL Server
