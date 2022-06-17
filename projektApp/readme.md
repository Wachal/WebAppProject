#Uruchomienie aplikacji

Przejście do katalogu
```
cd WebAppProject\projektApp\ProjektApp.Rest
```
Utworzenie migracji
```
dotnet ef migrations add InitialCreate
```

Utworzenie bazy danych i schematu
```
dotnet ef database update
```

Uruchomienie projektu
```
dotnet run
```

Opublikowanie projektu
```
dotnet publish -c Release -r linux-x64 -o publish
```

#Przykładowe zapytania API

Wpisy kart
* GET - https://localhost:7234/CardEntries
* POST - https://localhost:7234/CardEntries
```
{
    "cardNumber": "IdKarty"
}
```

Dodanie/pobranie użytkownika
```
{
    "FirstName": "Jan",
    "LastName": "Kowalski", 
    "CardNumber": "NumerKartyDwa"
}
```

#Endpointy/strony

Użytkownicy
* GET/POST
https://localhost:7234/People
https://localhost:7234/CardEntries

Strona główna aplikacji
https://localhost:7234/Home