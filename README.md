# OliveApp.Legacy

## What this is

A minimal, genuinely buildable **ASP.NET MVC 5 application on .NET Framework 4.8**, using classic **Entity Framework 6** for data access against SQL Server. It's a real, structurally correct legacy project — not a stub — meant to serve as the actual "before" state that AWS Transform for .NET assesses and modernizes.

## Why it exists

The client portal application deployed for Olive & Olive was built directly on .NET 8. That's fine for the deployed environment, but it meant there was nothing legacy for AWS Transform to genuinely modernize when introducing AWS Transform into the engagement. This project fills that gap: it's a real .NET Framework 4.8 / MVC 5 / EF6 solution, structurally equivalent in shape to the modernized `OliveApp` (same `Customers` entity, same basic CRUD-style read path), so AWS Transform's output can be meaningfully compared against what's already deployed.

## Project structure

```
OliveApp.Legacy.csproj      Old-style (non-SDK) MSBuild project targeting net48
packages.config              Legacy NuGet package references (EntityFramework, MVC 5)
Web.config                    App config + legacy SQL Server connection string
Global.asax / .cs             Application entry point
App_Start/                    Standard MVC 5 route/filter/bundle config
Controllers/                  HomeController, CustomersController (synchronous, EF6)
Models/Customer.cs            EF6 entity, mirrors the Customers table
Data/OliveLegacyDbContext.cs  Classic EF6 DbContext
Views/                        Razor views (.cshtml)
```

## Next steps — feeding this into AWS Transform

1. **Push this to its own GitHub repository** (separate from `olive-app`, since this represents a distinct, pre-modernization codebase):
   ```bash
   cd olive-legacy-app
   git init
   git add .
   git commit -m "Initial commit: Olive legacy client portal (ASP.NET MVC 5 / .NET Framework 4.8)"
   git branch -M main
   git remote add origin https://github.com/<your-org>/olive-app-legacy.git
   git push -u origin main
   ```

2. **Open AWS Transform** (console, or Visual Studio extension) and create a new .NET modernization job.

3. **Connect the repository** — via AWS CodeConnections, a GitHub Personal Access Token, or an S3 zip upload of this folder.

4. **Let AWS Transform assess the solution.** It will scan the project, identify it as an ASP.NET MVC 5 project targeting .NET Framework 4.8, and produce a modernization plan (repository topology, package migration map, transformation strategy).

5. **Review the plan**, resolve any missing package dependencies it flags, and approve the transformation.

6. **Download the artifacts** — the assessment report, modernization plan, transformed code, and transformation report. These are the genuine AWS Transform outputs to include as evidence in the competency documentation.

7. **Compare the transformed output against the already-deployed `OliveApp`** (.NET 8) — they don't need to match line-for-line, but the comparison demonstrates AWS Transform's modernization output aligns with the real, deployed target architecture.
