CREATE TABLE transport (
    transport_id int NOT NULL,
    fligth_carrier varchar(255),
    fligth_carrier_number varchar(255),
    PRIMARY KEY (transport_id),
);

CREATE TABLE fligth (
    fligth_id int NOT NULL,
    transport_id int NOT NULL,
    origin varchar(255),
	destination varchar (255),
	price float,
    PRIMARY KEY (fligth_id),
	FOREIGN KEY (transport_id) REFERENCES transport(transport_id),
);

CREATE TABLE journey (
    journey_id int NOT NULL,
    origin varchar(255),
    destination varchar(255),
	price float,
    PRIMARY KEY (journey_id),
);

CREATE TABLE journey_flight (
    journey_flight_id int NOT NULL,
    fligth_id int NOT NULL,
    journey_id int NOT NULL,
    PRIMARY KEY (journey_flight_id),
	FOREIGN KEY (fligth_id) REFERENCES fligth(fligth_id),
	FOREIGN KEY (journey_id) REFERENCES journey(journey_id),
);