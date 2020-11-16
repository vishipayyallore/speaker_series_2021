'use strict';

const mongoose = require('mongoose');
const { Schema } = mongoose;

const bookModel = new Schema({
    author: { type: String, required: true },

    title: { type: String, required: true },

    dateOfPublish: { type: Date, required: true, default: new Date().toUTCString() },

    language: { type: String, default: 'C#' },

    read: { type: Boolean, default: false }
});

module.exports = mongoose.model('book', bookModel);


