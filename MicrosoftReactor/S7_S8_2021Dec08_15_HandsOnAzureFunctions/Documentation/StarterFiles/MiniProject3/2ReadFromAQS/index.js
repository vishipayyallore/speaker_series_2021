module.exports = async function (context, myQueueItem) {
    context.log('JavaScript queue trigger function processed work item', myQueueItem);

    context.bindings.outputBlob = context.bindings.myQueueItem;
    context.done();

};