const _ = require('lodash');

module.exports = async function (context, req) {

    context.log(`Inputs Name=${req.body.name} Digits=${req.body.digits} received for HttpTrigger Function.`);

    const inputs = (req.body && req.body.name && req.body.digits);
    let name = '';
    let digits = [];

    if (inputs) {
        name = req.body.name;
        digits = req.body.digits;
    }

    digits.forEach(digit => context.log(digit));

    context.log(`Returning the output`);

    context.res = (inputs) ? {
        status: 200,
        body: {
            success: true,
            message: `Hello, ${name} welcome to Array Operations.`,
            executedAt: process.env["COMPUTERNAME"],
            reverseData: _.reverse(digits),
            partitionData: _.partition(digits, n => n % 2)
        }
    } : {
        status: 400,
        body: {
            success: false,
            message: "Please Pass a 'name' and 'data' in the request body for a response."
        }
    };
}

    // context.log(`${req.query?.digits} :: ${req.body?.name}`);
    // context.log(`${req.body?.digits} :: ${req.body?.name}`);
