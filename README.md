# Willi-Maps
A user-supported map tool that offers young people orientation and facilitates access to safe, consumption-free spaces.

Lokal starten (docker desktop)

Vom Projekt-Root aus:
```bash
docker compose up -d
```

Der lokale Stack startet:
- App unter `http://localhost:5166`
- PostGIS/PostgreSQL unter `localhost:5433`

Stoppen
```bash
docker compose down
```

Das Deployment ist mit docker-compose.deploy.yml moeglich (muss aufn Server gepullt und ausgeführt werden, braucht kein IP ports und die Anmeldedaten sind in environmental variables .env).

Migrationen im Container ausfuehren

vom Projekt-Root, um das Migration-Skript im DB-Container auszufuehren:

```bash
docker exec -i willimaps-db psql -U willimaps -d willimaps -f /dev/stdin < db/migrations/test_migration.sql
```

Um Tabellen manuell zu pruefen:

```bash
docker exec -it willimaps-db psql -U willimaps -d willimaps
```

