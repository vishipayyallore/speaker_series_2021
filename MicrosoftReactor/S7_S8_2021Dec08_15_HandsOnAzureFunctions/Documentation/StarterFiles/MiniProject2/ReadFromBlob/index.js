module.exports = async function (context, myBlob) {
    context.log("JavaScript blob trigger function processed blob \n Blob:", context.bindingData.blobTrigger, "\n Blob Size:", myBlob.length, "Bytes");

    // context.log('Binding Data: ', JSON.stringify(context.bindingData));

    // Writing in Table Storage
    context.bindings.outputTable = [];

    context.bindings.outputTable.push({
        PartitionKey: context.bindingData.invocationId,
        RowKey: uuidv4(),
        BlobData: context.bindingData.blobTrigger,
        DataLength: myBlob.length
    });

};

function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
