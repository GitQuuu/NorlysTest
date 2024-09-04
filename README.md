# NorlysTest
Jeg har valgt at anvende en N-layer pattern for den logiske indeling af kodebasen. Der er blevet anvendt en sql lite database app.db for at gøre det nemt mht. miljøer. Man skulle meget gerne bare spinne API op via launchsettings og se swagger og teste der igennem.

Udover dette er der anvendt vertical slice architecture for at indele koden i features og ikke i tekniske detalje, hvilket giver bedre overblik og maintainability, idet at der ikke findes controllers med over 1000 linie kode, hellere ikke i fremtiden.

I N-lags mønster går dataflow fra top til bund,  API --> Services --> DAl, de alle sammen har en reference til Infrastruktur biblioteket som indeholder nuget pakker.

BLL ( Business logic laget ) somn findes i service bibloteket agere som en higher orchestration som sikre at der ikke kommer cirkulære afhængigheder imellem servisene.

Der er anvendt dependency injection som følge af SOLID principperne.

Alt sensitive information vil jeg gemme i en keyvault som APIen så bliver fodret med fra azure.

Logging vil jeg anvende serilog og kibana.

Unit testing vil jeg anvende NUnit

Performance er noget man tager når det kommer, jeg har lært at man ikke skal optimere for tidligt.

Der står i opgaven at microorm er tilladt men Entity Framework er ikke. Jeg er code-first og har altid brugt EF til dette, jeg gik udfra det er for at se mine sql færdigheder og ikke linq. Sql er det jeg har haft mest udfordring med i denne opgave.

Hvad jeg ville have gjort anderledes? Hvis jeg måtte bruge linq , havde jeg rykket alt dataaccess over i Data access laget og implementeret repository pattern og unit of work.