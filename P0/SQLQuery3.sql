/*

/* ADDING STRETS */
INSERT Locations(AddressNum, AddressStreet, AddressCity, AddressState, AddressZipCode, Description)
VALUES (101, 'W Main St', 'Houston', 'TX', 77033, 'A great spot for lessons and instruments.')

INSERT Locations(AddressNum, AddressStreet, AddressCity, AddressState, AddressZipCode, Description)
VALUES (12, 'Gallop Blvd', 'Galveston', 'TX', 79231, 'A wavy spot for groovey tunes.')

INSERT Locations(AddressNum, AddressStreet, AddressCity, AddressState, AddressZipCode, Description)
VALUES (3035, 'Bahd St', 'Dallas', 'TX', 84432, 'We buy ugly instruments')

INSERT Locations(AddressNum, AddressStreet, AddressCity, AddressState, AddressZipCode, Description)
VALUES (532, 'Copley Ln', 'Spring', 'TX', 77563, 'Friendly forest music fun')

/* ADDING GUITARS */
INSERT Products(Name, Price, Type, Description)
VALUES ('Martin 0004EC-Z Eric Clapton Crossroads Ziricote Auditorium Acoustic Guitar', 12999, 'GUITAR', 'Originally owned by Eric Clapton')

INSERT Products(Name, Price, Type, Description)
VALUES ('Gibson Custom 60th Anniversary 1959 Les Paul Standard Kindred Burst', 6499, 'GUITAR', 'Black Trim, Wood Finish, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('MitchelL MM100 mini Double Cutaway Electric Guitar', 119, 'GUITAR', 'Dark Red Coat, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Fender Player Stratocaster Maple Fingerbaord Electric Guitar', 699, 'GUITAR', 'Orange Finish, New')

/* INSERTING BASSES*/
INSERT Products(Name, Price, Type, Description)
VALUES ('Rogue X100B Series II Electric Bass Guitar', 149, 'BASS', 'Black, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Ibanez TMB100 Electric Guitar Bass', 199, 'BASS', 'Light Blue Finish, Excellent Condition')

INSERT Products(Name, Price, Type, Description)
VALUES ('Hofner Ignition Series Vintage Violin Bass', 349, 'BASS', 'Black Trim, White Pickgaurd, Great Condition')

INSERT Products(Name, Price, Type, Description)
VALUES ('MLS110 Apprentice Collection Double Bass', 2499, 'BASS', 'Maple Leaf Strings, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Warwick Custom Shop Streamer Stage I 6-String Electric Bass', 11999, 'BASS', 'Slime Green, New')

/* INSERTING DRUMS*/
INSERT Products(Name, Price, Type, Description)
VALUES ('Yamaha Stage Custom Birch 5-peice Shell', 679, 'DRUMS', 'Red Finish, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Rogue 5-Piece Complete Drum Set', 329, 'DRUMS', 'Black, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Roland TD-1dMKX V-Srums Set With Additional Larger Ride Cymbal', 799, 'DRUMS', 'Electric Drums, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Simmons SD600 Electromic Drum Set with Mesh Heads and Bluetooth', 549, 'DRUMS', 'Electric Drums, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('DW 6-Piece Collectors Series Santa Monica with Chrome Hardware Butterscotch', 5829, 'DRUMS', 'Chrome Finish, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Pearl Music City Custom Masters Maple Reserve Double Bass Shell Pack Mirror Chrome', 5318, 'DRUMS', 'Silver Chrome Finish, New')


/* INSERTING PIANOS */
INSERT Products(Name, Price, Type, Description)
VALUES ('Williams Legato III Digital Piano', 269, 'PIANO', 'Electric MIDI, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Casio CT-X800STSO', 269, 'PIANO', 'Electric Piano, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Williams Rhapsody 2 88-Key Console Digital Piano', 569, 'PIANO', 'Dual Pedal Action, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Yamaha Clavinova VP-709 Home Digital Piano', 10799, 'PIANO', 'Triple Pedal Action, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Yamaha GENOS 76-Key Flagship Arranger Workstation', 5999, 'PIANO', 'Electric MIDI, New')

/* Inserting Microphones */
INSERT Products(Name, Price, Type, Description)
VALUES ('Shure SM58 Dynamic Handheld Vocal Microphone', 99, 'MIC', 'Dynamic, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Blue Bluebird SL Large-Diaphragm Cardiod Conseser Microphone', 299, 'MIC', 'Condenser, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('Shure Beta 57A Microphone', 139, 'MIC', 'Dynamic Microphone')

INSERT Products(Name, Price, Type, Description)
VALUES ('Neumann U67, Tube Condenser Microphone Reissue', 6995, 'MIC', 'Condenser, New')

INSERT Products(Name, Price, Type, Description)
VALUES ('AKG C12 VR Reference Tube Condenser Microphone', 5999, 'MIC', 'Condenser, New')

/* INSERTING ACCESSORIES */
INSERT Products(Name, Price, Type, Description)
VALUES ('D Addario XT Electric Guitar Coated Strings  Medium (.011-.049)', 12, 'ACC', 'Medium Strings')

INSERT Products(Name, Price, Type, Description)
VALUES ('DAddario XT Classical Strings, Normal Tension', 15, 'ACC', 'Normal Classical Strings')

INSERT Products(Name, Price, Type, Description)
VALUES ('Ernie Ball 2003 Earthwood 80/20 Bronze Medium Light Acoustic Strings', 6, 'ACC', 'Light Acoustic Strings')

INSERT Products(Name, Price, Type, Description)
VALUES ('Snark Super Snark 2-Clip Tuner', 30, 'ACC', 'Digital Tuner')

INSERT Products(Name, Price, Type, Description)
VALUES ('Korg AW-LT100G Clip-On Guitar Tuner', 19, 'ACC', 'Digital Tuner')

INSERT Products(Name, Price, Type, Description)
VALUES ('DR Pro DR259 MS1500BK Low Profile Mic Boom Stand', 59, 'ACC', 'Mic Stand')

INSERT Products(Name, Price, Type, Description)
VALUES ('DR Pro Tripod Mic Stand with Telescoping Boom', 69, 'ACC', 'Mic Stand')

INSERT Products(Name, Price, Type, Description)
VALUES ('Proline HT1010', 22, 'ACC', 'Guitar Stand')



INSERT LocationProducts(LocationID, ProductID, Inventory)
VALUES(5, 1, 14)

INSERT LocationProducts(LocationID, ProductID, Inventory)
VALUES(5, 5, 12)

INSERT LocationProducts(LocationID, ProductID, Inventory)
VALUES(5, 6, 11)
*/

SELECT * FROM OrderProducts 

SELECT * FROM Orders

SELECT * FROM Locations

SELECT * FROM LocationProducts

SELECT * FROM Products

SELECT * FROM BillingInformation

SELECT * FROM Customers
SELECT * FROM Products
/*
SELECT * FROM UserAccounts

SELECT * FROM Locations

SELECT * FROM BillingInformation

SELECT * FROM Customers

SELECT * FROM CustomersBilling
*/
