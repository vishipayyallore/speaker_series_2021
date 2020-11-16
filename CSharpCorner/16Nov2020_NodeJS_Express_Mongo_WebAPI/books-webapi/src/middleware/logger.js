'use strict';

const morgan = require('morgan')
const chalk = require('chalk');

// Logger Middleware
const morganLogger = morgan(function (tokens, req, res) {
    return chalk.blue.bold([
        'Method:', tokens.method(req, res),
        '\tEnd Point:', tokens.url(req, res),
        '\tStatus:', tokens.status(req, res),
        '\tContent Length:', tokens.res(req, res, 'content-length'),
        '\tResponse Time', tokens['response-time'](req, res), 'ms'
    ].join(' '));
});

module.exports = morganLogger;

/*
const logger = (req, res, next) => {

    console.log(
      `${req.method} ${req.protocol}://${req.get('host')}${req.originalUrl}`
    );

    next();

};
*/

