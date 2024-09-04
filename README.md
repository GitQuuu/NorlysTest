# NorlysTest

Til denne opgave er der blevet anvendt, Separation of concerns, Vertical slice architecture, N-layer pattern ( ikke N-Tier ), Request-Response pattern,SOLID
Der er blevet anvendt en sql lite database app.db for at gøre det nemt mht. miljøer.

For at se app.db i visual studio gør følgende :

1.Go to Extensions > Manage Extensions.
2.In the search box, type SQLite/SQL Server Compact Toolbox.
3.Install the extension. This toolbox allows you to easily connect to and browse SQLite database files.
4.Restart Visual Studio after installing the extension.
5.After installing the extension, go to View > SQL Server Compact/SQLite Toolbox to open the toolbox window.
6.In the toolbox window, right-click and select Add SQLite Connection….
7.Navigate to your app.db file and select it. Make sure the Database Type is set to SQLite.
8.Click OK to connect to the database.

Der findes en employee med id: 22 og 3 offices med id 1,2 og 3

**********************************************************************************************

Jeg har valgt at anvende en N-layer pattern for den logiske indeling af kodebasen.  Man skulle meget gerne bare spinne API op via launchsettings og se swagger og teste der igennem.

Udover dette er der anvendt vertical slice architecture for at indele koden i features og ikke i tekniske detalje, hvilket giver bedre overblik og maintainability.

Der er anvendt request-response pattern præsentations laget ( api )

I N-lags mønster går dataflow fra top til bund,  API --> Services --> DAl, de alle sammen har en reference til Infrastruktur biblioteket som indeholder nuget pakker.

BLL ( Business logic laget ) somn findes i service bibloteket agere som en higher orchestration som sikre at der ikke kommer cirkulære afhængigheder imellem servisene.

Der er anvendt dependency injection som følge af SOLID principperne.

Alt sensitive information vil jeg gemme i en keyvault som APIen så bliver fodret med fra azure.

Logging vil jeg anvende serilog og kibana.

Unit testing vil jeg anvende NUnit

Performance er noget man tager når det kommer, jeg har lært at man ikke skal optimere for tidligt.

Der står i opgaven at microorm er tilladt men Entity Framework er ikke. Jeg er code-first og har altid brugt EF til dette, jeg gik udfra det er for at se mine sql færdigheder og ikke linq. Sql er det jeg har haft mest udfordring med i denne opgave.

Hvad jeg ville have gjort anderledes? Hvis jeg måtte bruge linq , havde jeg rykket alt dataaccess over i Data access laget og implementeret repository pattern og unit of work. 