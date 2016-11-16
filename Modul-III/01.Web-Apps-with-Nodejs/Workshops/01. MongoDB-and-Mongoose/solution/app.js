const mongoose = require('mongoose');
const Employee = require('./models/employee');

mongoose.connect('mongodb://localhost:27017/TelerikFriends');

const db = mongoose.connection;

db.on('error', (err) => {
    console.log('Connection failed! ' + err);
});

db.on('open', () => {
    console.log('Connection successfull!');
});


var em = new Employee({
    firstName: "Goshko",
    middleName: "Petrov",
    lastName: "Ivanov",
    insuranceNumber: "123123",
    age: 12,
    contactDetails: {
        phoneNumber: "089 882",
        email: "pesho@abv.bg",
        workRoomNumber: 147
    },
    itemsForSale: [
        {
            itemName: "test",
            itemPrice: 222,
            status: 'Give away',
            offerStartDate: new Date(),
            offerEndDate: new Date() + 123
        }
    ]
});

em.save((err, entry, nummAffected) => {
    console.log(entry);
    console.log(nummAffected);
});

