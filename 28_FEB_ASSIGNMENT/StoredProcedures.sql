USE FlightSearchDB;

CREATE PROCEDURE sp_GetSources
AS
BEGIN
    SELECT DISTINCT Source
    FROM Flights;
END;

EXEC sp_GetSources;

CREATE PROCEDURE sp_GetDestinations
AS
BEGIN
    SELECT DISTINCT Destination
    FROM Flights;
END;

EXEC sp_GetDestinations;

CREATE PROCEDURE sp_SearchFlights
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT
        FlightId,
        FlightName,
        FlightType,
        Source,
        Destination,
        PricePerSeat * @Persons AS TotalCost
    FROM Flights
    WHERE Source = @Source
      AND Destination = @Destination;
END;

EXEC sp_SearchFlights
    @Source = 'Delhi',
    @Destination = 'Mumbai',
    @Persons = 2;

ALTER PROCEDURE sp_SearchFlightsWithHotels
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT
        f.FlightId,
        f.FlightName,
        f.Source,
        f.Destination,
        h.HotelName,
        (f.PricePerSeat * @Persons + h.PricePerDay) AS TotalCost
    FROM Flights f
    INNER JOIN Hotel h
        ON f.Destination = h.Location
    WHERE f.Source = @Source
      AND f.Destination = @Destination;
END;

EXEC sp_SearchFlightsWithHotels
    @Source = 'Delhi',
    @Destination = 'Mumbai',
    @Persons = 2;