# Projekt-Dokumentation

| Datum       | Version | Zusammenfassung                                              |
| ----------- | ------- | ------------------------------------------------------------ |
| 12.02.2025  | 0.0.1   | Beginn der Planungs- und Entwicklungsphase für die Auto-Website. Erstellung der Konzepte für Anmelde- und Registrierfunktionen sowie Struktur der Startseite und Unterseiten. |
| 19.02.2025  | 0.0.2   | Programmierung der Startseite begonnen, Aufteilung und Zuweisung der Unterseiten für verschiedene Automarken. |
| 26.02.2025  | 0.0.3   | Überarbeitung und Detailplanung der Website, Entwicklung der Anmelde- und Registrierfunktion sowie Erweiterung der Unterseiten für die Automarken. |
| 05.03.2025  | 0.0.3   | Revision der Website, Verfeinerung der Funktionen und Designs für die Startseite und die spezifischen Automarken-Seiten. |

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
| 2.1   | WPF-UI         | Klick auf "Bearbeiten"        | Artikel wurde bearbeitet. |
| 2.2   | API (Swagger)         | PUT-Anfrage tätigen        | Artikel wurde bearbeitet. |
| 3.1   | WPF-UI    | Klick auf "gekauft" | Artikel wird als "gekauft" markiert.            |
| 4.1   | WPF-UI | Klick auf "Löschen" | Artikel wird gelöscht.              |
| 4.1   | API (Swagger) | DELETE-Anfrage tätigen | Artikel wird gelöscht.              |
| 5.1   | SSMS    | Keine Eingabe        |  Artikel wird gespeichert und aktualisiert.               |
| 6.1   | API (Swagger)         | Keine Eingabe          | Die API funktioniert einwandfrei. |
| 7.1   | WPF    | Keine Eingabe |  WPF funktioniert einwandfrei.         |
| 8.1   | SSMS    | Keine Eingabe | Echtzeit-Liveübertragungen funktionieren einwandfrei.          |

### 1.4 Diagramme
Dieses Low-Fidelity-Entwurf soll die grafische Benutzeroberfläche (GUI) der EinkaufslistenApp darstellen.

![image](https://github.com/user-attachments/assets/1d836875-2895-4796-8b1c-75991db3affd)


## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A | 12.02.2025 | Jashari | Entwicklung der Benutzer, um Artikel hinzufügen zu können  | 120' |
| 2.A | 12.02.2025 | Jashari | Implementierung der Bearbeitenfunktion | 45' |
| 3.A | 19.02.2025 | Jashari | Implementierung der Funktion, Artikel als "gekauft" zu markieren.  | 30' |
| 4.A | 19.02.2025 | Jashari| Implementierung der Löschfunktion | 45' |
| 5.A | 19.02.2025 | Jashari | Verbindung zu SMSS erstellen. | 30' |
| 6.A | 26.02.2025 | Jashari | API funktionstüchtig versetzen. | 30' |
| 7.A | 26.02.2025 | Jashari | WPF funktionstüchtig versetzen.  | 120' |
| 8.A | 26.02.2025 | Jashari | Echtzeit-Liveübertragung implementieren. | 240' |


## 3 Entscheiden


Wir haben in der Gruppe die Arbeitspakete fair verteilt, sodass wir alle zum Implementieren beitragen. Dadurch haben wir auch eine gute Zeiteinteilung erreicht.

## 4 Realisieren

| AP-№ | Datum      | Zuständig   | Geplante Zeit | Tatsächliche Zeit |
| ---- | ---------- | ----------- | ------------- | ----------------- |
| 1.A  | 12.02.2025 | Jashari       | 120'          |  110'                 |
| 2.A  | 12.02.2025 | Jashari     | 120'          |  100'                 |
| 3.A  | 19.02.2025 | Jashari  | 60'           |  50'                  |
| 4.A  | 19.02.2025 | Jashari  | 180'          |  140'                |
| 5.A  | 19.02.2025 | Jashari       | 120'          |  100'               |
| 6.A  | 26.02.2025 | Jashari     | 180'          |  140'              |
| 7.A  | 26.02.2025 | Jashari     | 240'          |  120'               |
| 7.A  | 26.02.2025 | Jashari     | 240'          |  120'               |


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
