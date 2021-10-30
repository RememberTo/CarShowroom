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
phone_number VARCHAR(100)
);

CREATE TABLE type_accessory (
id serial PRIMARY KEY,
name_type_accessory VARCHAR(100) NOT NULL
);

CREATE TABLE accessories (
id serial PRIMARY KEY,
type_accessory_id INTEGER,
model_id INTEGER,
name_accessory VARCHAR(100) NOT NULL,
price INTEGER NOT NULL,
FOREIGN KEY (type_accessory_id) REFERENCES type_accessory (id),
FOREIGN KEY (model_id) REFERENCES model (id)
);

CREATE TABLE equipment (
id serial PRIMARY KEY,
model_id INTEGER,
name_equipment VARCHAR(100) NOT NULL,
price INTEGER NOT NULL,
type_drive VARCHAR(100) NOT NULL,
fuel VARCHAR(100) NOT NULL,
FOREIGN KEY (model_id) REFERENCES model (id)
);

CREATE TABLE payment (
id serial PRIMARY KEY,
pay_method VARCHAR(100) NOT NULL,
initial_donat_money FLOAT CHECK (initial_donat_money > 0),
monthly_pay FLOAT CHECK (monthly_pay > 0),
count_month_installment INTEGER CHECK (count_month_installment > 0)
);

CREATE TABLE contract (
id serial PRIMARY KEY,
customer_id INTEGER,
employee_id INTEGER,
payment_id INTEGER UNIQUE,
date_bid TIMESTAMP NOT NULL,
date_sale TIMESTAMP NOT NULL,
FOREIGN KEY (customer_id) REFERENCES customer (id),
FOREIGN KEY (employee_id) REFERENCES employee (id)
);

!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
машина может быть не продана но в таблице есть фк на договор
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
удаление проданных автомобилей и перенос их в архив
CREATE TABLE car (
id serial PRIMARY KEY,
color VARCHAR(100),
equipment_id INTEGER,
contract_id INTEGER,
Vin VARCHAR(17)
FOREIGN KEY (equipment_id) REFERENCES equipment (id),
FOREIGN KEY (contract_id) REFERENCES contract (id)
);