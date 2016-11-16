const mongoose = require('mongoose');

const contactsSchema = new mongoose.Schema({
    phoneNumber: {
        type: String,
        match: /[0-9]{3}\s?/
    },
    email: {
        type: String,
        required: true
    },
    workRoomNumber: {
        type: Number,
        min: 100,
        max: 999,
        match: /[0-9]{3}/
    }
});

mongoose.model('Contacts', contactsSchema);

module.exports = contactsSchema;