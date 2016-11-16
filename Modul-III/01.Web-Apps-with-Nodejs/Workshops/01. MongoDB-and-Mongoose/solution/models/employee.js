const mongoose = require("mongoose");

const givaway = ['Give away', 'For Sale'];

function dateValidator(val) {
    return val < new Date();
}

const dateValidate = [dateValidator, "asdasdas"];

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

const itemSchema = new mongoose.Schema({
    itemName: {
        type: String,
        match: /[a-zA-Z]/,
        required: true
    },
    itemPrice: {
        type: Number
    },
    status: {
        type: String,
        enum: givaway
    },
    offerStartDate: {
        type: Date,
        default: Date.now
    },
    offerEndDate: {
        type: Date,
        validate: dateValidate,
        default: Date.now
    }
});

const employeeSchema = new mongoose.Schema({
    firstName: {
        type: String,
        match: /^[A-Z]([a-z]?)+$/,
        required: true
    },
    middleName: {
        type: String,
        match: /^[A-Z]([a-z]?)+$/,
        required: true
    },
    lastName: {
        type: String,
        match: /^[A-Z]([a-z]?)+$/,
        required: true
    },
    insuranceNumber: {
        type: String,
        match: /[a-zA-Z0-9-]/,
        required: true
    },
    age: {
        type: Number,
        min: 0,
        max: 120
    },
    contactDetails: contactsSchema,
    itemsForSale: {
        type: [itemSchema]
    }
});

mongoose.model('Employee', employeeSchema);

module.exports = mongoose.model('Employee');