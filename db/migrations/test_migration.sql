\dt
\d users
\d places
SELECT PostGIS_Version();

/*
 * Run this command to execute the migration:
 * docker exec -i willimaps-db psql -U willimaps -d willimaps -f /dev/stdin < db/migrations/test_migration.sql
 */