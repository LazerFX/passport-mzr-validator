passport-mzr-validator

Requires ASP.NET Core 2 to build, and is developed in Visual Studio Code.

Requires NPM / NodeJS at the latest available versions.

Uses the `dotnet new aurelia` framework to start-up.

To build, use `dotnet restore` and then `npm install`.

**Note:** If you are using the latest versions of NPM 
(5.4.?), you will run into errors on Windows.  To overcome this, use the command `npm install --no-optional`.

---

This application parses a Machine Readable Zone 2 from a passport, ensuring that its valid and real.