# Banken
Välkommen till banken! Konsolapplikation byggt i Visual Studio med C#.

# Struktur av koden
Till att börja med så har applikationen flera olika menyer. När man öppnar applikationen så välkommnas man till en liten inloggningsmeny som har två val: det inkluderar inloggningen samt exit. Efter att man har loggat in så visas huvudmenyn. Själva inloggningen använder en metod som kontrollerar uppgifterna som användaren fyller i. Användaren får tre chanser på att fylla i rätt uppgifter innan applikationen stängs ner.

Efter att ha loggat in kommer man som sagt till huvudmenyn som innehåller alla val relaterade till ens bankkonto. Här kan man se över ens konton samt överföra eller ta ut pengar. Annars kan man logga ut.

Accounts and balances använder en metod som skriver ut ens konton och hur mycket pengar som finns tillgängligt på varje konto medan transfer samt withdraw använder sig av några lättare while-loopar som ser till att du bara kan överföra samt ta ut pengar om det är möjligt. Man kan t.ex. inte överföra 1000 kr till ett annat konto om inte kontot som ska överföra pengarna redan har minst 1000 kr tillgängligt. Förutom det är utloggningsfunktionen väldigt simpel och det finns inte så mycket mer att säga om den än att den loggar ut användaren och tar tillbaka användaren till inloggningsmenyn.

# Reflektion
Anledningen till att jag bestämde för att bygga applikationen med hjälp av flera olika menyer var för att det bidrog med en struktur som gjorde att blev lättare att skriva koden. Då transfer samt withdraw metoderna var så pass lika varandra blev det lättare att bygga den andra metoden efter att ha byggt den första metoden.

Jag hade egentligen inte några andra idéer för applikationen: jag kände att det här var den mest effektiva lösningen. Applikationen känns dock väldigt fast så det kanske finns några bättre lösningar kring just den punkten. Det är en av anledningarna till att jag utformade applikationen på ett sätt som gjorde det möjligt för navigation med hjälp av tangenter: på så sätt känns applikationen lite mer flexibel.