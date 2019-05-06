Start the program and run these cURL commands

```sh
---SUCCESS---
curl http://localhost:20991/api/values/date1?date=5/15/2019
curl http://localhost:20991/api/values/date1?date=15/5/2019 -H "culture: es-MX"
curl http://localhost:20991/api/values/date2 -X POST -d "Date=5/15/2019"
curl http://localhost:20991/api/values/date2 -X POST -d "Date=15/5/2019" -H "culture: es-MX"
curl http://localhost:20991/api/values/date3 -X POST -d "{\"Date\":\"5\/5\/2019\"}" -H "Content-Type: application/json"

---FAILURE---
curl http://localhost:20991/api/values/date3 -X POST -d "{\"Date\":\"15\/5\/2019\"}" -H "culture: es-MX" -H "Content-Type: application/json"

```
Every command works except the `curl http://localhost:20991/api/values/date3 -X POST -d "{\"Date\":\"15\/5\/2019\"}" -H "culture: es-MX" -H "Content-Type: application/json"`