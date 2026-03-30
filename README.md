INSTRUKCJA URUCHOMIENIOWA

Wymagania
- Zainstalowany .NET SDK
- Dowolny terminal (PowerShell/cmd) albo uruchomienie z Ridera

Uruchomienie
Należy wejść do folderu projektu (tam gdzie jest .sln) i uruchomić kolejno:

bash
dotnet run

Po uruchomieniu program odpala scenariusz demonstracyjny w Program.cs (dodaje przykładowe dane, wykonuje wypożyczenia/zwroty, pokazuje błędne przypadki i raporty).

DECYZJE PROJEKTOWE

Projekt podzieliłem na Domain, Services i Program.cs, żeby nie trzymać wszystkiego w jednym miejscu. 
W Domain są klasy opisujące dane i stan obiektów (sprzęt, użytkownicy, wypożyczenie), bez logiki działania. Cała logika biznesowa, czyli wypożyczanie, zwroty, limity, kary i raporty, jest w Services. 
Program.cs służy tylko do pokazania działania aplikacji w konsoli. Dzięki temu kod jest czytelniejszy i łatwiej go zrozumieć oraz rozbudować.

Logikę w Services rozbiłem na kilka klas, żeby każda robiła jedną konkretną rzecz. 
- RentalService obsługuje cały proces wypożyczenia i zwrotu oraz trzyma dane w pamięci, 
- RentalPolicy sprawdza reguły (czy sprzęt jest dostępny i czy użytkownik nie przekroczył limitu),
- PenaltyCalculation liczy karę za spóźnienie. Dzięki temu reguły są w jednym miejscu i łatwo je zmienić.
  
Zamiast wyjątków użyłem out string message, bo to aplikacja konsolowa i zależało mi na prostych komunikatach dla użytkownika.
Sytuacje typu brak sprzętu albo przekroczony limit to nie są błędy programu, tylko normalne przypadki, więc metoda zwraca true/false, a message mówi dokładnie co poszło nie tak.
Jest to proste, czytelne i według mnie dobrze pasuje do scenariusza demonstracyjnego.
