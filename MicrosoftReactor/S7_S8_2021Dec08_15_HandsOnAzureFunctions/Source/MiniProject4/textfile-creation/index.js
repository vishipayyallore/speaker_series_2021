module.exports = async function (context, textfiles) {
    context.log("JavaScript blob trigger function processed blob \n Blob:", context.bindingData.blobTrigger, "\n Blob Size:", textfiles.length, "Bytes");

    context.bindings.tableBinding = [];

    context.bindings.tableBinding.push({
        PartitionKey: 'TextFiles',
        RowKey: uuidv4(),
        FullName: context.bindingData.blobTrigger,
        FileSize: textfiles.length
    });
};

function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}