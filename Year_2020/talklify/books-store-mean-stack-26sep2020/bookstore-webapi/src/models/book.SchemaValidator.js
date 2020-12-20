'use strict';

const joiValidator = require('@hapi/joi');

const bookSchemaValidator = joiValidator.object({

    author: joiValidator.string().required(),

    title: joiValidator.string().required(),

    dateOfPublish: joiValidator.date(),

    language: joiValidator.string(),

    read: joiValidator.bool()

});

module.exports = bookSchemaValidator;
