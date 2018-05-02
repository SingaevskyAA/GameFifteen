# GameFifteen 

Данный проект представляет собой сервер для игры в пятнашки реализованный на ASP.NET Core. Сервер умеет создавать поле для игры в пятнашки, а так же проверять ходы пользователя на корректность. Подразумевается, что проверка завершения игры, таймер и счетчик ходов реализованы на клиентской стороне.


### Подготовка сервера:

При первой сборке проекта необходимо использовать миграции ET Core для создания базы данных. Для этого в Package Manager Console необходимо последовательно выполнить команды:
1. Add-Migration Initial
2. Update-Database

### Api:

* /game/

[FromBody] guid
Запрос получает из тела запроса Id игры. Если Id не существует на сервере, то создается новая игра. Если игра существует, то возвращается её текущее состояние. Id должен быть представлен в виде корректного GUID.
Пример тела корректного запроса:
```
"646cdf58-d864-4708-b294-55319190bfd0"
```

* /game/turn

[FromBody] TurnInfo

Данный запрос совершает ход. В качестве тела запроса необходимо передать id игры и координаты клетки для которой необходимо совершить ход. Id должен быть представлен в виде корректного GUID.
Результатом будет текущее состояние игры. 
Пример тела корректного запроса:
```
{
"id": "646cdf58-d864-4708-b294-55319190bfd0" ,
"x" : 1 ,
"y" : 2
}
```

### Формат ответа:

Ответом на корректный запрос будет строка, представляющая собой текущее состояние игрового поля. Например: 
``` "12,5,6,14,16,3,15,4,13,8,11,9,1,7,2,10" ```


Код ошибки 400:
Запрос с неверным форматом id

Код ошибки 404:

Попытка сделать ход в несуществующей игре
