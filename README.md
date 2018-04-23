# GameFifteen 

Данный проект представляет собой сервер для игры в пятнашки реализованный на ASP.NET Core.


Подготовка сервера:

При первой сборке проекта необходимо использовать миграции ET Core для создания базы данных. Для этого в Package Manager Console необходимо последовательно выполнить команды:
1. Add-Migration Initial
2. Update-Database
-------------
Api:

/game/id/

Данный запрос создает новую игру. В качестве id клиент должен предоставить сгенерированный Guid.

/game/id/x/y

Данный запрос совершает ход. В качестве id клиент должен предоставить Guid существующей на сервере игры. Координаты должны соответвовать одной из клеток игрового поля. 

Формат ответа:

Ответом на корректный запрос будет строка, представляющая собой текущее состояние игрового поля. Например: "12,5,6,14,16,3,15,4,13,8,11,9,1,7,2,10"

Код ошибки 400:

Попытка создать новую игру с уже существующим Guid

Код ошибки 404:

Попытка сделать ход в несуществующей игре
