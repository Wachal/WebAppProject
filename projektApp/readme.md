Uruchomienie

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
```
Uruchomienie projektu
```
dotnet run
```

Przykładowe zapytania

Wpisy kart
* GET - https://localhost:7234/CardEntries
* POST -https://localhost:7234/CardEntries
```
{
    "cardNumber": "IdKarty"
}
```

Użytkownicy
* GET/POST
https://localhost:7234/People