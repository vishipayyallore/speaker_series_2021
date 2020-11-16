'use strict';

const webApi = require('./app');
const mongoDbConnection = require('./Persistence/mongoDb.Helper');
const path = require('path');
const dotenv = require('dotenv');

// Load the Configuration from the given Path
const _config = dotenv.config({ path: path.resolve(process.cwd(), 'src/config/.env')});

var port = process.env.PORT || 3000;

mongoDbConnection
    .connectToMongoDb()
    .then(() => {

        // Listen to the server
        webApi.listen(port, () => {
            console.log(`Env Port: ${process.env.PORT}`);
            console.log(`Server Listening at port ${port}. http://localhost:${port}`);
        });

    })
    .catch((error) => {

        console.log(`Error:: Unable to connect to Mongo Database. Message:: ${error}`);

    });
