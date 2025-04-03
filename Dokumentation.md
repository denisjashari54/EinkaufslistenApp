# Projekt-Dokumentation

| Datum       | Version | Zusammenfassung                                              |
| ----------- | ------- | ------------------------------------------------------------ |
| 12.02.2025  | 0.0.1   | Beginn der Planungs- und Entwicklungsphase für die Auto-Website. Erstellung der Konzepte für Anmelde- und Registrierfunktionen sowie Struktur der Startseite und Unterseiten. |
| 19.02.2025  | 0.0.2   | Programmierung der Startseite begonnen, Aufteilung und Zuweisung der Unterseiten für verschiedene Automarken. |
| 26.02.2025  | 0.0.3   | Überarbeitung und Detailplanung der Website, Entwicklung der Anmelde- und Registrierfunktion sowie Erweiterung der Unterseiten für die Automarken. |
| 05.03.2025  | 0.0.3   | Revision der Website, Verfeinerung der Funktionen und Designs für die Startseite und die spezifischen Automarken-Seiten. |
| 12.03.2023  | 0.0.4   | Abschluss der Entwicklungsarbeiten, vorläufige Fertigstellung der Auto-Website, Beginn der Vorbereitung auf den Portfolioeintrag. |

## 1 Informieren

### 1.1 Ihr Projekt

MultiUserApplikation

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ         | Beschreibung                                     |
| ---- | --------------- | ----------- | ------------------------------------------------ |
| 1    | Muss            | Funktional  | Mehrere Benutzer können Artikel zur Einkaufsliste hinzufügen.  |
| 2    | Muss            | Funktional  | Benutzer können Artikel in der Einkaufsliste bearbeiten. |
| 3    | Kann            | Funktional  | Benutzer können Artikel als „gekauft“ markieren. |
| 4    | Muss            | Funktional  | Benutzer können Artikel löschen. |
| 5    | Muss            | Funktional  | Artikel werden in SSMS automatisch gespeichert und aktualisiert bei neuen Einträgen. |
| 6    | Muss            | Qualität  | Die Applikation soll über das Internet benutzbar sein. |
| 7    | Muss            | Qualität  | Die Applikation soll über ein lokales GUI (WPF) verfügen. |
| 8    | Muss            | Funktional    | Transaktionsmanagement soll sicherstellen, dass Datenkonsistenz gewährleistet wird. |

### 1.3 Testfälle

| TC-№ | Ausgangslage       | Eingabe                     | Erwartete Ausgabe                                    |
| ----- | ------------------ | --------------------------- | ---------------------------------------------------- |
| 1.1   | WPF-UI         | Klick auf "Hinzufügen"    | Neues Artikel wird hinzugefügt                |
| 1.2   | API (Swagger)         | POST-Anfrage tätigen   | Neues Artikel wird hinzugefügt                |
| 2.1   | WPF-Ui         | Klick auf "Bearbeiten"        | Artikel wurde bearbeitet. |
| 2.2   | API (Swagger)         | PUT-Anfrage tätigen        | Artikel wurde bearbeitet. |
| 3.1   | WPF-UI    | Klick auf "gekauft" | Artikel wird als "gekauft" markiert.            |
| 4.1   | WPF-UI | Klick auf "Löschen" | Artikel wird gelöscht.              |
| 4.1   | API (Swagger) | DELETE-Anfrage tätigen | Artikel wird gelöscht.              |
| 5.1   | SSMS    | Keine Eingabe        |  Artikel wird gespeichert und aktualisiert.               |
| 6.1   | Auto-Liste         | Klick auf ein Auto          | Detailansicht des gewählten Autos mit technischen Daten und Fotos |
| 7.1   | Beliebige Seite    | Navigation durch die Website | Einfache und intuitive Nutzung der Website          |


### 1.4 Diagramme

### Mockups


## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A | 15.06.2023 | Marku | Entwicklung der Registrierungsfunktion für Benutzerkonten. | 120' |
| 2.A | 22.06.2023 | Jashari | Implementierung der Anmeldefunktion für Benutzerkonten. | 120' |
| 3.A | 29.06.2023 | Bajramovic | Implementierung der Funktion zum Zurücksetzen von Passwörtern. | 60' |
| 4.A | 06.07.2023 | Bajramovic| Entwicklung der Filterfunktion für Autosuche nach Marken. | 180' |
| 5.A | 13.07.2023 | Marku | Implementierung der Sortierfunktion für Suchergebnisse. | 120' |
| 6.A | 20.07.2023 | Jashari | Programmierung der Detailansicht für Autos mit Fotos und Daten. | 180' |
| 7.A | 27.07.2023 | Angelov | Optimierung der Benutzerfreundlichkeit und Intuitivität der Website. | 240' |


## 3 Entscheiden


Wir haben in der Gruppe die Arbeitspakete fair verteilt, sodass wir alle zum Implementieren beitragen. Dadurch haben wir auch eine gute Zeiteinteilung erreicht.

## 4 Realisieren

| AP-№ | Datum      | Zuständig   | Geplante Zeit | Tatsächliche Zeit |
| ---- | ---------- | ----------- | ------------- | ----------------- |
| 1.A  | 15.06.2023 | Jashari       | 120'          |  110'                 |
| 2.A  | 22.06.2023 | Jashari     | 120'          |  100'                 |
| 3.A  | 29.06.2023 | Jashari  | 60'           |  50'                  |
| 4.A  | 06.07.2023 | Jashari  | 180'          |  140'                |
| 5.A  | 13.07.2023 | Jashari       | 120'          |  100'               |
| 6.A  | 20.07.2023 | Jashari     | 180'          |  140'              |
| 7.A  | 27.07.2023 | Jashari     | 240'          |  120'               |


## 5 Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum      | Resultat | Tester      |
| ---- | ---------- | -------- | ----------- |
| 1.1  | 12.01.2024 |   Funktioniert       | Jashari     |
| 2.1  | 12.01.2024 |   Funktioniert       | Jashari       |
| 3.1  | 12.01.2024 |   Funktioniert       | Jashari     |
| 4.1  | 12.01.2024 |   Funktioniert      | Jashari       |
| 5.1  | 12.01.2024 |   Funktioniert      | Jashari  |
| 6.1  | 12.01.2024 |   Funktioniert       | Jashari     |
| 7.1  | 12.01.2024 |   Funktioniert       | Jashari     |
