use FlightSearchDB;

INSERT INTO Flights (FlightName, FlightType, Source, Destination, PricePerSeat)
VALUES
('IndiGo 6E-201', 'Domestic', 'Delhi', 'Mumbai', 4500),
('Air India AI-101', 'Domestic', 'Delhi', 'Bangalore', 5200),
('Vistara UK-820', 'Domestic', 'Mumbai', 'Chennai', 4800),
('SpiceJet SG-404', 'Domestic', 'Bangalore', 'Delhi', 5000),
('IndiGo 6E-305', 'Domestic', 'Chennai', 'Hyderabad', 3200),
('Air Asia I5-909', 'Domestic', 'Hyderabad', 'Mumbai', 3900);


INSERT INTO Hotel (HotelName, HotelType, Location, PricePerDay)
VALUES
('The Taj Mahal Palace', 'Luxury', 'Mumbai', 9000),
('ITC Gardenia', 'Luxury', 'Bangalore', 8000),
('Leela Palace', 'Luxury', 'Chennai', 8500),
('Novotel Hyderabad', 'Business', 'Hyderabad', 6000),
('Radisson Blu', 'Business', 'Delhi', 7500);

select * from Flights;
select * from Hotel;