module.exports = async function (context, myTimer) {
    var timeStamp = new Date().toISOString();

    var person = {
        name: 'Shiva',
        dateTime: timeStamp
    };

    if (myTimer.IsPastDue) {
        context.log('JavaScript is running late!');
    }
    context.log('JavaScript timer trigger function ran!', timeStamp);

    context.bindings.outputQueueItem = person;
    context.done();

};