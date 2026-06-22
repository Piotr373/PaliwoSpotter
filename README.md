# PaliwoSpotter 

**PaliwoSpotter** to aplikacja konsolowa (docelowo Web API / Mobile) służąca do crowdsourcingowego monitorowania cen paliw na stacjach benzynowych w czasie rzeczywistym. Projekt powstał z myślą o kierowcach, którzy chcą wspólnie walczyć z drożyzną, dzieląc się aktualnymi stawkami ze stacji w swojej okolicy.

Aplikacja kładzie ogromny nacisk na wiarygodność danych (system reputacji) oraz nowoczesne podejście do danych przestrzennych (wyszukiwanie stacji na mapie).

---

##  Główne Funkcjonalności

* **Geolokalizacja Stacji (Spatial Data):** Przechowywanie dokładnych współrzędnych stacji za pomocą typu `GEOGRAPHY`. Umożliwia to błyskawiczne wyszukiwanie najbliższych stacji w promieniu "X" kilometrów bezpośrednio przez bazę danych.
* **System Raportów Cenowych:** Użytkownicy mogą na bieżąco zgłaszać aktualne ceny dla konkretnych typów paliw (Pb95, Pb98, Diesel, LPG) na wybranej stacji.
* **Mechanizm Anty-Troll (Reputation System):** Każdy użytkownik zbiera punkty reputacji. Zgłoszenia od użytkowników z wyższą reputacją mają większą wagę, co eliminuje fałszywe lub żartobliwe raporty cenowe.
* **Pełna Relacyjność:** Ścisłe powiązanie raportów z użytkownikami, markami sieciowymi (np. Orlen, BP) oraz konkretnymi lokalizacjami.

---

##  Tech Stack (Użyte Technologie)

* **Język:** C# (.NET 8.0 / .NET 9.0)
* **Dostęp do bazy danych (ORM):** Entity Framework Core (Podejście Code-First)
* **Baza danych:** Microsoft SQL Server (LocalDB)
* **Obsługa GIS / Map:** NetTopologySuite (NTS)
* **Zarządzanie kodem:** Git / GitHub

---

## Architektura Bazy Danych (ERD)

Aplikacja korzysta z w pełni zrelacjonowanej bazy danych SQL. Poniższy schemat przedstawia relacje między tabelami (Użytkownicy, Stacje, Marki, Typy Paliw oraz Raporty Cenowe):


![Schemat Relacji Bazy Danych](Images/database_schema.png)

---

##  Czego się nauczyłem podczas tego projektu?

1.  **Mapowanie Obiektowo-Relacyjne (ORM):** Praktyczne wykorzystanie Entity Framework Core do projektowania bazy danych bezpośrednio z poziomu kodu C# (Code-First), zarządzanie migracjami (`Add-Migration`, `Update-Database`).
2.  **Zaawansowane typy danych w SQL:** Konfiguracja i optymalizacja zapytań przestrzennych z użyciem typu `GEOGRAPHY` i biblioteki NetTopologySuite, zamiast przechowywania współrzędnych jako zwykłe liczby (double/string).
3.  **Projektowanie logiki biznesowej:** Stworzenie systemu opartego na relacjach Jeden-do-Wielu (One-to-Many) z silnym naciskiem na integralność danych (brak anonimowych wpisów w celu ochrony przed manipulacją cenami).

---

##  Jak uruchomić projekt lokalnie?

1. Sklonuj repozytorium:
   ```bash
   git clone [https://github.com/Piotr373/PaliwoSpotter.git](https://github.com/Piotr373/PaliwoSpotter.git)
