'use strict';

const mongoose = require('mongoose');
require('dotenv/config');

const connectToMongoDb = async () => {

    await mongoose.connect(process.env.MongoDbConnection, {

        useNewUrlParser: true,
        useUnifiedTopology: true

    }, (error) => {

        if (error) {

            console.log(`Error Connecting to Cloud MongoDb ${error}`);
            throw new Error(error);
        } else {

            // Connecting to the MongoDb Cloud Instance
            console.log(`Mongo Db Connection: ${process.env.MongoDbConnection}`);
            console.log('Connected to MongoDb in Cloud');
        }

    });
}

module.exports = { connectToMongoDb };
