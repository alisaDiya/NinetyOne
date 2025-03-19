# NinetyOne
## Overview and Features

### Manual CSV Parsing
The application parses a CSV file listing people and their scores without using a standard CSV library.

### Database
Stores parsed data in a SQL Server database (local or remote).

### Top Scorers
Displays or returns the highest-scoring individuals, handling multiple top scorers by alphabetical order.

### RESTful API
Exposes endpoints to:
- **POST** new scores (create or update).
- **GET** a specific person’s score.
- **GET** the top scorer(s).

---
---

## Prerequisites

### Software
- **.NET 6+ or .NET 7+ SDK**  
  Download from [Microsoft .NET Download](https://dotnet.microsoft.com/download) if not installed.
- **SQL Server (Developer or Express Edition)**  
  Download from [SQL Server Downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).  
  Make sure SQL Server is running locally or you have access to a remote SQL Server instance.
- **SQL Server Management Studio (SSMS) or Azure Data Studio (optional)**  
  Recommended for viewing or managing the database.

### Hardware
- **CPU:** Dual-core processor (or equivalent) recommended.
- **Memory:** Minimum 4 GB of RAM (8 GB+ recommended for smoother performance).
- **Disk Space:** ~1 GB free for .NET, SQL Server, and the project files.

## Security + Cloud 
- You can secure API endpoints using token-based (JWT), API key, or Basic Auth over HTTPS.
- Token-based auth validates a JWT in an Authorization header, and API keys rely on shared secrets.
- For cloud hosting, Azure offers App Service/Container Instances, Azure SQL, and Key Vault.

