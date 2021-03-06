CREATE TABLE manufacturer (
id serial PRIMARY KEY,
carbrand VARCHAR(100) NOT NULL
);

CREATE TABLE model (
id serial PRIMARY KEY,
manufacturer_id INTEGER,
name_model VARCHAR(100) NOT NULL,
FOREIGN KEY (manufacturer_id) REFERENCES manufacturer(id)
);

CREATE TABLE customer (
id serial PRIMARY KEY,
FIO VARCHAR(100) NOT NULL,
phone_number VARCHAR(100)
);

CREATE TABLE employee (
id serial PRIMARY KEY,
FIO VARCHAR(100) NOT NULL,
departament VARCHAR(100) NOT NULL,
position VARCHAR(100) NOT NULL,
phone_number VARCHAR(100),
login VARCHAR(100) UNIQUE,
password VARCHAR(100)
);

Alter table employee add constraint login UNIQUE (login);

CREATE TABLE type_accessory (
id serial PRIMARY KEY,
name_type_accessory VARCHAR(100) NOT NULL
);


CREATE TABLE accessories (
id serial PRIMARY KEY,
type_accessory_id INTEGER,
car_id INTEGER,
name_accessory VARCHAR(100) NOT NULL,
price INTEGER NOT NULL,
description TEXT,
FOREIGN KEY (type_accessory_id) REFERENCES type_accessory (id),
FOREIGN KEY (car_id) REFERENCES car (id)
);

ALTER TABLE accessories ADD amount INTEGER CHECK (amount > 0) NOT NULL;

CREATE TABLE equipment (
id serial PRIMARY KEY,
model_id INTEGER,
name_equipment VARCHAR(100) NOT NULL,
type_drive VARCHAR(100) NOT NULL,
fuel VARCHAR(100) NOT NULL,
FOREIGN KEY (model_id) REFERENCES model (id)
);


CREATE TABLE contract (
id serial PRIMARY KEY,
customer_id INTEGER,
employee_id INTEGER,
payment_id INTEGER UNIQUE,
date_sale TIMESTAMP NOT NULL,
pay_method VARCHAR(100) NOT NULL,
initial_donat_money INTEGER CHECK (initial_donat_money > 0),
monthly_pay INTEGER CHECK (monthly_pay > 0),
count_month_installment INTEGER CHECK (count_month_installment > 0)
FOREIGN KEY (customer_id) REFERENCES customer (id),
FOREIGN KEY (employee_id) REFERENCES employee (id)
);

ALTER TABLE contract ADD pay_method VARCHAR(100) NOT NULL;
ALTER TABLE contract ADD initial_donat_money INTEGER CHECK (initial_donat_money > 0);
ALTER TABLE contract ADD monthly_pay INTEGER CHECK (monthly_pay > 0);
ALTER TABLE contract ADD count_month_installment INTEGER CHECK (count_month_installment > 0);
insert into contract (customer_id, employee_id, payment_id)
ALTER TABLE contract DROP COLUMN payment_id;

CREATE TABLE car (
id serial PRIMARY KEY,
color VARCHAR(100),
equipment_id INTEGER,
contract_id INTEGER,
Vin VARCHAR(17) UNIQUE,
release_date DATE NOT NULL,
price INTEGER NOT NULL,
FOREIGN KEY (equipment_id) REFERENCES equipment (id),
FOREIGN KEY (contract_id) REFERENCES contract (id)
);

CREATE TABLE Eventslog(
  id serial PRIMARY KEY,
  type VARCHAR(100),
  employee_id INTEGER,
  date TIMESTAMP NOT NULL,
  event TEXT NOT NULL,
  FOREIGN KEY (employee_id) REFERENCES employee (id)
);

CREATE TABLE Bid(
  id serial PRIMARY KEY,
  type VARCHAR(100),
  employee_id INTEGER,
  name Text,
  count INTEGER CHECK (count > 0),
  FOREIGN KEY (employee_id) REFERENCES employee (id)
);

color,equipment_id,contract_id,Vin,release_date
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
машина может быть не продана но в таблице есть фк на договор
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
удаление проданных автомобилей и перенос их в архив

ALTER TABLE employee
ADD login VARCHAR(100);

ALTER TABLE car
ADD mileage VARCHAR(500);

ALTER TABLE employee
ADD password VARCHAR(100);

ALTER TABLE car
ADD release_date TIMESTAMP NOT NULL;

ALTER TABLE equipment DROP COLUMN price;
ALTER TABLE car ADD release_date DATE NOT NULL;

ALTER TABLE car DROP COLUMN Vin;
ALTER TABLE car ADD Vin VARCHAR(17) UNIQUE NOT NULL;

select a.vin, a.color, a.release_date, fmr.price, fmr.name_equipment,  fmr.type_drive, fmr.fuel, fmr.carbrand, fmr.name_model from (select r.id, r.price, r.name_equipment,  r.type_drive, r.fuel, fm.carbrand, fm.name_model  from (select m.id, f.carbrand, m.name_model from manufacturer f,model m where f.id = m.manufacturer_id) fm, equipment r where fm.id = r.model_id) fmr, car a where fmr.id = a.id;

insert into manufacturer (carbrand) values ('BMW');
insert into manufacturer (carbrand) values ('Mercedes-Benz');
insert into manufacturer (carbrand) values ('Chevrolet');

insert into model (manufacturer_id, name_model) values (1,'M5');
insert into model (manufacturer_id, name_model) values (1,'X5');
insert into model (manufacturer_id, name_model) values (2,'E-class');
insert into model (manufacturer_id, name_model) values (2,'S-class');
insert into model (manufacturer_id, name_model) values (3,'Camaro');

insert into equipment (model_id, name_equipment, type_drive, fuel) values (2,'turbo','Полный','АИ-98');
insert into equipment (model_id, name_equipment, type_drive, fuel) values (1,'competition','Передний','АИ-98');
insert into equipment (model_id, name_equipment, type_drive, fuel) values (3,'200 4matic','Задний','АИ-98');
insert into equipment (model_id, name_equipment, type_drive, fuel) values (3,'400d','Задний','Дизель');
insert into equipment (model_id, name_equipment, type_drive, fuel) values (4,'500','Полный','АИ-98');
insert into equipment (model_id, name_equipment, type_drive, fuel) values (4,'450','Полный','АИ-98');
insert into equipment (model_id, name_equipment, type_drive, fuel) values (5,'5.5','Передний','АИ-100');

insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Желтый', 7 ,NULL,'123456789qwertcam','2010-11-30',15000000,79063	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый', 1 ,NULL,'123456789qwertyui','2014-11-30',15000000,72724	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый',2,NULL,'123456790qwertyui','2015-10-11', 5132406,74052);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Золотой', 3 ,NULL,'123456791qwertyui','2019-04-27',776973,44180		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 4 ,NULL,'123456792qwertyui','2019-04-27',6339444,	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 5 ,NULL,'123456793qwertyui','2020-04-17',3856672,84408	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Белый', 6 ,NULL,'123456794qwertyui','2019-04-17',5563768,43470	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 2 ,NULL,'123456795qwertyui','2020-07-14',4746098,24303		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый', 4 ,NULL,'123456796qwertyui','2019-04-17',6864077,79063		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 3 ,NULL,'123456797qwertyui','2019-04-17',8241917,58848	);


insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый', 1 ,NULL,'123456729qwertyui','2014-11-30',4060370,94355	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый',2,NULL,'123456290qwertyui','2015-10-11',7205199,95124);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Золотой', 3 ,NULL,'122456791qwertyui','2019-04-27',5563768,48087);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 4 ,NULL,'123656792qwertyui','2019-04-27',9521752,74052	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 5 ,NULL,'124556793qwertyui','2020-04-17',4746098,24303		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Белый', 6 ,NULL,'126576794qwertyui','2019-04-17',4060370,60361		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 2 ,NULL,'123856795qwertyui','2020-07-14',7344959,49648		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый', 4 ,NULL,'123496796qwertyui','2019-04-17',3708369,19793	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 3 ,NULL,'123756797qwertyui','2019-04-17',3111295,74340		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый', 1 ,NULL,'123346789qwertyui','2014-11-30',8552879,16623		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый',2,NULL,'123453590qwertyui','2015-10-11',5563768,82512	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Золотой', 3 ,NULL,'123456791qwertyui','2019-04-27',2568935,68386		);

insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 4 ,NULL,'123156792qwertyui','2019-04-27',647455,5174		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 5 ,NULL,'123256793qwertyui','2020-04-17',1650595,67438	);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Белый', 6 ,NULL,'123456800qwertyui','2019-04-17',3111295,11823		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 2 ,NULL,'1234567035qwertyui','2020-07-14',6864077,69262		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Серый', 4 ,NULL,'1234567934wertyui','2019-04-17',215115,99187		);
insert into car (color,equipment_id,contract_id,Vin,release_date, price,mileage) values ('Черный', 3 ,NULL,'123456000qwertyui','2019-04-17',2694954,56407		);



insert into type_accessory (name_type_accessory) values ('Дворники');
insert into type_accessory (name_type_accessory) values ('Коврики');
insert into type_accessory (name_type_accessory) values ('Парковочные радары');
insert into type_accessory (name_type_accessory) values ('Чехлы');
insert into type_accessory (name_type_accessory) values ('Спойлеры');
insert into type_accessory (name_type_accessory) values ('Диски');
insert into type_accessory (name_type_accessory) values ('Зеркала');

insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (1,NULL,'Ультралайт',5000,'Michlen 70см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (1,NULL,'Каркасные',700,'Michlen 50см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (1,NULL,'Каркасные',8000,'Автодром 80см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (1,NULL,'Зимние',3000,'Лада 70см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (1,NULL,'Гибридные',2000,'Лада 70см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (2,NULL,'Резиновые',4000,'Комлпект 5шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (2,NULL,'Впитывающие',6000,'Комлпект 5шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (2,NULL,'Тканевые',1000,'Комлпект 5шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (3,NULL,'Revisor',5000,'Дальность 5-100см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (3,NULL,'Videotronic',4000,'Дальность 5-30см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (3,NULL,'Nictech',4500,'Дальность 5-30см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (3,NULL,'Revisor',8000,'Дальность 0-200см');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (4,NULL,'Кожанные',20000,'Комплект 2шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (4,NULL,'Микрофибра',9000,'Комплект 3шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (4,NULL,'Кожзам',9000,'Комплект 3шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (4,NULL,'Тканьевые',2000,'Комплект 2шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (5,NULL,'Низкий',7000,'Задний');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (5,NULL,'Высокий',3500,'Задний');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (6,NULL,'Штамповка',4000,'Комплект 4шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (6,NULL,'Литые',5000,'Комплект 4шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (6,NULL,'Michlen литые',15000,'Комплект 4шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (6,NULL,'Тундра',7000,'Комплект 4шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (6,NULL,'Сибирь',8000,'Комплект 4шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (6,NULL,'Урал',6000,'Комплект 4шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (6,NULL,'Кавказ',9000,'Комплект 4шт');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (7,NULL,'Боковые',5000,'Япония');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (7,NULL,'Боковые',5000,'Германия');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (7,NULL,'Задние',5000,'Michlen');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (7,NULL,'Слепая зона',5000,'Россия');
insert into accessories (type_accessory_id,car_id,name_accessory,price, description) values (7,NULL,'Слепая зона',7000,'Бельгия');


 Бортовой видеорегистратор ...
✔ Навигатор ...
✔ Пуско-зарядное устройство ...
✔ Обзорные панорамные зеркала ...
✔ Автомобильный холодильник ...
✔ Радар-детектор ...
✔ Оборудование для уборки ...
✔ Освежители воздуха и ионизаторы


ALTER SEQUENCE manufacturer_id_seq RESTART WITH 1;
ALTER SEQUENCE model_id_seq RESTART WITH 1;
ALTER SEQUENCE equipment_id_seq RESTART WITH 1;
ALTER SEQUENCE car_id_seq RESTART WITH 1;
ALTER SEQUENCE bid_id_seq RESTART WITH 1;
ALTER SEQUENCE contract_id_seq RESTART WITH 1;
ALTER SEQUENCE accessories_id_seq RESTART WITH 1;
ALTER SEQUENCE type_accessory_id_seq RESTART WITH 1;
<DataGrid.Columns >
                <DataGridTextColumn Header="VIN" Binding="{Binding _VIN}" Width="150"/>
                <DataGridTextColumn Header="Производитель" Binding="{Binding _manufacturerName}" Width="140"/>
                <DataGridTextColumn Header="Модель" Binding="{Binding _modelName}" Width="110"/>
                <DataGridTextColumn Header="Комплектация" Binding="{Binding _equipmentName}" Width="130"/>
                <DataGridTextColumn Header="Год выпуска" Binding="{Binding _releaseDate}" Width="120"/>
                <DataGridTextColumn Header="Тип топлива" Binding="{Binding _fuel}" Width="120"/>
                <DataGridTextColumn Header="Тип привода" Binding="{Binding _drive}" Width="120"/>
                <DataGridTextColumn Header="Цвет" Binding="{Binding _color}" Width="80"/>
                <DataGridTextColumn Header="Цена" Binding="{Binding _price}" Width="200"/>
            </DataGrid.Columns>

update car
   set vin = 'aaaaaaaaaaaaaaa12'
 where vin = 'aaaaaaaaaaaaaaaaa';


CREATE TABLE manufacturer (
  id serial PRIMARY KEY,
  carbrand VARCHAR(100) NOT NULL);

CREATE TABLE model (
  id serial PRIMARY KEY,
  manufacturer_id INTEGER,
  name_model VARCHAR(100) NOT NULL,
  FOREIGN KEY (manufacturer_id) REFERENCES manufacturer(id));

CREATE TABLE customer (
  id serial PRIMARY KEY,
  FIO VARCHAR(100) NOT NULL,
  phone_number VARCHAR(100));

CREATE TABLE employee (
  id serial PRIMARY KEY,
  FIO VARCHAR(100) NOT NULL,
  departament VARCHAR(100) NOT NULL,
  position VARCHAR(100) NOT NULL,
  phone_number VARCHAR(100),
  login VARCHAR(100) UNIQUE,
  password VARCHAR(100));

CREATE TABLE type_accessory (
  id serial PRIMARY KEY,
  name_type_accessory VARCHAR(100) NOT NULL);

CREATE TABLE accessories (
  id serial PRIMARY KEY,
  type_accessory_id INTEGER,
  car_id INTEGER,
  name_accessory VARCHAR(100) NOT NULL,
  price INTEGER NOT NULL,
  description TEXT,
  FOREIGN KEY (type_accessory_id) REFERENCES type_accessory (id),
  FOREIGN KEY (car_id) REFERENCES car (id));

CREATE TABLE equipment (
  id serial PRIMARY KEY,
  model_id INTEGER,
  name_equipment VARCHAR(100) NOT NULL,
  type_drive VARCHAR(100) NOT NULL,
  fuel VARCHAR(100) NOT NULL,
  FOREIGN KEY (model_id) REFERENCES model (id));

CREATE TABLE contract (
  id serial PRIMARY KEY,
  customer_id INTEGER,
  employee_id INTEGER,
  date TIMESTAMP NOT NULL,
  pay_method VARCHAR(100) NOT NULL,
  initial_donat_money INTEGER CHECK (initial_donat_money > 0),
  monthly_pay INTEGER CHECK (monthly_pay > 0),
  count_month_installment INTEGER CHECK (count_month_installment > 0)
  FOREIGN KEY (customer_id) REFERENCES customer (id),
  FOREIGN KEY (employee_id) REFERENCES employee (id));

CREATE TABLE car (
  id serial PRIMARY KEY,
  color VARCHAR(100),
  equipment_id INTEGER,
  contract_id INTEGER,
  Vin VARCHAR(17) UNIQUE,
  release_date DATE NOT NULL,
  price INTEGER NOT NULL,
  FOREIGN KEY (equipment_id) REFERENCES equipment (id),
  FOREIGN KEY (contract_id) REFERENCES contract (id));

CREATE TABLE Eventslog(
  id serial PRIMARY KEY,
  type VARCHAR(100),
  employee_id INTEGER,
  date TIMESTAMP NOT NULL,
  event TEXT NOT NULL,
  FOREIGN KEY (employee_id) REFERENCES employee (id));

CREATE TABLE Bid(
  id serial PRIMARY KEY,
  type VARCHAR(100),
  employee_id INTEGER,
  name Text,
  count INTEGER CHECK (count > 0),
  FOREIGN KEY (employee_id) REFERENCES employee (id));
