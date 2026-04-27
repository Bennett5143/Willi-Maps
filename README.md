# Willi Maps

A user-supported map tool that offers young people orientation and facilitates access to safe, consumption-free spaces in Hamburg-Wilhelmsburg.

---

## Voraussetzungen

- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9)
- [dotnet-ef CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet tool install --global dotnet-ef --version 9.0.5`)

---

## Setup (einmalig)

**1. Repository klonen**
```bash
git clone <repo-url>
cd Willi-Maps
```

**2. Umgebungsvariablen konfigurieren**

Eine `.env` Datei im Projekt-Root anlegen. Diese Datei wird nicht ins Repository committed und muss lokal erstellt werden. Die Datei enthält die Zugangsdaten für die lokale Datenbank – bitte bei einem Teammitglied erfragen.

**3. `appsettings.Development.json` anlegen**

Im `WilliMaps/`-Ordner eine `appsettings.Development.json` anlegen. Diese Datei wird ebenfalls nicht committed und enthält den Connection String zur lokalen Datenbank – bitte bei einem Teammitglied erfragen.

---

## Lokal starten

```bash
# Vom Projekt-Root aus
docker compose up -d
```

Der lokale Stack startet:
- App unter `http://localhost:5166`
- PostgreSQL + PostGIS unter `localhost:5433`

---

## Datenbank migrieren

Nach dem ersten Start oder nach einem `git pull` mit neuen Migrationen:

```bash
cd WilliMaps
dotnet ef database update
```

Das legt alle Tabellen an und spielt die Seed-Daten ein.

---

## Stoppen

```bash
docker compose down
```

Die Daten bleiben erhalten (Docker Volume). Um auch die Daten zu löschen:
```bash
docker compose down -v
```

---

## Datenbankverbindung prüfen

Mit der VSCode-Extension **SQLTools** oder direkt im Terminal:

```bash
docker exec -it willimaps-db psql -U willimaps -d willimaps
```

---

## Deployment

Das Deployment läuft über `docker-compose.deploy.yml`. Die Datei muss auf dem Server liegen und eine `.env` mit den Produktiv-Credentials daneben:

```bash
docker compose -f docker-compose.deploy.yml up -d
```

---

## Technologie-Stack

| Bereich | Technologie |
|--------|-------------|
| Frontend | C# Blazor Server |
| Karte | Leaflet.js |
| Backend | ASP.NET Core REST API |
| Datenbank | PostgreSQL 16 + PostGIS |
| ORM | Entity Framework Core 9 |
| Infrastruktur | Docker + Docker Compose |