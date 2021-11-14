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
login VARCHAR(100),
password VARCHAR(100)
);

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
FOREIGN KEY (type_accessory_id) REFERENCES type_accessory (id),
FOREIGN KEY (car_id) REFERENCES car (id)
);

ALTER TABLE accessories ADD description TEXT;

CREATE TABLE equipment (
id serial PRIMARY KEY,
model_id INTEGER,
name_equipment VARCHAR(100) NOT NULL,
price INTEGER NOT NULL,
type_drive VARCHAR(100) NOT NULL,
fuel VARCHAR(100) NOT NULL,
FOREIGN KEY (model_id) REFERENCES model (id)
);

-- CREATE TABLE payment (
-- id serial PRIMARY KEY,
-- pay_method VARCHAR(100) NOT NULL,
-- initial_donat_money FLOAT CHECK (initial_donat_money > 0),
-- monthly_pay FLOAT CHECK (monthly_pay > 0),
-- count_month_installment INTEGER CHECK (count_month_installment > 0)
-- );

CREATE TABLE contract (
id serial PRIMARY KEY,
customer_id INTEGER,
employee_id INTEGER,
payment_id INTEGER UNIQUE,
date_bid TIMESTAMP NOT NULL,
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
FOREIGN KEY (equipment_id) REFERENCES equipment (id),
FOREIGN KEY (contract_id) REFERENCES contract (id)
);
color,equipment_id,contract_id,Vin,release_date
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
машина может быть не продана но в таблице есть фк на договор
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
удаление проданных автомобилей и перенос их в архив

ALTER TABLE employee
ADD login VARCHAR(100);

ALTER TABLE employee
ADD password VARCHAR(100);

ALTER TABLE car
ADD release_date TIMESTAMP NOT NULL;

ALTER TABLE car DROP COLUMN release_date;
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

insert into equipment (model_id, name_equipment, price, type_drive, fuel) values (2,'turbo',9836000,'Полный','АИ-98');
insert into equipment (model_id, name_equipment, price, type_drive, fuel) values (1,'competition',5811000,'Передний','АИ-98');
insert into equipment (model_id, name_equipment, price, type_drive, fuel) values (3,'200 4matic',5250000,'Задний','АИ-98');
insert into equipment (model_id, name_equipment, price, type_drive, fuel) values (3,'400d',7930000,'Задний','Дизель');
insert into equipment (model_id, name_equipment, price, type_drive, fuel) values (4,'500',12578000,'Полный','АИ-98');
insert into equipment (model_id, name_equipment, price, type_drive, fuel) values (4,'450',10296000,'Полный','АИ-98');

insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый', 1 ,NULL,'123456789qwertyui','2014-11-30');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый',2,NULL,'123456790qwertyui','2015-10-11');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Золотой', 3 ,NULL,'123456791qwertyui','2019-04-27');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 4 ,NULL,'123456792qwertyui','2019-04-27');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 5 ,NULL,'123456793qwertyui','2020-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Белый', 6 ,NULL,'123456794qwertyui','2019-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 2 ,NULL,'123456795qwertyui','2020-07-14');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый', 4 ,NULL,'123456796qwertyui','2019-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 3 ,NULL,'123456797qwertyui','2019-04-17');


insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый', 1 ,NULL,'123456729qwertyui','2014-11-30');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый',2,NULL,'123456290qwertyui','2015-10-11');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Золотой', 3 ,NULL,'122456791qwertyui','2019-04-27');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 4 ,NULL,'123656792qwertyui','2019-04-27');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 5 ,NULL,'124556793qwertyui','2020-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Белый', 6 ,NULL,'126576794qwertyui','2019-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 2 ,NULL,'123856795qwertyui','2020-07-14');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый', 4 ,NULL,'123496796qwertyui','2019-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 3 ,NULL,'123756797qwertyui','2019-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый', 1 ,NULL,'123346789qwertyui','2014-11-30');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый',2,NULL,'123453590qwertyui','2015-10-11');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Золотой', 3 ,NULL,'123456791qwertyui','2019-04-27');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 4 ,NULL,'123156792qwertyui','2019-04-27');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 5 ,NULL,'123256793qwertyui','2020-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Белый', 6 ,NULL,'123456800qwertyui','2019-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 2 ,NULL,'1234567035qwertyui','2020-07-14');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Серый', 4 ,NULL,'1234567934wertyui','2019-04-17');
insert into car (color,equipment_id,contract_id,Vin,release_date) values ('Черный', 3 ,NULL,'123456000qwertyui','2019-04-17');




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
   set contract_id = 1
 where id = 1;