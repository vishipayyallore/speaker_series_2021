const _ = require('lodash');

module.exports = async function (context, req) {

    context.log(`Inputs Name=${req.body.name} Digits=${req.body.digits} received for HttpTrigger Function.`);

    const inputs = (req.body && req.body.name && req.body.digits);
    let name = '';
    let digits = [];

    if (inputs) {
        name = req.body.name;
        digits = req.body.digits;
    } else {
        name = 'No Name';
    }

    digits.forEach(digit => context.log(digit));

    context.log(`Returning the output`);

    // Writing in Table Storage
    context.bindings.outputTable = [];

    context.res = (inputs) ? {
        status: 200,
        body: {
            success: true,
            message: `Hello, ${name} welcome to Array Operations.`,
            executedAt: process.env["COMPUTERNAME"],
            executedOn: new Date().toISOString(),
            reverseData: _.reverse(digits),
            partitionData: _.partition(digits, n => n % 2)
        }
    } : {
        status: 400,
        body: {
            success: false,
            executedAt: process.env["COMPUTERNAME"],
            executedOn: new Date().toISOString(),
            message: "Please Pass a 'name' and 'data' in the request body for a response."
        }
    };

    context.bindings.outputTable.push({
        PartitionKey: name,
        RowKey: uuidv4(),
        OutputStatus: context.res.status,
        OutputData: context.res.body,
    });
}

function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
