'use strict';

const path = require('path');
const dotenv = require('dotenv');

const webApi = require('./app');
const mongoDbConnection = require('./Persistence/mongoDb.Helper');

// Load the Configuration from the given Path
dotenv.config({ path: path.resolve(process.cwd(), 'src/config/.env')});


mongoDbConnection
    .connectToMongoDb()
    .then(() => {

        var port = process.env.PORT || 3000;

        // Listen to the server
        webApi.listen(port, () => {
            console.log(`Env Port: ${process.env.PORT}`);
            console.log(`Server Listening at port ${port}. http://localhost:${port}`);
        });

    })
    .catch((error) => {

        console.log(`Error:: Unable to connect to Mongo Database. Message:: ${error}`);

    });
