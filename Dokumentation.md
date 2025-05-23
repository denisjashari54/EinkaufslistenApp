# Projekt-Dokumentation
Umser
| Datum       | Version | Zusammenfassung                                              |
| ----------- | ------- | ------------------------------------------------------------ |
| 12.02.2025  | 0.0.1   | Beginn der Planungs- und Entwicklungsphase für die Multi-User Applikation.  |
| 19.02.2025  | 0.0.2   | Umsetzung der Kernfunktionen. |
| 26.02.2025  | 0.0.3   | Finalisierung des Projekts. |

## 1 Informieren

### 1.1 Ihr Projekt

Die Anwendung ermöglicht mehreren Benutzern ihre Einkäufe zentral zu verwalten. Über eine WebAPI und WPF-GUI können Einträge erstellt, gelesen, aktualisiert und gelöscht werden. Die Daten werden sicher in einer SQL-Datenbank gespeichert.

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
| 2.1   | WPF-UI         | Klick auf "Bearbeiten"        | Artikel wurde bearbeitet. |
| 2.2   | API (Swagger)         | PUT-Anfrage tätigen        | Artikel wurde bearbeitet. |
| 3.1   | WPF-UI    | Klick auf "gekauft" | Artikel wird als "gekauft" markiert.            |
| 4.1   | WPF-UI | Klick auf "Löschen" | Artikel wird gelöscht.              |
| 4.1   | API (Swagger) | DELETE-Anfrage tätigen | Artikel wird gelöscht.              |
| 5.1   | SSMS    | Keine Eingabe        |  Artikel wird gespeichert und aktualisiert.               |
| 6.1   | API (Swagger)         | Keine Eingabe          | Die API funktioniert einwandfrei. |
| 7.1   | WPF    | Keine Eingabe |  WPF funktioniert einwandfrei.         |
| 8.1   | SSMS    | Keine Eingabe | Echtzeitübertragungen funktionieren einwandfrei.          |

### 1.4 Diagramme
Dieses Low-Fidelity-Entwurf soll die grafische Benutzeroberfläche (GUI) der EinkaufslistenApp darstellen.

![image](https://github.com/user-attachments/assets/1d836875-2895-4796-8b1c-75991db3affd)


## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A | 12.02.2025 | Jashari | Entwicklung der Benutzer, um Artikel hinzufügen zu können  | 120' |
| 2.A | 12.02.2025 | Jashari | Implementierung der Bearbeitenfunktion | 45' |
| 3.A | 12.02.2025 | Jashari | Implementierung der Funktion, Artikel als "gekauft" zu markieren.  | 30' |
| 4.A | 19.02.2025 | Jashari| Implementierung der Löschfunktion | 45' |
| 5.A | 19.02.2025 | Jashari | Verbindung zu SMSS erstellen. | 30' |
| 6.A | 19.02.2025 | Jashari | API funktionstüchtig versetzen. | 30' |
| 7.A | 26.02.2025 | Jashari | WPF funktionstüchtig versetzen.  | 120' |
| 8.A | 26.02.2025 | Jashari | Echtzeitübertragung implementieren. | 45' |


## 3 Entscheiden
Ich habe mich entschieden, eine Multi-User-Einkaufsliste mit ASP.NET Core WebAPI und SQL-Datenbank zu entwickeln, da sie es ermöglicht, mehreren Benutzern individuelle Einkaufsdaten zu speichern und zu verwalten. Dadurch wird die Anwendung alltagstauglicher und realistischer, weil verschiedene Benutzer gleichzeitig ihre eigene Einkaufsliste führen können. Die Benutzertrennung erfolgt durch den übermittelten Benutzernamen, wodurch einfache Mehrbenutzerunterstützung ohne Login-System realisiert wird.


## 4 Realisieren

| AP-№ | Datum      | Zuständig   | Geplante Zeit | Tatsächliche Zeit |
| ---- | ---------- | ----------- | ------------- | ----------------- |
| 1.A  | 12.02.2025 | Jashari       | 120'          |  120'                 |
| 2.A  | 12.02.2025 | Jashari     | 45'          |  30'                 |
| 3.A  | 12.02.2025 | Jashari  | 30'           |  20'                  |
| 4.A  | 19.02.2025 | Jashari  | 45'          |  30'                |
| 5.A  | 19.02.2025 | Jashari       | 30'          |  20'               |
| 6.A  | 19.02.2025 | Jashari     | 30'          |  20'              |
| 7.A  | 26.02.2025 | Jashari     | 120'          |  120'               |
| 8.A  | 26.02.2025 | Jashari     | 45'          |  30'               |


## 5 Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum      | Resultat | Tester      |
| ---- | ---------- | -------- | ----------- |
| 1.1  | 26.02.2024 |   Funktioniert       | Jashari     |
| 2.1  | 26.02.2024 |   Funktioniert       | Jashari     |
| 3.1  | 26.02.2024 |   Funktioniert       | Jashari     |
| 4.1  | 26.02.2024 |   Funktioniert       | Jashari     |
| 5.1  | 26.02.2024 |   Funktioniert       | Jashari     |
| 6.1  | 26.02.2024 |   Funktioniert       | Jashari     |
| 7.1  | 26.02.2024 |   Funktioniert       | Jashari     |
| 8.1  | 26.02.2024 |   Funktioniert       | Jashari     |
