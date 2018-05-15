# ParkingSimulator
BSAcademy'18 • 2nd stage • 2. C# Modern Features


**Программа должна иметь следующий функционал:**
* Добавить/удалить машину с парковки.
* Пополнить баланс машины.
* Списать средства за парковочное место (через каждые N-секунд будет срабатывать таймер и списывать с каждой машины стоимость парковки).
* Вывести истории транзакций за последнюю минуту.
* Вывести общий доход парковки.
* Вывести количество свободных мест на парковке.
* Каждую минуту записывать в файл Transactions.log сумму транзакций за последнюю минуту с пометкой даты.
* Вывести Transactions.log (отформатировать вывод)

# ParkingLotWebAPI

### Documentation https://documenter.getpostman.com/view/4361965/bsa2018/RW83PXHi
Academy'18 • 2nd stage • 3. .NET Core
На основі домашньої роботи №2 реалізовано ASP.NET Core Web API додаток.

## Parking
| URL | Description |
| --- | --- |
| http://localhost:53199/api/Parking/GetFreePlace | Кількість вільних місць (GET) |
| http://localhost:59687/api/ParkingLot/ParkingOccupiedSpaces | Кількість зайнятих місць (GET) |
| http://localhost:53199/api/Parking/GetBusyPlace | Загальний дохід (GET) |

## Cars
| URL | Description |
| --- | --- |
| http://localhost:53199/api/Car | Список всіх машин (GET) |
| http://localhost:53199/api/Car/{id}| Деталі по одній машині (GET) |
| http://localhost:53199/api/Car/{id} | Видалити машину (DELETE) |
| http://localhost:53199/api/Car(BODY {"Balance": balance, "Type": int}) | Додати машину (POST) |

## Transactions
| URL | Description |
| --- | --- |
| http://localhost:53199/api/Transaction/{id}/{balance} | Поповнити баланс машини (PUT) |
| http://localhost:53199/api/Transaction/GetLogFile| Вивести Transactions.log (GET) |
| http://localhost:53199/api/Transaction/ | Транзакції за останню хвилину (GET) |
| http://localhost:53199/api/Transaction/{id}| Транзакції за останню хвилину по одній конкретній машині (GET) |


### Screenshots
<img alt="" src="https://github.com/ICxodnik/ParkingSimulator/blob/develop/Screenshots/Capture.PNG" width=100%>
<img alt="" src="https://github.com/ICxodnik/ParkingSimulator/blob/develop/Screenshots/Capture1.PNG" width=100%>


